using System;
using System.Collections.Generic;

public static class Messages
{
    public static Language CurrentLanguage { get; set; } = Language.EN;

    private static readonly Dictionary<string, (string EN, string PL)> Texts =
        new Dictionary<string, (string EN, string PL)>
    {
        // MENU
        { "NewGame", ("New Game", "Nowa Gra") },
        { "Settings", ("Settings", "Ustawienia") },
        { "Exit", ("Exit", "Wyjście") },
        { "HallOfFame", ("Hall Of Fame", "Tablica Wyników") },

        // DIFFICULTY
        { "Easy", ("Easy", "Łatwy") },
        { "Medium", ("Medium", "Średni") },
        { "Hard", ("Hard", "Trudny") },

        // GAME TEXT
        { "TooLow", ("Too low!", "Za mało!") },
        { "TooHigh", ("Too high!", "Za dużo!") },
        { "InvalidInput", ("Invalid input!", "Niepoprawna wartość!") },
        { "Win", ("You won!", "Wygrałeś!") },
        { "Lose", ("You lost!", "Przegrałeś!") },
        { "EnterName", ("Enter your name:", "Podaj imię:") },
        { "HiddenChanged", ("Hidden number changed!", "Ukryta liczba została zmieniona!") },
        { "AttemptsLeft", ("Attempts:", "Próby:") }
    };

    public static string Get(string key)
{
    if (!Texts.ContainsKey(key))
        return key;

    return CurrentLanguage == Language.PL
        ? Texts[key].PL
        : Texts[key].EN;
}
