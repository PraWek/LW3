using System;

/// <summary>
/// Структура, представляющая трехмерный вектор
/// </summary>
public struct Vector
{
    /// <summary>
    /// Координата X вектора
    /// </summary>
    public double X;

    /// <summary>
    /// Координата Y вектора
    /// </summary>
    public double Y;

    /// <summary>
    /// Координата Z вектора
    /// </summary>
    public double Z;

    /// <summary>
    /// Инициализирует новый экземпляр структуры Vector
    /// </summary>
    /// <param name="x">Координата X</param>
    /// <param name="y">Координата Y</param>
    /// <param name="z">Координата Z</param>
    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Вычисляет длину вектора от начала координат
    /// </summary>
    /// <returns>Длина вектора double</returns>
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    /// <summary>
    /// Оператор сложения двух векторов
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>Результирующий вектор Vector</returns>
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    /// <summary>
    /// Оператор умножения двух векторов (скалярное произведение)
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>Скалярное произведение double</returns>
    public static double operator *(Vector v1, Vector v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }

    /// <summary>
    /// Оператор умножения вектора на число
    /// </summary>
    /// <param name="vector">Исходный вектор</param>
    /// <param name="scalar">Множитель</param>
    /// <returns>Результирующий вектор Vector</returns>
    public static Vector operator *(Vector vector, double scalar)
    {
        return new Vector(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
    }

    /// <summary>
    /// Оператор умножения числа на вектор
    /// </summary>
    /// <param name="scalar">Множитель</param>
    /// <param name="vector">Исходный вектор</param>
    /// <returns>Результирующий вектор Vector</returns>
    public static Vector operator *(double scalar, Vector vector)
    {
        return vector * scalar;
    }

    /// <summary>
    /// Оператор сравнения "меньше" по длине векторов
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>True если длина первого вектора меньше длины второго</returns>
    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.Length() < v2.Length();
    }

    /// <summary>
    /// Оператор сравнения "больше" по длине векторов
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>True если длина первого вектора больше длины второго</returns>
    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.Length() > v2.Length();
    }

    /// <summary>
    /// Оператор сравнения "меньше или равно" по длине векторов
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>True если длина первого вектора меньше или равна длине второго</returns>
    public static bool operator <=(Vector v1, Vector v2)
    {
        return v1.Length() <= v2.Length();
    }

    /// <summary>
    /// Оператор сравнения "больше или равно" по длине векторов
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>True если длина первого вектора больше или равна длине второго</returns>
    public static bool operator >=(Vector v1, Vector v2)
    {
        return v1.Length() >= v2.Length();
    }

    /// <summary>
    /// Оператор равенства векторов
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>True если векторы равны по координатам</returns>
    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }

    /// <summary>
    /// Оператор неравенства векторов
    /// </summary>
    /// <param name="v1">Первый вектор</param>
    /// <param name="v2">Второй вектор</param>
    /// <returns>True если векторы не равны по координатам</returns>
    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    /// <summary>
    /// Переопределение метода Equals для сравнения векторов
    /// </summary>
    /// <param name="obj">Объект для сравнения</param>
    /// <returns>True если объекты равны</returns>
    public override bool Equals(object obj)
    {
        if (obj is Vector other)
        {
            return this == other;
        }
        return false;
    }

    /// <summary>
    /// Переопределение метода GetHashCode
    /// </summary>
    /// <returns>Хэш-код вектора</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    /// <summary>
    /// Строковое представление вектора
    /// </summary>
    /// <returns>Строка в формате (X, Y, Z)</returns>
    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}

/// <summary>
/// Основной класс программы для демонстрации работы с векторами
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Демонстрация работы с векторами");
        Console.WriteLine();

        // Создание векторов
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);
        Vector v3 = new Vector(1, 2, 3);

        Console.WriteLine($"Вектор 1: {v1}");
        Console.WriteLine($"Вектор 2: {v2}");
        Console.WriteLine($"Вектор 3: {v3}");
        Console.WriteLine();

        // Демонстрация операций
        Console.WriteLine("Арифметические операции:");
        Console.WriteLine($"v1 + v2 = {v1 + v2}");
        Console.WriteLine($"v1 * v2 (скалярное) = {v1 * v2}");
        Console.WriteLine($"v1 * 2.5 = {v1 * 2.5}");
        Console.WriteLine($"3.0 * v2 = {3.0 * v2}");
        Console.WriteLine();

        // Демонстрация сравнения по длине
        Console.WriteLine("Сравнение по длине:");
        Console.WriteLine($"Длина v1: {v1.Length():F2}");
        Console.WriteLine($"Длина v2: {v2.Length():F2}");
        Console.WriteLine($"v1 < v2: {v1 < v2}");
        Console.WriteLine($"v1 > v2: {v1 > v2}");
        Console.WriteLine($"v1 <= v2: {v1 <= v2}");
        Console.WriteLine($"v1 >= v2: {v1 >= v2}");
        Console.WriteLine();

        // Демонстрация сравнения по координатам
        Console.WriteLine("Сравнение по координатам:");
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");
        Console.WriteLine($"v1 == v3: {v1 == v3}");
        Console.WriteLine($"v1 != v3: {v1 != v3}");
        Console.WriteLine();

        // Демонстрация метода Equals
        Console.WriteLine("Использование метода Equals:");
        Console.WriteLine($"v1.Equals(v2): {v1.Equals(v2)}");
        Console.WriteLine($"v1.Equals(v3): {v1.Equals(v3)}");
        Console.WriteLine($"v1.Equals(\"строка\"): {v1.Equals("строка")}");
    }
}