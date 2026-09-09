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

    // DELIBERATELY WRONG. 10 / 4 is 2.5, not 3.
    // Exists so that CI has a real .NET failure to report.
    [Fact]
    public void DividesCorrectly_FailsOnPurpose() =>
        Assert.Equal(3.0, Calculator.Divide(10, 4));
}
