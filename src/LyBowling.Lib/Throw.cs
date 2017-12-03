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
        public Func<int? ,Throw> Play;

        /// <summary>
        /// 略過丟球
        /// </summary>
        public Func<Throw> Skip;

        /// <summary>
        /// 開始丟球
        /// </summary>
        public Action Start;

        /// <summary>
        /// 上一球
        /// </summary>
        public Func<Throw> Previous;
        /// <summary>
        /// 下一球
        /// </summary>
        public Func<Throw> Next;

        /// <summary>
        /// 位置
        /// </summary>
        public Func<int> Index;

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
        public Func<bool> IsFirst;
        /// <summary>
        /// 是否為計分格第二球
        /// </summary>
        public Func<bool> IsSecond;

        /// <summary>
        /// 是否為計分格第三球
        /// </summary>
        public Func<bool> IsThree;

        /// <summary>
        /// 是否為最後一球
        /// </summary>
        public Func<bool> IsLast;

        /// <summary>
        /// 是否略過此球 
        /// </summary>
        public Func<bool> IsSkip;

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
