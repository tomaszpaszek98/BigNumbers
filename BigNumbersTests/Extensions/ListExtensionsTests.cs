using BigNumbers.Exceptions;
using BigNumbers.Extensions;
using TddXt.AnyRoot.Collections;

namespace BigNumbersTests.Extensions;

public class ListExtensionsTests
{
    [Test]
    public void ShouldReturnBigNumberWithSameDigitsWhenListIsByte()
    {
        // GIVEN
        var bytes = Any.List<byte>();

        // WHEN
        var result = bytes.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(bytes);
    }

    [Test]
    public void ShouldReturnBigNumberWithConvertedDigitsWhenListIsShort()
    {
        // GIVEN
        var shorts = Any.List<short>();

        // WHEN
        var result = shorts.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(shorts.Select(Convert.ToByte));
    }

    [Test]
    public void ShouldReturnBigNumberWithConvertedDigitsWhenListIsInt()
    {
        // GIVEN
        var ints = Any.List<int>();

        // WHEN
        var result = ints.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(ints.Select(Convert.ToByte));
    }

    [Test]
    public void ShouldReturnBigNumberWithConvertedDigitsWhenListIsLong()
    {
        // GIVEN
        var longs = Any.List<long>();

        // WHEN
        var result = longs.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(longs.Select(Convert.ToByte));
    }

    [Test]
    public void ShouldReturnBigNumberWithConvertedDigitsWhenListIsSByte()
    {
        // GIVEN
        var sbytes = Any.List<sbyte>();

        // WHEN
        var result = sbytes.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(sbytes.Select(Convert.ToByte));
    }

    [Test]
    public void ShouldReturnBigNumberWithConvertedDigitsWhenListIsUShort()
    {
        // GIVEN
        var ushorts = Any.List<ushort>();

        // WHEN
        var result = ushorts.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(ushorts.Select(Convert.ToByte));
    }

    [Test]
    public void ShouldReturnBigNumberWithConvertedDigitsWhenListIsUInt()
    {
        // GIVEN
        var uints = Any.List<uint>();

        // WHEN
        var result = uints.ToBigNumber();

        // THEN
        result.Digits.Should().BeEquivalentTo(uints.Select(Convert.ToByte));
    }

    [Test]
    public void ShouldThrowTypeNotSupportedExceptionWhenTypeIsWrong()
    {
        // GIVEN
        var floats = Any.List<float>();

        // WHEN
        Action act = () => floats.ToBigNumber();

        // THEN
        act.Should().Throw<TypeNotSupportedException>();
    }
    
    [Test]
    public void ShouldReturnSingleZeroWhenAllDigitsAreZero()
    {
        // GIVEN
        var digits = new List<byte> { 0, 0, 0, 0 };

        // WHEN
        var result = digits.TrimRedundantZeros();

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 0 });
    }

    [Test]
    public void ShouldReturnOriginalListWhenNoRedundantZeros()
    {
        // GIVEN
        var digits = new List<byte> { 1, 2, 3 };

        // WHEN
        var result = digits.TrimRedundantZeros();

        // THEN
        result.Should().BeSameAs(digits);
    }

    [Test]
    public void ShouldReturnOriginalListWhenZerosAreNotAll()
    {
        // GIVEN
        var digits = new List<byte> { 0, 1, 0 };

        // WHEN
        var result = digits.TrimRedundantZeros();

        // THEN
        result.Should().BeSameAs(digits);
    }

    [Test]
    public void ShouldReturnSingleZeroWhenListIsSingleZero()
    {
        // GIVEN
        var digits = new List<byte> { 0 };

        // WHEN
        var result = digits.TrimRedundantZeros();

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 0 });
    }
}