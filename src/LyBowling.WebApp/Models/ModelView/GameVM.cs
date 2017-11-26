using LyBowling.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyBowling.WebApp.Models.ModelView
{
    public class GameVM
    {
        public IEnumerable<Frame> Frames { get; set; }
        public Throw Current { get; set; }
        public int FrameCount { get; set; } = 10;
    }
}