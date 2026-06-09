using System;
using System.Collections.Generic;

public static class Messages
{
    private static Random random = new Random();

    private static List<string> tooLowEN = new List<string>
    {
        "Too low!",
        "Number is too small :(",
        "Try higher!",
        "Go up!",
        "Increase it!"
    };

    private static List<string> tooHighEN = new List<string>
    {
        "Too high!",
        "Number is too big :(",
        "Try lower!",
        "Go down!",
        "Slow down!"
    };

    public static string GetTooLow()
    {
        return tooLowEN[random.Next(tooLowEN.Count)];
    }

    public static string GetTooHigh()
    {
        return tooHighEN[random.Next(tooHighEN.Count)];
    }
}