using BigNumbers.ArithmeticOperations;
using TddXt.AnyRoot.Collections;

namespace BigNumbersTests.ArithmeticOperations;

public class ColumnSubtractionStrategyTests
{
    [Test]
    public void ShouldReturnCorrectDifferenceWhenBothNumbersHaveSameLength()
    {
        // GIVEN
        var first = new List<byte> { 9, 8, 7 };
        var second = new List<byte> { 4, 5, 6 };
        var strategy = new ColumnSubtractionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 5, 3, 1 });
    }

    [Test]
    public void ShouldReturnCorrectDifferenceWhenNumbersHaveDifferentLengths()
    {
        // GIVEN
        var first = new List<byte> { 1, 0, 0, 0 };
        var second = new List<byte> { 1 };
        var strategy = new ColumnSubtractionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 0, 9, 9, 9 });
    }

    [Test]
    public void ShouldReturnCorrectDifferenceWhenThereIsBorrow()
    {
        // GIVEN
        var first = new List<byte> { 2, 0, 0 };
        var second = new List<byte> { 1, 9, 9 };
        var strategy = new ColumnSubtractionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 0, 0, 1 });
    }

    [Test]
    public void ShouldReturnSameNumberWhenSubtractingZero()
    {
        // GIVEN
        var first = Any.List<byte>().Select(b => (byte)(b % 10)).ToList();
        var second = new List<byte> { 0 };
        var strategy = new ColumnSubtractionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(first);
    }

    [Test]
    public void ShouldReturnZeroWhenSubtractingSameNumbers()
    {
        // GIVEN
        var first = Any.List<byte>().Select(b => (byte)(b % 10)).ToList();
        var second = new List<byte>(first);
        var strategy = new ColumnSubtractionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 0, 0, 0 });
    }
}