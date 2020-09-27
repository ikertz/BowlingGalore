using BowlingGalore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Xunit.Sdk;

namespace BowlingGaloreTest
{
    [TestClass]
    public class ScoreCardTests
    {
        private Player[] InitializePlayersTestData(int _numberOfPlayers)
        {
            Player[] players = new Player[_numberOfPlayers];
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                Player player = new Player("Test");
                players[i] = player;
            }

            players = SetUpPlayerTestScores(players);

            return players;
        }
        
        private Player[] SetUpPlayerTestScores(Player[] _players)
        {
            const int numberOfFrames = 10;
            const int strikeScore = 10;
            const int score = 4;

            for (int i = 0; i < numberOfFrames; i++)
            {
                foreach (Player player in _players)
                {
                    ArrayList scores = new ArrayList();

                    scores.Add(score);

                    if (score < strikeScore || i == (numberOfFrames - 1))
                    {
                        scores.Add(score);

                        if (i == (numberOfFrames - 1))
                        {
                            scores.Add(score);
                        }
                    }

                    Frame frame = new Frame(scores);
                    frame.CalculateFrameScore();
                    player.Score.Frames.Add(frame);
                }
            }

            return _players;
        }

        [TestMethod]
        public void GetTotalScoreTest()
        {
            Player[] players = InitializePlayersTestData(1);

            foreach (Player player in players)
            {
                const int expectedScore = 84;
                Assert.IsTrue(expectedScore == player.Score.GetTotalScore());
            }
        }
    }
}
