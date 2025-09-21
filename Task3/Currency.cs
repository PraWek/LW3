using System;

/// <summary>
/// Базовый класс для валюты
/// </summary>
public abstract class Currency
{
    /// <summary>
    /// Значение валюты
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса Currency
    /// </summary>
    /// <param name="value">Значение валюты</param>
    protected Currency(decimal value)
    {
        Value = value;
    }

    /// <summary>
    /// Возвращает символ валюты
    /// </summary>
    /// <returns>Символ валюты string</returns>
    public abstract string GetSymbol();

    /// <summary>
    /// Строковое представление валюты
    /// </summary>
    /// <returns>Строка с значением и символом валюты</returns>
    public override string ToString()
    {
        return $"{Value:F2} {GetSymbol()}";
    }
}

/// <summary>
/// Класс для долларов США
/// </summary>
public class CurrencyUSD : Currency
{
    /// <summary>
    /// Курс USD к RUB
    /// </summary>
    public static decimal ExchangeRateToRUB { get; set; }

    /// <summary>
    /// Курс USD к EUR
    /// </summary>
    public static decimal ExchangeRateToEUR { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса CurrencyUSD
    /// </summary>
    /// <param name="value">Значение в долларах</param>
    public CurrencyUSD(decimal value) : base(value) { }

    /// <summary>
    /// Возвращает символ валюты USD
    /// </summary>
    /// <returns>Символ USD string</returns>
    public override string GetSymbol()
    {
        return "USD";
    }

    /// <summary>
    /// Неявное преобразование USD в RUB
    /// </summary>
    /// <param name="usd">Исходная валюта в USD</param>
    /// <returns>Преобразованная валюта в RUB</returns>
    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        return new CurrencyRUB(usd.Value * ExchangeRateToRUB);
    }

    /// <summary>
    /// Неявное преобразование USD в EUR
    /// </summary>
    /// <param name="usd">Исходная валюта в USD</param>
    /// <returns>Преобразованная валюта в EUR</returns>
    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        return new CurrencyEUR(usd.Value * ExchangeRateToEUR);
    }
}

/// <summary>
/// Класс для евро
/// </summary>
public class CurrencyEUR : Currency
{
    /// <summary>
    /// Курс EUR к USD
    /// </summary>
    public static decimal ExchangeRateToUSD { get; set; }

    /// <summary>
    /// Курс EUR к RUB
    /// </summary>
    public static decimal ExchangeRateToRUB { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса CurrencyEUR
    /// </summary>
    /// <param name="value">Значение в евро</param>
    public CurrencyEUR(decimal value) : base(value) { }

    /// <summary>
    /// Возвращает символ валюты EUR
    /// </summary>
    /// <returns>Символ EUR string</returns>
    public override string GetSymbol()
    {
        return "EUR";
    }

    /// <summary>
    /// Неявное преобразование EUR в USD
    /// </summary>
    /// <param name="eur">Исходная валюта в EUR</param>
    /// <returns>Преобразованная валюта в USD</returns>
    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        return new CurrencyUSD(eur.Value * ExchangeRateToUSD);
    }

    /// <summary>
    /// Неявное преобразование EUR в RUB
    /// </summary>
    /// <param name="eur">Исходная валюта в EUR</param>
    /// <returns>Преобразованная валюта в RUB</returns>
    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        return new CurrencyRUB(eur.Value * ExchangeRateToRUB);
    }
}

/// <summary>
/// Класс для российских рублей
/// </summary>
public class CurrencyRUB : Currency
{
    /// <summary>
    /// Курс RUB к USD
    /// </summary>
    public static decimal ExchangeRateToUSD { get; set; }

    /// <summary>
    /// Курс RUB к EUR
    /// </summary>
    public static decimal ExchangeRateToEUR { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса CurrencyRUB
    /// </summary>
    /// <param name="value">Значение в рублях</param>
    public CurrencyRUB(decimal value) : base(value) { }

    /// <summary>
    /// Возвращает символ валюты RUB
    /// </summary>
    /// <returns>Символ RUB string</returns>
    public override string GetSymbol()
    {
        return "RUB";
    }

    /// <summary>
    /// Неявное преобразование RUB в USD
    /// </summary>
    /// <param name="rub">Исходная валюта в RUB</param>
    /// <returns>Преобразованная валюта в USD</returns>
    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        return new CurrencyUSD(rub.Value * ExchangeRateToUSD);
    }

    /// <summary>
    /// Неявное преобразование RUB в EUR
    /// </summary>
    /// <param name="rub">Исходная валюта в RUB</param>
    /// <returns>Преобразованная валюта в EUR</returns>
    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        return new CurrencyEUR(rub.Value * ExchangeRateToEUR);
    }
}