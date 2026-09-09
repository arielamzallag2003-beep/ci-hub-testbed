using Testbed.Core;
using Xunit;

namespace Testbed.Tests;

public class CalculatorTests
{
    [Fact]
    public void AddsCorrectly() => Assert.Equal(7, Calculator.Add(3, 4));

    [Fact]
    public void SubtractsCorrectly() => Assert.Equal(1, Calculator.Subtract(4, 3));

    [Fact]
    public void ThrowsOnDivideByZero() =>
        Assert.Throws<DivideByZeroException>(() => Calculator.Divide(1, 0));

    // Fixed: 10 / 4 really is 2.5.
    [Fact]
    public void DividesCorrectly() =>
        Assert.Equal(2.5, Calculator.Divide(10, 4));
}
