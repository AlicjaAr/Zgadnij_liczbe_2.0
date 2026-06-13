using System;
using System.Collections.Generic;
using Zgadnij_liczbe;

public static class Messages
{
    private static Random random = new Random();
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
        { "Difficulty", ("Choose difficulty:", "Wybierz poziom trudności:") },
        { "Easy", ("Easy", "Łatwy") },
        { "Medium", ("Medium", "Średni") },
        { "Hard", ("Hard", "Trudny") },
        { "BetMode", ("Do you want bet mode? (Y/N)", "Czy włączyć tryb zakładu? (Y/N)") },
        { "MaxAtt", ("Enter max attempts:", "Wprowadź ilość prób:") },

        // GAME TEXT
        { "InvalidInput", ("Invalid input!", "Niepoprawna wartość!") },
        { "Win", ("You won!", "Wygrałeś!") },
        { "Lose", ("You lost!", "Przegrałeś!") },
        { "EnterName", ("Enter your name:", "Podaj imię:") },
        { "HiddenChanged", ("Hidden number changed!", "Ukryta liczba została zmieniona!") },
        { "AttemptsLeft", ("Attempts:", "Próby:") },

        //Settings
        { "Changelan", ("Change language", "Zmień język") },
        { "AskBet", ("Ask for bet mode", "Ustawienia Bet mode") },
        { "ClearHOF", ("Clear Hall Of Fame", "Wyczyść Hall Of Fame") },
        { "Back", ("Back", "Powrót") },

    };

    private static readonly Dictionary<Language, List<string>> TooLow =
        new Dictionary<Language, List<string>>
    {
        {
            Language.EN, new List<string>
            {
                "Too low!",
                "Number is too small :(",
                "Try higher!",
                "Go up!",
                "Increase it!"
            }
        },
        {
            Language.PL, new List<string>
            {
                "Za mało!",
                "Za mała liczba :(",
                "Spróbuj większej!",
                "Idź w górę!",
                "Zwiększ wartość!"
            }
        }
    };

    private static readonly Dictionary<Language, List<string>> TooHigh =
        new Dictionary<Language, List<string>>
    {
        {
            Language.EN, new List<string>
            {
                "Too high!",
                "Number is too big :(",
                "Try lower!",
                "Go down!",
                "Slow down!"
            }
        },
        {
            Language.PL, new List<string>
            {
                "Za dużo!",
                "Za duża liczba :(",
                "Spróbuj mniejszej!",
                "Idź w dół!",
                "Zwolnij trochę!"
            }
        }
    };

    public static string Get(string key)
    {
        if (!Texts.ContainsKey(key))
            return key;

        return CurrentLanguage == Language.PL
            ? Texts[key].PL
            : Texts[key].EN;
    }

    public static string GetTooLow()
    {
        var list = TooLow[CurrentLanguage];
        return list[random.Next(list.Count)];
    }

    public static string GetTooHigh()
    {
        var list = TooHigh[CurrentLanguage];
        return list[random.Next(list.Count)];
    }
}
