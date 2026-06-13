using System;
using System.Collections.Generic;

public static class Messages
{
    private static Random random = new Random();

    public static Language CurrentLanguage {get; set} = Language.EN;
    
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

    public static Language CurrentLanguage {get; set} = Language.PL;

    private static List<string> tooLowPL = new List<string>
    {
        "Za mało!",
        "Za mała liczba :(",
        "Spróbuj większej!",
        "Idź w górę!",
        "Zwiększ wartość!"
    };

    private static List<string> tooHighPL = new List<string>
{
        "Za dużo!",
        "Za duża liczba :(",
        "Spróbuj mniejszej!",
        "Idź w dół!",
        "Zwolnij trochę!"
    };

    public static string GetTooLow()
{
    if (CurrentLanguage == Language.PL)
        return tooLowPL[random.Next(tooLowPL.Count)];
    return tooLowEN[random.Next(tooLowEN.Count)];
}

    public static string GetTooHigh()
{
    if (CurrentLanguage == Language.PL)
        return tooHighPL[random.Next(tooHighPL.Count)];
    return tooHighEN[random.Next(tooHighEN.Count)];
}
