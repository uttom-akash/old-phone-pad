using IronSoft.OldPhonePad;
using IronSoft.OldPhonePad.Contracts;
using IronSoft.OldPhonePad.Exceptions;
using Xunit;

namespace IronSoft.Tests;

public class OldPhonePadDecoderTests
{
    private readonly IOldPhonePadDecoder _decoder;

    public OldPhonePadDecoderTests()
    {
        _decoder = new OldPhonePadDecoder();
    }

    [Fact]
    public void Decode_SingleKeyPress_ReturnSingleLetter()
    {
        Assert.Equal("D", _decoder.Decode("3#"));
    }

    [Fact]
    public void Decode_BackspacePress_DeletePreviousLetter()
    {
        Assert.Equal("B", _decoder.Decode("227*#"));
    }

    [Fact]
    public void Decode_MultipleBackspacePress_DeleteMultipleLetters()
    {
        Assert.Equal("", _decoder.Decode("227**#"));
    }

    [Fact]
    public void Decode_BackSpacePressAfterPause_DeletePreviousLetter()
    {
        Assert.Equal("", _decoder.Decode("222 *#"));
    }

    [Fact]
    public void Decode_BackSpacePressAfterSpace_DeleteSpace()
    {
        Assert.Equal("", _decoder.Decode("00 *#"));
    }

    [Fact]
    public void Decode_OnePauseBetweenSameButtonPresses_ReturnsTwoLetters()
    {
        // LL is parsed from 555 555
        Assert.Equal("HELLO", _decoder.Decode("4433555 555666#"));
    }

    [Fact]
    public void Decode_RepeatedSameButtonPressWithPause_ReturnsMultipleLetters()
    {
        Assert.Equal("CAB", _decoder.Decode("222 2 22#"));
    }

    [Fact]
    public void Decode_ComplexInput_ReturnsCorrectResult()
    {
        Assert.Equal("TURING", _decoder.Decode("8 88777444666*664#"));
    }

    [Fact]
    public void Decode_EmptyInput_ThrowsException()
    {
        Assert.Throws<InvalidInputException>(() => _decoder.Decode(""));
    }

    [Fact]
    public void Decode_InputWithoutHash_ThrowsException()
    {
        Assert.Throws<InvalidInputException>(() => _decoder.Decode("33"));
    }

    [Fact]
    public void Decode_InvalidLetter_ThrowsException()
    {
        Assert.Throws<InvalidInputException>(() => _decoder.Decode("33A#"));
    }
}