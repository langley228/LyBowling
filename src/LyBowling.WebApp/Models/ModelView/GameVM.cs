using LyBowling.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyBowling.WebApp.Models.ModelView
{
    public class GameVM
    {
        /// <summary>
        /// 計分格
        /// </summary>
        public IEnumerable<Frame> Frames { get; set; }
        /// <summary>
        /// 目前的丟球
        /// </summary>
        public Throw Current { get; set; }
        /// <summary>
        /// 計分格數量
        /// </summary>
        public int FrameCount { get; set; } = 10;
    }
}