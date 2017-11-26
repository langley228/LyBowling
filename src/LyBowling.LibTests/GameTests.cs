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
            if (g.GetSource() != 300)
            {
                Assert.Fail();
            }
            t = g.ReSet();
            for (int i = 0; i < 12; i++)
            {
                t = t.Play(10);
            }
            if (g.GetSource() != 300)
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetSource_Sample_133()
        {
            Game g = new Game(10);
            Throw t = g.Start();
            t = t.Play(1);
            t = t.Play(4);
            t = t.Play(4);
            t = t.Play(5);
            t = t.Play(6);
            t = t.Play(4);
            t = t.Play(5);
            t = t.Play(5);
            t = t.Play(10);
            t = t.Play(0);
            t = t.Play(1);
            t = t.Play(7);
            t = t.Play(3);
            t = t.Play(6);
            t = t.Play(4);
            t = t.Play(10);
            t = t.Play(2);
            t = t.Play(8);
            t = t.Play(6);
            if (g.GetSource() != 133)
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
            if (g.GetSource() != 113)
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
            if (g.GetSource() != 102)
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
            if (g.GetSource() != 128)
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
            if (g.GetSource() != 100)
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
            if (g.GetSource() != 220)
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
            if (g.GetSource() != 161)
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
            if (g.GetSource() != 150)
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
            if (g.GetSource() != 76)
            {
                Assert.Fail();
            }
        }
    }
}