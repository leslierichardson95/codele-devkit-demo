namespace CodeleLogic
{
    /// <summary>
    /// Class <c>Guess</c> handles the game logic for Codele.
    /// </summary>
    public class Guess
    {
        public string? Word { get; set; }
        public List<(char, LetterStatus)>? GuessStatus;

        public Guess(string? word)
        {
            this.Word = word;
        }

        /// <summary>
        /// Method <c>GetGuessStatuses</c> evaluates each letter in a guess and determines their status relative to the answer.
        /// </summary>
        public void GetGuessStatuses(string answer)
        {
            if (!string.IsNullOrEmpty(Word))
            {

                GuessStatus = new();

                for (int i = 0; i < 5; i++)
                { 
                    char letter = Word[i];
                    bool isDuplicateInAnswer = answer.Count(x => x == letter) > 1;

                    //Check for duplicate letters
                    if ((GuessStatus.Contains((letter, LetterStatus.Correct)) || GuessStatus.Contains((letter, LetterStatus.IncorrectPosition))) && isDuplicateInAnswer)
                    {
                        GuessStatus.Add((letter, LetterStatus.Incorrect));
                    }
                    else // regular Wordle logic
                    {
                        if (Word[i] == answer[i]) GuessStatus.Add((letter, LetterStatus.Correct));
                        else if (answer.Contains(letter)) GuessStatus.Add((letter, LetterStatus.IncorrectPosition));
                        else GuessStatus.Add((letter, LetterStatus.Incorrect));
                    }
                }
            }
        }

        /// <summary>
        /// Method <c>IsWinningGuess</c> Checks if the guess is the correct answer, thus winning the game.
        /// </summary>
        public bool IsWinningGuess(string answer)
        {
            if (!string.IsNullOrEmpty(Word)) {
                if (Word.Equals(answer)) return true;
                return false;
            }
            return false;
        }

    }
}