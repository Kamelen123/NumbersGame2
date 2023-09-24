using System.Transactions;

namespace NumbersGame2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            playagain:
            Console.Clear();
            Console.WriteLine("Welcome to the guessing game, please guess a number between 1 and 20...");
            bool numbersGame = true;
            int guesses = 0;
            int limit = 5;
            int randomNumber = randomNumberG();
            int guess = 0;
            while (guess != randomNumber && numbersGame)
            {
                if (guesses < limit)
                {
                    try
                    {
                        Console.Write("Enter guess: ");
                        guess = Convert.ToInt32(Console.ReadLine());
                        guesses++;
                        if (guess < randomNumber)
                        {
                            Console.WriteLine(guess + " is to low!");
                            Console.WriteLine("You now have " + (limit - guesses) + " guesses left...");
                        }
                        else if (guess > randomNumber)
                        {
                            Console.WriteLine(guess + " is to high!");
                            Console.WriteLine("You now have " + (limit - guesses) + " guesses left...");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press anykey to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    numbersGame = false;
                }
            }
            if (numbersGame == false)
            {
                Console.WriteLine("Out of guesses... You Lose!");
            }
            else
            {
                Console.WriteLine("Congratulations! You Win!");
                enterOption:
                Console.Write("Do you wanna play again? y/n: ");
                string playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    goto playagain;
                }
                else if (playAgain == "n")
                {
                    numbersGame = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                    goto enterOption;
                }
            }
            Console.WriteLine("Thanks for playing!");
        }
        static int randomNumberG()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 20);
            return randomNumber;
        }
    }
}