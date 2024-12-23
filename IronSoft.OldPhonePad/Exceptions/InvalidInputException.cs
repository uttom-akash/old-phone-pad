namespace IronSoft.OldPhonePad.Exceptions;

public class InvalidInputException : Exception
{
    public InvalidInputException(string message)
        : base(message)
    {
    }

    public static void Throw(string message)
    {
        throw new InvalidInputException(message);
    }
}