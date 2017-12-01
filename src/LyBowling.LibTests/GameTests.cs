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
        public void GetSource_Sample_113()
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
            t = t.Play(8);
            t = t.Play(10);
            if (g.Source() != 113)
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
        public void GetSource_Sample_128()
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
            t = t.Play(7);
            t = t.Play(7);
            if (g.Source() != 128)
                Assert.Fail();
        }
        [TestMethod()]
        public void GetSource_Sample_100()
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
            t = t.Play(5);
            t = t.Play(6);
            if (g.Source() != 100)
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
        public void GetSource_Sample_161()
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
            t = t.Play(7);
            if (g.Source() != 161)
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
    }
}