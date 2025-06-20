using TddXt.AnyRoot.Collections;

namespace BigNumbersTests.ArithmeticOperations;

public class ColumnMultiplicationStrategyTests
{
    [Test]
    public void ShouldReturnCorrectProductWhenBothNumbersHaveSingleDigit()
    {
        // GIVEN
        var first = new List<byte> { 3 };
        var second = new List<byte> { 4 };
        var strategy = new ColumnMultiplicationStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 1, 2 });
    }

    [Test]
    public void ShouldReturnCorrectProductWhenMultiplyingByZero()
    {
        // GIVEN
        var first = Any.List<byte>().Select(b => (byte)(b % 10)).ToList();
        var second = new List<byte> { 0 };
        var strategy = new ColumnMultiplicationStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 0, 0, 0 });
    }

    [Test]
    public void ShouldReturnCorrectProductWhenMultiplyingByOne()
    {
        // GIVEN
        var first = Any.List<byte>().Select(b => (byte)(b % 10)).ToList();
        var second = new List<byte> { 1 };
        var strategy = new ColumnMultiplicationStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(first);
    }

    [Test]
    public void ShouldReturnCorrectProductWhenBothNumbersHaveMultipleDigits()
    {
        // GIVEN
        var first = new List<byte> { 1, 2 };
        var second = new List<byte> { 2, 3 };
        var strategy = new ColumnMultiplicationStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 2, 7, 6});
    }
}