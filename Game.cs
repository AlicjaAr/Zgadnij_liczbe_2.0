using System;
using System.Diagnostics;
using Zgadnij_liczbe;

public abstract class Game
{
    protected int hiddenNumber;
    protected int attempts;
    protected int min;
    protected int max;
    protected Difficulty difficulty;
    protected bool isNewGamePlus;
    protected int maxAttempts;
    protected Stopwatch timer;
    protected HallOfFame hallOfFame;

    public Game(int min, int max, HallOfFame hallOfFame, int maxAttempts, Difficulty difficulty, bool isNewGamePlus)
    {
        this.min = min;
        this.max = max;
        this.maxAttempts = maxAttempts;
        this.difficulty = difficulty;
        this.isNewGamePlus = isNewGamePlus;
        this.hallOfFame = hallOfFame;

        attempts = 0;

        timer = new Stopwatch();
    }

    protected void GenerateNumber()
    {
        Random random = new Random();

        hiddenNumber = random.Next(min, max + 1);
    }

    public abstract void StartGame();
}