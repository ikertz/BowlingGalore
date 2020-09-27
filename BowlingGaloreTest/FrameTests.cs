using BowlingGalore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Xunit.Sdk;

namespace BowlingGaloreTest
{
    [TestClass]
    public class FrameTests
    {
        private Frame InitializeFrame(int _score1, int _score2)
        {
            ArrayList frameScore = new ArrayList();
            frameScore.Add(_score1);
            frameScore.Add(_score2);
            return new Frame(frameScore);
        }

        [TestMethod]
        public void GetTotalScoreTest()
        {
            //setup
            const int expectedScore = 9;
            Frame frame = InitializeFrame(3, 6);

            //execute
            frame.CalculateFrameScore();

            //Verify
            Assert.IsTrue(expectedScore == frame.GetScore());
        }

        [TestMethod]
        public void IsOpenFrameTest()
        {
            //setup
            Frame frame = InitializeFrame(3, 6);

            //execute
            frame.CalculateFrameScore();

            //Verify
            Assert.IsTrue(frame.IsOpenFrame());
        }

        [TestMethod]
        public void IsSpareTest()
        {
            //setup
            Frame frame = InitializeFrame(4, 6);

            //execute
            frame.CalculateFrameScore();

            //Verify
            Assert.IsTrue(frame.IsSpare());
        }

        [TestMethod]
        public void IsStrikeTest()
        {
            //setup
            Frame frame = InitializeFrame(10, 0);

            //execute
            frame.CalculateFrameScore();

            //Verify
            Assert.IsTrue(frame.IsSpare());
        }
    }
}
