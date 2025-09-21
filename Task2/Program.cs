using System;

/// <summary>
/// Основной класс программы для демонстрации работы с автомобилями
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Демонстрация работы с автомобилями");
        Console.WriteLine();

        // Создание автомобилей
        Car car1 = new Car("Toyota Camry", "V6 3.5L", 240);
        Car car2 = new Car("BMW X5", "V8 4.4L", 250);
        Car car3 = new Car("Mercedes E-Class", "Inline-6 3.0L", 230);
        Car car4 = new Car("Toyota Camry", "V6 3.5L", 240); // Копия car1

        Console.WriteLine("Созданные автомобили:");
        Console.WriteLine($"car1: {car1}");
        Console.WriteLine($"car2: {car2}");
        Console.WriteLine($"car3: {car3}");
        Console.WriteLine($"car4: {car4} (копия car1)");
        Console.WriteLine();

        // Демонстрация метода ToString
        Console.WriteLine("Метод ToString():");
        Console.WriteLine($"car1.ToString() = {car1.ToString()}");
        Console.WriteLine($"car2.ToString() = {car2.ToString()}");
        Console.WriteLine();

        // Демонстрация сравнения автомобилей
        Console.WriteLine("Сравнение автомобилей:");
        Console.WriteLine($"car1 == car2: {car1 == car2}");
        Console.WriteLine($"car1 == car4: {car1 == car4}");
        Console.WriteLine($"car1 != car3: {car1 != car3}");
        Console.WriteLine($"car1.Equals(car2): {car1.Equals(car2)}");
        Console.WriteLine($"car1.Equals(car4): {car1.Equals(car4)}");
        Console.WriteLine();

        // Демонстрация работы с каталогом
        Console.WriteLine("Работа с каталогом автомобилей:");
        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        Console.WriteLine($"В каталоге {catalog.Count} автомобиля:");
        for (int i = 0; i < catalog.Count; i++)
        {
            Console.WriteLine($"Автомобиль {i}: {catalog[i]}");
        }
        Console.WriteLine();

        // Демонстрация обработки исключений
        try
        {
            Console.WriteLine("Попытка доступа к несуществующему индексу:");
            Console.WriteLine(catalog[5]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}