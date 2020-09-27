namespace BowlingGalore
{
    public interface IFrame
    {
        /// <summary>
        /// Get the frame score
        /// </summary>
        /// <returns></returns>
        int GetScore();
        
        /// <summary>
        /// Determines if the Frame score is a strike
        /// </summary>
        /// <returns></returns>
        bool IsStrike();

        /// <summary>
        /// Determines if the Frame score is s spare
        /// </summary>
        /// <returns></returns>
        bool IsSpare();

        /// <summary>
        /// Determines if the Frame score is neither a spare nor a strike
        /// </summary>
        /// <returns></returns>
        bool IsOpenFrame();

    }
}
