using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyBowling.Lib
{
    /// <summary>
    /// 計分格
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// 計分格
        /// </summary>
        public Frame() { }

        /// <summary>
        /// 計分格位置
        /// </summary>
        public Func<int> Index;

        /// <summary>
        /// 球 
        /// </summary>
        public Func<IEnumerable<Throw>> Throws;

        /// <summary>
        /// 分數
        /// </summary>
        public Func<int> Source;

        /// <summary>
        /// 是否為最後一計分格
        /// </summary>
        public Func<bool> IsLast;

        /// <summary>
        /// 擊倒瓶數
        /// </summary>
        public Func<int> Fall;
    }
}
