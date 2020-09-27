using System;
using System.Collections;
using static System.Console;

namespace BowlingGalore
{
    /// <summary>
    /// The main class for the game
    /// </summary>
    public class Bowl
    {
        static void Main(string[] args)
        {
            WriteLine(" ==============================\n WELCOME TO BOWLING GALORE!\n ==============================\n\n");
            Write("Enter the number of players: ");
            string result = ReadLine();
            int numberOfPlayers = ValidateUserIntegerInput(result);

            Play(numberOfPlayers);
        }

        private static void Play(int _numberOfPlayers)
        {
            Player[] players = InitializePlayers(_numberOfPlayers);

            const int numberOfFrames = 10;
            const int strikeScore = 10;
            for (int i = 0; i < numberOfFrames; i++)
            {
                foreach (Player player in players)
                {
                    ArrayList scores = new ArrayList();

                    WriteLine("\n Player " + player.Name + " it is your round: \n");
                    int score;
                    Write("Enter your first score: ");
                    score = EnterScore(scores);
                    scores.Add(score);

                    if (score < strikeScore || i == (numberOfFrames - 1))
                    {
                        Write("Enter your second score: ");
                        score = EnterScore(scores);
                        scores.Add(score);

                        if (i == (numberOfFrames - 1))
                        {
                            Write("Enter your third score: ");
                            score = EnterScore(scores, true);
                            scores.Add(score);
                        }
                    }

                    Frame frame = new Frame(scores);
                    frame.CalculateFrameScore();
                    player.Score.Frames.Add(frame);
                }
            }

            DisplayPlayerScores(players);
            
        }

        private static void DisplayPlayerScores(Player[] _players)
        {
            foreach (Player player in _players)
            {
                WriteLine(player.Name);
                foreach (Frame frame in player.Score.Frames)
                {
                    foreach (var item in frame.ScoreEntries)
                    {
                        Write("| " + item);
                    }
                    WriteLine("");
                }
                WriteLine("");

                WriteLine("Total score for " + player.Name + " = " + player.Score.GetTotalScore());
            }
        }

        private static bool ValidateScoreAmount(ArrayList _scores, int currentScore, bool _isLastFrame)
        {
            bool valid;

            int totalScore = 0;
            foreach (int item in _scores)
            {
                totalScore = totalScore + item;
            }

            if (_isLastFrame && currentScore > 10)
            {
                valid = false;
            }
            else if (!_isLastFrame && (totalScore + currentScore) > 10)
            {
                valid = false;
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        private static int EnterScore(ArrayList _scores, bool _isLastFrame = false)
        {
            return ValidateScoreEntry(ReadLine(), _scores, _isLastFrame);
        }

        private static int ValidateScoreEntry(string _input, ArrayList _scores, bool _isLastFrame)
        {
            int validatedScoreEntry = ValidateUserIntegerInput(_input);

            while (!ValidateScoreAmount(_scores, validatedScoreEntry, _isLastFrame))
            {
                WriteLine("The total score for a frame cannot exceed 10, Try again.");
                validatedScoreEntry = EnterScore(_scores, _isLastFrame);
            }

            return validatedScoreEntry;
        }

        private static int ValidateUserIntegerInput(string _input)
        {
            int validatedUserIntegerInput;

            while (!Int32.TryParse(_input, out validatedUserIntegerInput))
            {
                WriteLine("Not a valid number, try again.");
                _input = ReadLine();
            }

            return validatedUserIntegerInput;
        }

        private static Player[] InitializePlayers(int _numberOfPlayers)
        {
            Player[] players = new Player[_numberOfPlayers];
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                WriteLine("\n");
                Write("Enter player name: ");
                string playerName = ReadLine();
                Player player = new Player(playerName);
                players[i] = player;
            }

            return players;
        }
    }
}
