using IronSoft.OldPhonePad.Exceptions;

namespace IronSoft.OldPhonePad.Contracts;

/// <summary>
///     Provides functionality to turn input of OldPhonePad into the correct output.
/// </summary>
public interface IOldPhonePadDecoder
{
    /// <summary>
    ///     Turn any input of OldPhonePad into the correct output.
    /// </summary>
    /// <param name="input">The input to OldPhonePad.</param>
    /// <returns>
    ///     A corrected output.
    /// </returns>
    /// <exception cref="InvalidInputException">Thrown when the input is invalid.</exception>
    string Decode(string input);
}