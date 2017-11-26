using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyBowling.Lib
{
    /// <summary>
    /// 保齡球Game
    /// </summary>
    public class Game
    {
        private int _FrameCount = 10;
        private Throw[] _Throws;
        private Frame[] _Frames;
        /// <summary>
        /// 保齡球Game
        /// </summary>
        public Game() : this(10) { }
        /// <summary>
        /// 保齡球Game
        /// </summary>
        /// <param name="frameCount">計分格數</param>
        public Game(int frameCount)
        {
            _FrameCount = frameCount;
            init();
        }
        private void init()
        {
            _Throws = new Throw[_FrameCount * 2 + 1];
            _Frames = new Frame[_FrameCount];
        }
        /// <summary>
        /// 計分格數量
        /// </summary>
        public int FrameCount
        {
            get
            {
                return _FrameCount;
            }
        }
        /// <summary>
        /// 重新開始
        /// </summary>
        /// <param name="frameCount">計分格數</param>
        /// <returns></returns>
        public Throw ReSet(int frameCount)
        {
            _FrameCount = frameCount;
            init();
            return Start();
        }
        /// <summary>
        /// 重新開始
        /// </summary>
        /// <returns></returns>
        public Throw ReSet()
        {
            init();
            return Start();
        }
        /// <summary>
        /// 開局
        /// </summary>
        /// <returns></returns>
        public Throw Start()
        {
            _Throws[0] = CreateThrow();
            return _Throws[0];
        }
        /// <summary>
        /// 此位置是否為最後一球
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool IsThrowLast(int index)
        {
            return index == _Throws.Length - 1;
        }
        /// <summary>
        /// 是否可以打最後一球
        /// </summary>
        /// <returns></returns>
        private bool HasThrowLast()
        {
            int iEnd = _Throws.Length - 1;
            return _Throws[iEnd - 2].Fall.HasValue &&
                   _Throws[iEnd - 1].Fall.HasValue &&
                   _Throws[iEnd - 2].Fall.Value + _Throws[iEnd - 1].Fall.Value >= 10;
        }
        /// <summary>
        /// 略過丟球
        /// </summary>
        /// <returns></returns>
        private Throw SkipThrow()
        {
            Throw skip = CreateThrow();
            skip.After = 0;
            skip.Before = 0;
            return skip;
        }

        /// <summary>
        /// 第二次丟球
        /// </summary>
        /// <param name="pre"></param>
        /// <returns></returns>
        private Throw SecondThrow(Throw pre)
        {
            Throw second = CreateThrow();
            second.After = pre.After;
            second.Before = pre.After;
            return second;
        }

        /// <summary>
        /// 產生新的丟球
        /// </summary>
        /// <returns></returns>
        private Throw CreateThrow()
        {
            Throw newThrow = new Throw();
            newThrow.Next = () =>
            {
                int index = newThrow.Index();
                Throw next = null;
                index++;
                if (newThrow != null && !newThrow.IsGameLast())
                {
                    if (!newThrow.Frame().IsGameLast())
                    {
                        if (newThrow.IsFrameFirst() && (newThrow.Fall ?? 0) == 10)
                        {
                            _Throws[index] = SkipThrow();
                            return _Throws[index].Play(null);
                        }
                        else if (newThrow.IsFrameFirst())
                            _Throws[index] = SecondThrow(newThrow);
                        else
                            _Throws[index] = CreateThrow();
                    }
                    else
                    {
                        if (IsThrowLast(index) && !HasThrowLast())
                        {
                            _Throws[index] = SkipThrow();
                            return _Throws[index].Play(null);
                        }
                        else if (newThrow.After > 0)
                            _Throws[index] = SecondThrow(newThrow);
                        else
                            _Throws[index] = CreateThrow();
                    }
                    next = _Throws[index];
                }
                return next;
            };
            newThrow.Index = () => { return Array.IndexOf(_Throws, newThrow); };
            newThrow.IsGameLast = () => { return newThrow.Index() == _Throws.Length - 1; };
            newThrow.FrameIndex = () =>
            {
                int index = newThrow.Index() / 2;
                if (index > _Frames.Length - 1)
                    index = _Frames.Length - 1;
                return index;
            };
            newThrow.Frame = () =>
            {
                int index = newThrow.FrameIndex();
                if (_Frames[index] == null)
                    _Frames[index] = CreateFrame(index);
                return _Frames[index];
            };
            newThrow.IsFrameFirst = () =>
            {
                int index = newThrow.Index();
                if (index < _Throws.Length - 1 && (index + 1) % 2 == 1)
                    return true;
                else
                    return false;
            };
            newThrow.IsStrike = () =>
            {
                return newThrow.IsFrameFirst() && newThrow.Fall.HasValue && newThrow.Fall.Value == 10;
            };
            newThrow.IsSpare = () =>
            {
                return !newThrow.IsFrameFirst() && !newThrow.IsGameLast() &&
                      ((_Throws[newThrow.Index() - 1].Fall ?? 0) + (newThrow.Fall ?? 0)) == 10;
            };
            newThrow.Source = () =>
            {

                if (newThrow == null)
                    return 0;

                if (!newThrow.Fall.HasValue)
                    return 0;

                int source = newThrow.Fall ?? 0;
                if (!newThrow.Frame().IsGameLast())
                {
                    if (newThrow.IsStrike())
                        source += newThrow.Extra(2);
                    else if (newThrow.IsSpare())
                        source += newThrow.Extra(1);

                }
                return source;
            };
            newThrow.Extra = (iCount) =>
            {
                int source = 0;
                int index = newThrow.Index();
                for (int i = index + 1; i < _Throws.Length; i++)
                {
                    if (_Throws[i] == null)
                        break;
                    else if (_Throws[i].Fall.HasValue)
                    {
                        source += _Throws[i].Fall.Value;
                        if (iCount > 1)
                            iCount--;
                        else
                            break;
                    }
                }
                return source;
            };
            return newThrow;
        }
        /// <summary>
        /// 產生計分格
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Frame CreateFrame(int index)
        {
            Frame frame = new Frame();
            frame.Throws = () =>
            {
                int iS = index * 2;
                if (index < _Frames.Length - 1)
                    return _Throws.Skip(iS).Take(2);
                else
                    return _Throws.Skip(iS);
            };
            frame.Source = () =>
            {
                int source = 0;
                foreach (var item in frame.Throws())
                {
                    source += item?.Source() ?? 0;
                }
                return source;
            };
            frame.Index = () => { return Array.IndexOf(_Frames, frame); };
            frame.IsGameLast = () => { return frame.Index() == _Frames.Length - 1; };
            return frame;
        }

        /// <summary>
        /// 總分
        /// </summary>
        /// <returns></returns>
        public int GetSource()
        {
            int source = 0;
            for (int i = 0; i < _Frames.Length; i++)
            {
                if (_Frames[i] == null)
                    _Frames[i] = CreateFrame(i);
                source += _Frames[i].Source();
                //Console.WriteLine(source.ToString());
            }
            return source;
        }
        /// <summary>
        /// 計分格
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Frame> GetFrames()
        {
            return _Frames;
        }
    }
}
