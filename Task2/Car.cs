using System;

/// <summary>
/// Класс, представляющий автомобиль
/// </summary>
public class Car : IEquatable<Car>
{
    /// <summary>
    /// Название автомобиля
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Тип двигателя
    /// </summary>
    public string Engine { get; set; }

    /// <summary>
    /// Максимальная скорость
    /// </summary>
    public int MaxSpeed { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса Car
    /// </summary>
    /// <param name="name">Название автомобиля</param>
    /// <param name="engine">Тип двигателя</param>
    /// <param name="maxSpeed">Максимальная скорость</param>
    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    /// <summary>
    /// Переопределение метода ToString
    /// </summary>
    /// <returns>Название автомобиля</returns>
    public override string ToString()
    {
        return Name;
    }

    /// <summary>
    /// Сравнение объектов Car на равенство
    /// </summary>
    /// <param name="other">Другой объект Car для сравнения</param>
    /// <returns>True если объекты равны</returns>
    public bool Equals(Car other)
    {
        if (other is null) return false;
        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }

    /// <summary>
    /// Переопределение метода Equals для сравнения с любым объектом
    /// </summary>
    /// <param name="obj">Объект для сравнения</param>
    /// <returns>True если объекты равны</returns>
    public override bool Equals(object obj)
    {
        return Equals(obj as Car);
    }

    /// <summary>
    /// Переопределение метода GetHashCode
    /// </summary>
    /// <returns>Хэш-код объекта</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Engine, MaxSpeed);
    }

    /// <summary>
    /// Оператор равенства
    /// </summary>
    /// <param name="car1">Первый автомобиль</param>
    /// <param name="car2">Второй автомобиль</param>
    /// <returns>True если автомобили равны</returns>
    public static bool operator ==(Car car1, Car car2)
    {
        if (ReferenceEquals(car1, car2)) return true;
        if (car1 is null || car2 is null) return false;
        return car1.Equals(car2);
    }

    /// <summary>
    /// Оператор неравенства
    /// </summary>
    /// <param name="car1">Первый автомобиль</param>
    /// <param name="car2">Второй автомобиль</param>
    /// <returns>True если автомобили не равны</returns>
    public static bool operator !=(Car car1, Car car2)
    {
        return !(car1 == car2);
    }
}