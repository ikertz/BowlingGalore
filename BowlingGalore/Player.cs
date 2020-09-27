namespace BowlingGalore
{
    /// <summary>
    /// Maintains a player record
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets and Sets the score card for a player
        /// </summary>
        public ScoreCard Score { get; set; }

        /// <summary>
        /// Gets and sets the name of a player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="_name">player name</param>
        public Player(string _name)
        {
            Name = _name;
            Score = new ScoreCard();
        }
    }
}
