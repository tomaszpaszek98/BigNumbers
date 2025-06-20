using BigNumbers.Exceptions;
using BigNumbers.Extensions;
using TddXt.AnyRoot.Collections;

namespace BigNumbersTests.Extensions;

public class StringExtensionsTests
{
    [Test]
    public void ShouldReturnBigNumberWithCorrectDigitsWhenStringContainsOnlyDigits()
    {
        // GIVEN
        var digits = Any.List<byte>().Select(b => (b % 10).ToString()).ToArray();
        var value = string.Concat(digits);

        // WHEN
        var result = value.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(digits.Select(byte.Parse));
    }

    [Test]
    public void ShouldThrowUnsupportedStringFormatWhenStringContainsNonDigitCharacters()
    {
        // GIVEN
        var digits = Any.List<byte>().Select(b => (b % 10).ToString()).ToArray();
        var value = string.Concat(digits) + "a";

        // WHEN
        Action act = () => value.ToBigNumber();

        // THEN
        act.Should().Throw<UnsupportedStringFormat>()
            .WithMessage($"*{value}*");
    }

    [Test]
    public void ShouldThrowUnsupportedStringFormatWhenStringIsEmpty()
    {
        // GIVEN
        var value = string.Empty;

        // WHEN
        Action act = () => value.ToBigNumber();

        // THEN
        act.Should().Throw<UnsupportedStringFormat>()
            .WithMessage("*");
    }
}