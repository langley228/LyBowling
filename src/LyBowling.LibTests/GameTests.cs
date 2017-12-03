using Microsoft.VisualStudio.TestTools.UnitTesting;
using LyBowling.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyBowling.Lib.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GetSource_270()
        {
            Game g = new Game(10);
            Throw t1 = g.Start();
            for (int i = 0; i < 9; i++)
                t1= t1.Play(10);
            t1 = t1.Play(9);
            t1 = t1.Play(1);
            t1 = t1.Play(1);
            Assert.AreEqual(270, g.Source());
        }
        [TestMethod()]
        public void GetSource_Before()
        {
            Game g = new Game(10);
            Throw t1 = g.Start();
            for (int i = 0; i < 9; i++)
                t1 = t1.Play(10);
            t1 = t1.Play(1);
            t1 = t1.Play(9);
            t1 = t1.Play(1);

            if (g.Throw(20).Before != 10)
                Assert.Fail();
            if (g.Throw(20).After!=9)
                Assert.Fail();

        }
        [TestMethod()]
        public void GetSource_Strike()
        {
            Game g = new Game(10);
            Throw t1 = g.Start();
            Throw t2 = t1.Play(10);
            if (!t1.IsStrike())
                Assert.Fail();
            if (!g.Throw(1).IsSkip())
                Assert.Fail();
            if (!t2.IsFirst())
                Assert.Fail();
        }
        [TestMethod()]
        public void GetSource_LastSkip()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            for (int i = 0; i < 9; i++)
            {
                t = t.Play(10);
            }
            Throw t1 = t.Play(9);
            Throw t2 = t1.Play(0);
            if (t2!=null)
            {
                Assert.Fail();
            }
            if (!g.Throw(20).IsSkip())
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        public void GetSource_300()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            for (int i = 0; i < 12; i++)
            {
                t = t.Play(10);
            }
            if (g.Source() != 300)
            {
                Assert.Fail();
            }
            t = g.ReSet();
            for (int i = 0; i < 12; i++)
            {
                t = t.Play(10);
            }
            if (g.Source() != 300)
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetSource_Sample_133()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(1).Play(4);
            t = t.Play(4).Play(5);
            t = t.Play(6).Play(4);
            t = t.Play(5).Play(5);
            t = t.Play(10);
            t = t.Play(0).Play(1);
            t = t.Play(7).Play(3);
            t = t.Play(6).Play(4);
            t = t.Play(10);
            t = t.Play(2).Play(8).Play(6);
            if (g.Source() != 133)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetSource_Sample_108()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(1);
            t = t.Play(2);
            t = t.Play(4);
            t = t.Play(5);
            t = t.Play(6);
            t = t.Play(0);
            t = t.Play(10);
            t = t.Play(8);
            t = t.Play(2);
            t = t.Play(3);
            t = t.Play(1);
            t = t.Play(0);
            t = t.Play(5);
            t = t.Play(10);
            t = t.Play(6);
            t = t.Play(3);
            t = t.Play(7);
            t = t.Play(3);
            t = t.Play(10);
            if (g.Source() != 108)
                Assert.Fail();
        }
        [TestMethod()]
        public void GetSource_Sample_102()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(2);
            t = t.Play(4);
            t = t.Play(8);
            t = t.Play(1);
            t = t.Play(9);
            t = t.Play(1);
            t = t.Play(10);
            t = t.Play(4);
            t = t.Play(4);
            t = t.Play(2);
            t = t.Play(3);
            t = t.Play(9);
            t = t.Play(1);
            t = t.Play(5);
            t = t.Play(3);
            t = t.Play(8);
            t = t.Play(1);
            t = t.Play(4);
            t = t.Play(0);
            if (g.Source() != 102)
                Assert.Fail();
        }
        [TestMethod()]
        public void GetSource_Sample_126()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(4);
            t = t.Play(6);
            t = t.Play(9);
            t = t.Play(1);
            t = t.Play(4);
            t = t.Play(2);
            t = t.Play(2);
            t = t.Play(6);
            t = t.Play(6);
            t = t.Play(4);
            t = t.Play(2);
            t = t.Play(5);
            t = t.Play(2);
            t = t.Play(8);
            t = t.Play(9);
            t = t.Play(0);
            t = t.Play(6);
            t = t.Play(4);
            t = t.Play(5);
            t = t.Play(5);
            t = t.Play(7);
            if (g.Source() != 126)
                Assert.Fail();
        }
        [TestMethod()]
        public void GetSource_Sample_99()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(4);
            t = t.Play(5);
            t = t.Play(3);
            t = t.Play(0);
            t = t.Play(3);
            t = t.Play(1);
            t = t.Play(8);
            t = t.Play(1);
            t = t.Play(10);
            t = t.Play(7);
            t = t.Play(3);
            t = t.Play(6);
            t = t.Play(4);
            t = t.Play(3);
            t = t.Play(2);
            t = t.Play(2);
            t = t.Play(2);
            t = t.Play(6);
            t = t.Play(4);
            t = t.Play(6);
            if (g.Source() != 99)
                Assert.Fail();
        }
        [TestMethod()]
        public void GetSource_Sample_220()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(10);
            t = t.Play(10);
            t = t.Play(10);
            t = t.Play(3);
            t = t.Play(7);
            t = t.Play(7);
            t = t.Play(3);
            t = t.Play(10);
            t = t.Play(5);
            t = t.Play(5);
            t = t.Play(10);
            t = t.Play(3);
            t = t.Play(7);
            t = t.Play(10);
            t = t.Play(10);
            t = t.Play(10);
            if (g.Source() != 220)
                Assert.Fail();
        }
        [TestMethod()]
        public void GetSource_Sample_157()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(10);
            t = t.Play(10);
            t = t.Play(9);
            t = t.Play(1);
            t = t.Play(0);
            t = t.Play(10);
            t = t.Play(2);
            t = t.Play(8);
            t = t.Play(6);
            t = t.Play(2);
            t = t.Play(10);
            t = t.Play(10);
            t = t.Play(0);
            t = t.Play(6);
            t = t.Play(10);
            t = t.Play(7);
            t = t.Play(3);
            if (g.Source() != 157)
                Assert.Fail();
        }


        [TestMethod()]
        public void GetSource_5_150()
        {
            Game g = new Game(5);
            Throw t = g.Start();
            for (int i = 0; i < 7; i++)
            {
                t = t.Play(10);
            }
            if (g.Source() != 150)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetSource_5_76()
        {
            Game g = new Game(5);
            Throw t = g.Start();
            t = t.Play(2);
            t = t.Play(8);
            t = t.Play(10);

            t = t.Play(7);
            t = t.Play(3);
            t = t.Play(6);
            t = t.Play(0);
            t = t.Play(3);
            t = t.Play(7);
            t = t.Play(4);
            if (g.Source() != 76)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetSource_Over()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            for (int i = 0; i < 12; i++)
            {
                t = t.Play(40);
            }
            if (g.Source() != 300)
            {
                Assert.Fail();
            }
            t = g.ReSet();
            for (int i = 0; i < 12; i++)
            {
                t = t.Play(40);
            }
            if (g.Source() != 300)
            {
                Assert.Fail();
            }
        }
    }
}