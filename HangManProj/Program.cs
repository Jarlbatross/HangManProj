namespace HangManProj;

internal class Program
{
    private static void Main(string[] args)
    {
        var correctWord = "Hangman";
        string charsDisplayed = "";
        var playingGame = true;
        foreach (var letter in correctWord) charsDisplayed += "_ ";


        while (playingGame) PlayGame();

        void PlayGame()
        {
            
            correctWord = correctWord.ToLower();

            Console.WriteLine(charsDisplayed);
            Console.Write("Pick a letter: ");
            var guessedLetter = char.ToLower(Console.ReadLine()[0]);
            var newCharsDisplayed = "";

            for (int i = 0; i < correctWord.Length; i++)
                if (correctWord[i] == guessedLetter)
                {
                    newCharsDisplayed += guessedLetter + " ";
                }
                else
                {
                    newCharsDisplayed += (charsDisplayed[2 * i] + " ");
                }

            charsDisplayed = newCharsDisplayed;

        }
    }
}

