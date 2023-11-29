namespace HangManProj;

internal class Program
{
    private static void Main(string[] args)
    {
        
        var playingGame = true;
        var correctWord = GenerateWord(); ;
        var guessCount = 0;
        var charsDisplayed = "";
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
                Console.WriteLine($"Congratulations! The word was {correctWord}. Well done.");
                Console.WriteLine("The hanging man lives and is set free. Sometimes I question our judicial system...");
                PlayAgain();
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
                PlayAgain();
            }
        }


        // Her må charsDisplayed resettes også. 
        void PlayAgain()
        {
            Console.WriteLine("Do you want to play again? y/n");
            string userInput = Console.ReadLine();
            if (userInput == "n")
            {
                Console.WriteLine("Thanks for playing!");
                playingGame = false;
            }
        }

        string GenerateWord()
        {
            string[] wordList =
            {
                "community", "accumulation", "matter", "pleasant", "tactic", "dribble", "result", "mathematics",
                "primary", "bucket", "scenario", "academy", "timber", "packet", "mourning", "voucher",
                "qualified",
                "suntan", "effect", "fountain", "academy"
            };
            Random randomWord = new Random();
            int index = randomWord.Next(wordList.Length);
            return wordList[index];
        }
    }
}