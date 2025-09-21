using System;
using System.Globalization;

/// <summary>
/// Основной класс программы для демонстрации работы с валютами
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Конвертер валют");
        Console.WriteLine();

        // Установка курсов валют (пользовательский ввод)
        SetExchangeRates();

        // Создание валют
        CurrencyUSD usd = new CurrencyUSD(100m);
        CurrencyEUR eur = new CurrencyEUR(85m);
        CurrencyRUB rub = new CurrencyRUB(5000m);

        Console.WriteLine("\nИсходные валюты:");
        Console.WriteLine($"USD: {usd}");
        Console.WriteLine($"EUR: {eur}");
        Console.WriteLine($"RUB: {rub}");
        Console.WriteLine();

        // Демонстрация неявных преобразований
        Console.WriteLine("Неявные преобразования:");
        CurrencyRUB rubFromUsd = usd; // USD -> RUB (неявное)
        CurrencyEUR eurFromUsd = usd; // USD -> EUR (неявное)
        CurrencyUSD usdFromEur = eur; // EUR -> USD (неявное)
        CurrencyRUB rubFromEur = eur; // EUR -> RUB (неявное)
        CurrencyUSD usdFromRub = rub; // RUB -> USD (неявное)
        CurrencyEUR eurFromRub = rub; // RUB -> EUR (неявное)

        Console.WriteLine($"{usd} -> RUB: {rubFromUsd}");
        Console.WriteLine($"{usd} -> EUR: {eurFromUsd}");
        Console.WriteLine($"{eur} -> USD: {usdFromEur}");
        Console.WriteLine($"{eur} -> RUB: {rubFromEur}");
        Console.WriteLine($"{rub} -> USD: {usdFromRub}");
        Console.WriteLine($"{rub} -> EUR: {eurFromRub}");
        Console.WriteLine();

        // Демонстрация преобразований с десятичными дробями
        Console.WriteLine("Преобразования с десятичными дробями:");
        CurrencyUSD usdFraction = new CurrencyUSD(123.45m);
        CurrencyEUR eurFraction = new CurrencyEUR(67.89m);
        CurrencyRUB rubFraction = new CurrencyRUB(12345.67m);

        Console.WriteLine($"{usdFraction} -> RUB: {(CurrencyRUB)usdFraction}");
        Console.WriteLine($"{eurFraction} -> USD: {(CurrencyUSD)eurFraction}");
        Console.WriteLine($"{rubFraction} -> EUR: {(CurrencyEUR)rubFraction}");
    }

    /// <summary>
    /// Установка обменных курсов от пользователя
    /// </summary>
    private static void SetExchangeRates()
    {
        Console.WriteLine("Введите текущие курсы валют:");

        Console.Write("USD -> RUB: ");
        CurrencyUSD.ExchangeRateToRUB = ReadDecimal();
        CurrencyRUB.ExchangeRateToUSD = 1 / CurrencyUSD.ExchangeRateToRUB;

        Console.Write("USD -> EUR: ");
        CurrencyUSD.ExchangeRateToEUR = ReadDecimal();
        CurrencyEUR.ExchangeRateToUSD = 1 / CurrencyUSD.ExchangeRateToEUR;

        Console.Write("EUR -> RUB: ");
        CurrencyEUR.ExchangeRateToRUB = ReadDecimal();
        CurrencyRUB.ExchangeRateToEUR = 1 / CurrencyEUR.ExchangeRateToRUB;

        Console.WriteLine("\nУстановленные курсы:");
        Console.WriteLine($"1 USD = {CurrencyUSD.ExchangeRateToRUB} RUB");
        Console.WriteLine($"1 USD = {CurrencyUSD.ExchangeRateToEUR} EUR");
        Console.WriteLine($"1 EUR = {CurrencyEUR.ExchangeRateToRUB} RUB");
        Console.WriteLine($"1 RUB = {CurrencyRUB.ExchangeRateToUSD:F6} USD");
        Console.WriteLine($"1 RUB = {CurrencyRUB.ExchangeRateToEUR:F6} EUR");
        Console.WriteLine($"1 EUR = {CurrencyEUR.ExchangeRateToUSD:F6} USD");
    }

    /// <summary>
    /// Чтение десятичного числа с консоли
    /// </summary>
    /// <returns>Десятичное число decimal</returns>
    private static decimal ReadDecimal()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal result))
            {
                return result;
            }
            else if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }
            else
            {
                Console.Write("Неверный формат. Введите число с запятой (например: 91,25): ");
            }
        }
    }
}