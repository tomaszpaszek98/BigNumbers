using BigNumbers.ArithmeticOperations;
using TddXt.AnyRoot.Collections;

namespace BigNumbersTests.ArithmeticOperations;

public class ColumnAdditionStrategyTests
{
     [Test]
    public void ShouldReturnCorrectSumWhenBothNumbersHaveSameLength()
    {
        // GIVEN
        var first = new List<byte> { 1, 2, 3 };
        var second = new List<byte> { 4, 5, 6 };
        var strategy = new ColumnAdditionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 5, 7, 9 });
    }

    [Test]
    public void ShouldReturnCorrectSumWhenNumbersHaveDifferentLengths()
    {
        // GIVEN
        var first = new List<byte> { 9, 9, 9, 9 };
        var second = new List<byte> { 1 };
        var strategy = new ColumnAdditionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 1, 0, 0, 0, 0 });
    }

    [Test]
    public void ShouldReturnCorrectSumWhenThereIsCarryOver()
    {
        // GIVEN
        var first = new List<byte> { 5, 9, 9 };
        var second = new List<byte> { 7, 2, 2 };
        var strategy = new ColumnAdditionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 1, 3, 2, 1 });
    }

    [Test]
    public void ShouldReturnSameNumberWhenAddingZero()
    {
        // GIVEN
        var first = Any.List<byte>().Select(b => (byte)(b % 10)).ToList();
        var second = new List<byte> { 0 };
        var strategy = new ColumnAdditionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(first);
    }

    [Test]
    public void ShouldReturnZeroWhenAddingTwoZeros()
    {
        // GIVEN
        var first = new List<byte> { 0 };
        var second = new List<byte> { 0 };
        var strategy = new ColumnAdditionStrategy();

        // WHEN
        var result = strategy.Count(first, second);

        // THEN
        result.Should().BeEquivalentTo(new List<byte> { 0 });
    }
}