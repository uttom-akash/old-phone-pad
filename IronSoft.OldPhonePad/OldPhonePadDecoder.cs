using System.Text;
using IronSoft.OldPhonePad.Contracts;
using IronSoft.OldPhonePad.Exceptions;

namespace IronSoft.OldPhonePad;

public class OldPhonePadDecoder : IOldPhonePadDecoder
{
    public string Decode(string input)
    {
        ValidateInput(input);

        var result = new StringBuilder();

        var index = 0;

        while (!IsEndOfInput(input, index))
        {
            index = SkipWhiteSpaces(input, index);

            index = ApplyBackSpaces(input, index, result);

            index = ParseAndAppendLetter(input, index, result);
        }

        return result.ToString();
    }

    private static bool IsEndOfInput(string input, int index)
    {
        return input[index] == Constants.Send;
    }

    private static void ValidateInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            InvalidInputException.Throw("Input should not be null or empty.");

        if (input[^1] != Constants.Send)
            InvalidInputException.Throw($"Input must end with '{Constants.Send}'.");

        var invalidLetters = input
            .Where(c => !Constants.AllowedLetters.Contains(c))
            .Distinct()
            .ToList();

        if (invalidLetters.Count != 0)
            InvalidInputException.Throw($"Input contains invalid letters: {string.Join(", ", invalidLetters)}");
    }

    private static int SkipWhiteSpaces(string input, int index)
    {
        while (!IsEndOfInput(input, index) && input[index] == Constants.Whitespace) index++;

        return index;
    }

    private static int ApplyBackSpaces(string input, int index, StringBuilder result)
    {
        while (!IsEndOfInput(input, index) && input[index] == Constants.BackSpace)
        {
            if (result.Length > 0) result.Length--;

            index++;
        }

        return index;
    }

    /// <summary>
    ///     Consume the consecutive same button number without pause,
    ///     cycle through the letter on the button,
    ///     and append the letter to result reference.
    /// </summary>
    /// <param name="input">Given old phone pad input</param>
    /// <param name="index">Current index</param>
    /// <param name="result">Current result reference</param>
    /// <returns> next index to decode from.</returns>
    private static int ParseAndAppendLetter(string input, int index, StringBuilder result)
    {
        var startIndex = index;

        while (!IsEndOfInput(input, index) && input[startIndex] == input[index]) index++;

        if (startIndex == index) return index;

        var clickCounts = index - startIndex;
        var buttonNumber = input[startIndex];
        var letters = Constants.Keypad[buttonNumber];
        var letterIndex = (clickCounts - 1) % letters.Length; // clickCounts - 1 to make it zero indexed 
        result.Append(letters[letterIndex]);

        return index;
    }
}