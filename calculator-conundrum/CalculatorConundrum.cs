using System;
using System.Collections.Generic;

public static class SimpleCalculator
{
    private const string SUM_OPERATOR = "+";
    private const string MULTIPLICATION_OPERATOR = "*";
    private const string DIVISION_OPERATOR = "/";
    private const int DIVISION_BY_ZERO = 0;

    public static string Calculate(int operand1, int operand2, string operation)
    {
        string result = string.Empty;

        if (operation is null)
        {
            throw new ArgumentNullException();
        }

        if (operation == string.Empty)
        {
            throw new ArgumentException();
        }

        if (!new List<string>() { SUM_OPERATOR, MULTIPLICATION_OPERATOR, DIVISION_OPERATOR }.Contains(operation))
        {
            throw new ArgumentOutOfRangeException();
        }

        switch (operation)
        {
            case SUM_OPERATOR:
                result = BuildOperationResultAsString($"{operand1} {SUM_OPERATOR} {operand2}", operand1 + operand2);
                break;
            case MULTIPLICATION_OPERATOR:
                result = BuildOperationResultAsString($"{operand1} {MULTIPLICATION_OPERATOR} {operand2}", operand1 * operand2);
                break;
            case DIVISION_OPERATOR:
                if (operand2 == DIVISION_BY_ZERO)
                {
                    return "Division by zero is not allowed.";
                }

                result = BuildOperationResultAsString($"{operand1} {DIVISION_OPERATOR} {operand2}", operand1 / operand2);
                break;
        }

        return result;
    }

    private static string BuildOperationResultAsString(string operation, int result) => $"{operation} = {result}";
}
