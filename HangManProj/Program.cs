namespace HangManProj;

internal class Program
{
    private static void Main(string[] args)
    {
        var correctWord = "Hangman";
        var guessCount = 0;
        var charsDisplayed = "";
        var playingGame = true;
        foreach (var letter in correctWord) charsDisplayed += "_ ";


        while (playingGame) PlayGame();

        void PlayGame()
        {
            correctWord = correctWord.ToLower();

            Console.WriteLine("\n");
            Console.WriteLine(charsDisplayed);
            Console.Write("Pick a letter: ");
            var guessedLetter = char.ToLower(Console.ReadLine()[0]);
            var newCharsDisplayed = "";

            for (var i = 0; i < correctWord.Length; i++)
                if (correctWord[i] == guessedLetter)
                    newCharsDisplayed += guessedLetter + " ";
                else
                    newCharsDisplayed += charsDisplayed[2 * i] + " ";

            charsDisplayed = newCharsDisplayed;


            if (!charsDisplayed.Contains("_") && guessCount <= 5)
            {
                Console.WriteLine("You found the word! Well done.");
                playingGame = false;
            }
            else if (correctWord.Contains($"{guessedLetter}") && guessCount <= 6)
            {
                Console.WriteLine("That letter is in the word!");
                Console.WriteLine($"You have {7 - guessCount} guesses remaining.");
            }
            else if (!correctWord.Contains($"{guessedLetter}") && guessCount <= 5)
            {
                Console.WriteLine("That letter is not in the word. Try again!");
                guessCount++;
                Console.WriteLine($"You have {7 - guessCount} guesses remaining.");
            }
            else
            {
                Console.WriteLine("You ran out of guesses, a man died because of you.");
                playingGame = false;
            };
        }
    }
}