using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyBowling.Lib
{
    /// <summary>
    /// 丟球
    /// </summary>
    public class Throw
    {
        /// <summary>
        /// 丟球
        /// </summary>
        public Throw() { }

        /// <summary>
        /// 丟球前瓶數
        /// </summary>
        public int Before { get; set; } = 10;
        /// <summary>
        /// 丟球後瓶數
        /// </summary>
        public int After { get; set; } = 10;
        /// <summary>
        /// 擊倒瓶數
        /// </summary>
        public int? Fall { get; set; }

        /// <summary>
        /// 執行丟球
        /// </summary>
        /// <param name="fall"></param>
        /// <returns></returns>
        public Throw Play(int? fall)
        {
            this.Fall = fall;
            if (fall.HasValue)
                After = Before - fall.Value;
            return Next();
        }

        /// <summary>
        /// 下一球
        /// </summary>
        public Func<Throw> Next;


        /// <summary>
        /// 位置
        /// </summary>
        public Func<int> Index;

        /// <summary>
        /// 隸屬計分格的位置
        /// </summary>
        public Func<int> FrameIndex;

        /// <summary>
        /// 計分格
        /// </summary>
        public Func<Frame> Frame;

        /// <summary>
        /// 是否為Strike
        /// </summary>
        public Func<bool> IsStrike;

        /// <summary>
        /// 是否為Spare
        /// </summary>
        public Func<bool> IsSpare;

        /// <summary>
        /// 是否為計分格第一球
        /// </summary>
        public Func<bool> IsFrameFirst;

        /// <summary>
        /// 是否為最後一球
        /// </summary>
        public Func<bool> IsGameLast;

        /// <summary>
        /// 分數
        /// </summary>
        public Func<int> Source;
        /// <summary>
        /// 附加分數
        /// </summary>
        public Func<int, int> Extra;
    }
}
