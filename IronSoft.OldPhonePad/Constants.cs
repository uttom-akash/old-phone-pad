namespace IronSoft.OldPhonePad;

public static class Constants
{
    public const char Send = '#'; // End of input

    public const char Whitespace = ' ';

    public const char BackSpace = '*';

    public const string AllowedLetters = "0123456789*# ";

    public static readonly Dictionary<char, string> Keypad = new()
    {
        { '1', "&'(" },
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', " " }
    };
}