using System.Collections.Generic;

namespace BowlingGalore
{
    /// <summary>
    /// Maintains a player score card.
    /// </summary>
    public class ScoreCard
    {
        /// <summary>
        /// Gets or Sets the list of frames in a game
        /// </summary>
        public List<IFrame> Frames { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ScoreCard()
        {
            Frames = new List<IFrame>();
        }

        /// <summary>
        /// Calculates the total score in a game
        /// </summary>
        /// <returns>Total score</returns>
        public int GetTotalScore()
        {
            int totalScore = 0;

            for (int i = 0; i < Frames.Count; i++)
            {
                Frame currentFrame = Frames[i] as Frame;

                if (currentFrame.IsStrike())
                {
                    if (i + 1 < Frames.Count)
                    {
                        Frame nextFrame = Frames[i + 1] as Frame;
                        totalScore = totalScore + currentFrame.GetScore() + nextFrame.GetScore();
                    }
                    else
                    {
                        totalScore = totalScore + currentFrame.GetScore();
                    }
                }
                else if (currentFrame.IsSpare())
                {
                    if (i + 1 < Frames.Count)
                    {
                        Frame nextFrame = Frames[i + 1] as Frame;
                        totalScore = totalScore + currentFrame.GetScore() + (int)nextFrame.ScoreEntries[0];
                    }
                    else
                    {
                        totalScore = totalScore + currentFrame.GetScore();
                    }
                }
                else
                {
                    totalScore = totalScore + currentFrame.GetScore();
                }
            }

            return totalScore;
        }
    }
}
