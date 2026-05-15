using System;
using Zgadnij_liczbe;

public class NewGamePlus : Game
{
    private int rerollAfter;

    public NewGamePlus(int min, int max, HallOfFame hallOfFame)
        : base(min, max, hallOfFame)
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

                hallOfFame.AddResult(result);

                isPlaying = false;
            }
            else if (guess < hiddenNumber)
            {
                Console.WriteLine("Too low!");
            }
            else
            {
                Console.WriteLine("Too high!");
            }
        }
    }
}