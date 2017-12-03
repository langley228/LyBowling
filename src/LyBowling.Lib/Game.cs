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
            Frames = () => _Frames;
            Frame = (index) => _Frames.ElementAtOrDefault(index);
            Throws = () => _Throws;
            Throw = (index) => _Throws.ElementAtOrDefault(index);
            Source = () => _Frames.Where(m => m != null).Sum(m => m.Source());
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
        /// 產生新的丟球
        /// </summary>
        /// <returns></returns>
        private Throw CreateThrow()
        {
            Throw newThrow = new Throw();
            newThrow.Index = () => Array.IndexOf(_Throws, newThrow);
            newThrow.Frame = () =>
            {
                int index = newThrow.Index() / 2;
                if (index > _Frames.Length - 1)
                    index = _Frames.Length - 1;
                if (_Frames[index] == null)
                    _Frames[index] = CreateFrame(index);
                return _Frames[index];
            };
            newThrow.Previous = () => Throw(newThrow.Index() - 1);
            newThrow.Next = () => Throw(newThrow.Index() + 1);
            newThrow.IsSkip = () => (!newThrow.Frame().IsLast() && newThrow.Previous().IsStrike()) ||
                                        (newThrow.IsThree() && newThrow.Frame().Fall() < 10);
            newThrow.IsThree = () => newThrow.Index() == _Throws.Length - 1;
            newThrow.IsFirst = () => !newThrow.IsThree() && (newThrow.Index() + 1) % 2 == 1;
            newThrow.IsSecond = () => !newThrow.IsThree() && (newThrow.Index() + 1) % 2 == 0;
            newThrow.IsThree = () => newThrow.Index() == _Throws.Length - 1;
            newThrow.IsStrike = () => newThrow.IsFirst() && newThrow.Fall.HasValue && newThrow.Fall.Value == 10;
            newThrow.IsSpare = () => newThrow.IsSecond() && !newThrow.Previous().IsStrike() && ((newThrow.Previous().Fall ?? 0) + (newThrow.Fall ?? 0)) == 10;
            newThrow.Play = (fall) =>
            {
                newThrow.Fall = fall;
                if (fall.HasValue)
                {
                    if (newThrow.Fall.Value > newThrow.Before)
                        newThrow.Fall = newThrow.Before;

                    newThrow.After = newThrow.Before - newThrow.Fall.Value;
                }

                int index = newThrow.Index();
                Throw next = null;
                index++;
                if (!newThrow.IsThree())
                {
                    _Throws[index] = CreateThrow();
                    next = _Throws[index];
                    if (next.IsSkip())
                        next = next.Skip();
                    else
                        next.Start();
                }
                return next;
            };
            newThrow.Skip = () =>
            {
                newThrow.After = 0;
                newThrow.Before = 0;
                return newThrow.Play(null);
            };
            newThrow.Start = () =>
            {
                if (( newThrow.IsSecond() &&!newThrow.Previous().IsStrike()) || (newThrow.IsThree() && newThrow.Previous().After!=0))
                {
                    newThrow.After = newThrow.Previous().After;
                    newThrow.Before = newThrow.Previous().After;
                }
            };
            newThrow.Source = () =>
            {
                if (!newThrow.Fall.HasValue)
                    return 0;

                int source = newThrow.Fall ?? 0;

                if (!newThrow.Frame().IsLast() && newThrow.IsStrike())
                    source +=_Throws.Skip(newThrow.Index()+1).Where(m=> m!=null && m.Fall.HasValue).Take(2).Sum(m=>m.Fall.Value);
                else if (!newThrow.Frame().IsLast() && newThrow.IsSpare())
                    source += _Throws.Skip(newThrow.Index() + 1).Where(m => m != null&& m.Fall.HasValue).Take(1).Sum(m => m.Fall.Value);

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
            frame.Index = () => Array.IndexOf(_Frames, frame);
            frame.Fall = () => frame.Throws().Sum(m => m?.Fall ?? 0);
            frame.IsLast = () => frame.Index() == _Frames.Length - 1;
            return frame;
        }


        /// <summary>
        /// 所有計分格 
        /// </summary>
        public Func<IEnumerable<Frame>> Frames;

        /// <summary>
        /// 某個計分格
        /// </summary>
        public Func<int, Frame> Frame;
        /// <summary>
        /// 所有丟球
        /// </summary>
        public Func<IEnumerable<Throw>> Throws;
        /// <summary>
        /// 某一球
        /// </summary>
        public Func<int, Throw> Throw;
        /// <summary>
        /// 總分
        /// </summary>
        public Func<int> Source;
        
    }
}
