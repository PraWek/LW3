using System;

/// <summary>
/// Класс-каталог автомобилей
/// </summary>
public class CarsCatalog
{
    private List<Car> cars;

    /// <summary>
    /// Инициализирует новый экземпляр класса CarsCatalog
    /// </summary>
    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    /// <summary>
    /// Добавляет автомобиль в каталог
    /// </summary>
    /// <param name="car">Автомобиль для добавления</param>
    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    /// <summary>
    /// Индексатор для доступа к автомобилям в каталоге
    /// </summary>
    /// <param name="index">Индекс автомобиля в коллекции</param>
    /// <returns>Строка с названием машины и типом двигателя</returns>
    /// <exception cref="IndexOutOfRangeException">Выбрасывается при неверном индексе</exception>
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count)
                throw new IndexOutOfRangeException("Индекс находится вне диапазона коллекции");

            return $"{cars[index].Name} - {cars[index].Engine}";
        }
    }

    /// <summary>
    /// Количество автомобилей в каталоге
    /// </summary>
    public int Count => cars.Count;
}