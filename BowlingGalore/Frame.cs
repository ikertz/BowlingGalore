using System.Collections;

namespace BowlingGalore
{
    public class Frame : IFrame
    {
        private bool isSpare;
        private bool isStrike;
        private bool isOpenFrame;
        private int score;

        /// <summary>
        /// Gets and Sets the list of score entries in a Frame
        /// </summary>
        /// <returns></returns>
        public ArrayList ScoreEntries { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_scoreEntries">Score entry for the frame</param>
        public Frame(ArrayList _scoreEntries)
        {
            ScoreEntries = _scoreEntries;
        }

        /// <summary>
        /// Calculates the total score for the frame
        /// </summary>
        public void CalculateFrameScore()
        {
            if (ScoreEntries.Count == 1)
            {
                score = 10;
                isStrike = true;
            }
            else if (ScoreEntries.Count == 2)
            {
                AddScoreEntries();

                if (score == 10)
                {
                    isSpare = true;
                }
                else
                {
                    isOpenFrame = true;
                }
            }
            else
            {
                AddScoreEntries();
            }
        }

        /// <summary>
        /// Determines if the Frame score is neither a spare nor a strike
        /// </summary>
        /// <returns></returns>
        public bool IsOpenFrame()
        {
            return isOpenFrame;
        }

        /// <summary>
        /// Determines if the Frame score is s spare
        /// </summary>
        /// <returns></returns>
        public bool IsSpare()
        {
            return isSpare;
        }

        /// <summary>
        /// Determines if the Frame score is a strike
        /// </summary>
        /// <returns></returns>
        public bool IsStrike()
        {
            return isStrike;
        }

        /// <summary>
        /// Get the frame score
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            return score;
        }

        private void AddScoreEntries()
        {
            foreach (int scoreEntry in ScoreEntries)
            {
                score = score + scoreEntry;
            }
        }
    }
}
