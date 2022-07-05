using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount currencyA, CurrencyAmount currencyB) => CheckEqualityAndComparisonOperators(currencyA, currencyB, (a, b) => a == b);

    public static bool operator !=(CurrencyAmount currencyA, CurrencyAmount currencyB) => CheckEqualityAndComparisonOperators(currencyA, currencyB, (a, b) => a != b);

    // TODO: implement comparison operators
    public static bool operator >(CurrencyAmount currencyA, CurrencyAmount currencyB) => CheckEqualityAndComparisonOperators(currencyA, currencyB, (a, b) => a > b);

    public static bool operator <(CurrencyAmount currencyA, CurrencyAmount currencyB) => CheckEqualityAndComparisonOperators(currencyA, currencyB, (a, b) => a < b);

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount currencyA, CurrencyAmount currencyB) => currencyA.currency.Equals(currencyB.currency) ?
                                                                                                        DoArithmetics(currencyA, currencyB.amount, (a, b) => a + b) : throw new ArgumentException();

    public static CurrencyAmount operator -(CurrencyAmount currencyA, CurrencyAmount currencyB) => currencyA.currency.Equals(currencyB.currency) ?
                                                                                            DoArithmetics(currencyA, currencyB.amount, (a, b) => a - b) : throw new ArgumentException();

    public static CurrencyAmount operator *(CurrencyAmount currencyA, decimal factor) => DoArithmetics(currencyA, factor, (a, b) => a * b);

    public static CurrencyAmount operator *(decimal factor, CurrencyAmount currencyA) => DoArithmetics(currencyA, factor, (a, b) => a * b);

    public static CurrencyAmount operator /(CurrencyAmount currencyA, decimal divider) => DoArithmetics(currencyA, divider, (a, b) => a / b);

    // TODO: implement type conversion operators
    public static explicit operator double(CurrencyAmount currencyAmount) => Convert.ToDouble(currencyAmount.amount);

    public static implicit operator decimal(CurrencyAmount currencyAmount) => Convert.ToDecimal(currencyAmount.amount);


    private static bool CheckEqualityAndComparisonOperators(CurrencyAmount currencyA, CurrencyAmount currencyB, Func<decimal, decimal, bool> op)
    {
        return currencyA.currency.Equals(currencyB.currency) ? op(currencyA.amount, currencyB.amount) : throw new ArgumentException();
    }

    private static CurrencyAmount DoArithmetics(CurrencyAmount currency, decimal factor, Func<decimal, decimal, decimal> op)
    {
        return new CurrencyAmount() { amount = op(currency.amount, factor), currency = currency.currency };
    }
}
