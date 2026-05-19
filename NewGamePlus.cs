using System;
using Zgadnij_liczbe;

public class NewGamePlus : Game
{
    private int rerollAfter;

    public NewGamePlus(int min, int max, HallOfFame hallOfFame, int maxAttempts, Difficulty difficulty, bool isNewGamePlus)
        : base(min, max, hallOfFame, maxAttempts, difficulty, true)
    {
    }

    public override void StartGame()
    {
        Random random = new Random();

        rerollAfter = random.Next(6, 9);

        GenerateNumber();

        timer.Start();

        bool isPlaying = true;

        while (isPlaying)
        {
            if (maxAttempts != -1 && attempts >= maxAttempts)
            {
                Console.WriteLine("You lost! No attempts left.");
                isPlaying = false;
                return;
            }

            attempts++;

            Console.WriteLine($"Attempt: {attempts}");

            int guess = int.Parse(Console.ReadLine());

            if (attempts == rerollAfter)
            {
                GenerateNumber();

                Console.WriteLine("Hidden number changed!");
            }

            if (guess == hiddenNumber)
            {
                timer.Stop();

                Console.WriteLine("You won!");
                Console.WriteLine("Enter your name:");

                string playerName = Console.ReadLine();

                Result result = new Result();

                result.PlayerName = playerName;

                result.Attempts = attempts;

                result.TimeInSeconds = (int)timer.Elapsed.TotalSeconds;

                result.Difficulty = difficulty;

                hallOfFame.AddResult(result);

                isPlaying = false;
            }
            else if (guess < hiddenNumber)
            {
                Console.WriteLine(Messages.GetTooLow());
            }
            else
            {
                Console.WriteLine(Messages.GetTooHigh());
            }
        }
    }
}