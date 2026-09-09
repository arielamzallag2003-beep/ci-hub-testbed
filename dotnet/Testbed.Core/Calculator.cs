namespace Testbed.Core;

public static class Calculator
{
    public static int Add(int a, int b) => a + b;

    public static int Subtract(int a, int b) => a - b;

    public static double Divide(int a, int b) =>
        b == 0 ? throw new DivideByZeroException() : (double)a / b;
}
