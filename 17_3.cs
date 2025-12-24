/*Замечание: При демонстрации работы класса использовать файловый ввод/вывод 
данных. Для хранения экземпляров класса использовать типизированную коллекцию List<>

 Задание 3. Создать класс Rectangle, содержащий следующие члены класса: 
1. Закрытые поля: 
 int a, b; 
2.  Конструкторы, позволяющие создать экземпляр класса: 
 со значениями полей по умолчанию; 
 с заданными длинами сторон (допустимыми); 
 на основе существующего экземпляра класса (конструктор копирования). 
3. Методы, позволяющие: 
 расчитать периметр прямоугольника; 
 расчитать площадь прямоугольника; 
 масштабировать треугольник с заданным коэффицентом. 
4. Перегрузить методы предка Object (ToString, GetHashCode, Equals, GetType). 
5. Свойство: 
 позволяющее получать доступ к закрытым полям класса (доступное для чтения и 
записи, при записи проверять допустимость новых значений полей); 
 позволяющее установить, является ли данный прямоугольник квадратом (доступное 
только для чтения). 
6. Индексатор, позволяющий по индексу 0 обращаться к полю a, по индексу 1 – к полю b, 
при других значениях индекса выдается сообщение об ошибке. 
7. Перегрузку: 
 операции ++ (--): одновременно увеличивает (уменьшает) значение полей a и b; 
 констант true и false: обращение к экземпляру класса дает значение true, если 
прямоугольник с заданными длинами сторон является квадратом, иначе false; 
 операции *:  одновременно домножает поля a и b  на скаляр. 
Продемонстрировать работу класса. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Rectangle
{
    private int a, b;
    public Rectangle()
    {
        this.a = 1;
        this.b = 1;
    }

    public Rectangle(int a, int b)
    {
        if (a <= 0 || b <= 0)
        {
            throw new ArgumentException("Длины сторон должны быть положительными.");
        }
        this.a = a;
        this.b = b;
    }

    public Rectangle(Rectangle other)
    {
        this.a = other.a;
        this.b = other.b;
    }

    public (int A, int B) Sides
    {
        get { return (a, b); }
        set
        {
            if (value.A <= 0 || value.B <= 0)
            {
                throw new ArgumentException("Длины сторон должны быть положительными.");
            }
            a = value.A;
            b = value.B;
        }
    }

    public bool IsSquare
    {
        get { return a == b; }
    }

    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return b;
                default: throw new IndexOutOfRangeException("Индекс должен быть 0 или 1.");
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    if (value <= 0) throw new ArgumentException("Длина стороны должна быть положительной.");
                    a = value;
                    break;
                case 1:
                    if (value <= 0) throw new ArgumentException("Длина стороны должна быть положительной.");
                    b = value;
                    break;
                default: throw new IndexOutOfRangeException("Индекс должен быть 0 или 1.");
            }
        }
    }

    public int CalculatePerimeter()
    {
        return 2 * (a + b);
    }

    public int CalculateArea()
    {
        return a * b;
    }

    public void Scale(double factor)
    {
        if (factor <= 0)
        {
            throw new ArgumentException("Коэффициент масштабирования должен быть положительным.");
        }
        a = (int)(a * factor);
        b = (int)(b * factor);
    }

    public override string ToString()
    {
        return $"Rectangle [a={a}, b={b}]";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Rectangle other = (Rectangle)obj;
        return (a == other.a && b == other.b) || (a == other.b && b == other.a);
    }

    public override int GetHashCode()
    {
        int MinSide = Math.Min(a, b);
        int MaxSide = Math.Max(a, b);
        return (MinSide * 397) ^ MaxSide;
    }

    public static Rectangle operator ++(Rectangle r)
    {
        return new Rectangle(r.a + 1, r.b + 1);
    }

    public static Rectangle operator --(Rectangle r)
    {
        return new Rectangle(Math.Max(1, r.a - 1), Math.Max(1, r.b - 1));
    }

    public static bool operator true(Rectangle r)
    {
        return r.IsSquare;
    }

    public static bool operator false(Rectangle r)
    {
        return !r.IsSquare;
    }

    public static explicit operator bool(Rectangle r)
    {
        return r.IsSquare;
    }

    public static Rectangle operator *(Rectangle r, int scalar)
    {
        if (scalar <= 0)
        {
            throw new ArgumentException("Скаляр должен быть положительным.");
        }
        return new Rectangle(r.a * scalar, r.b * scalar);
    }

    public static Rectangle operator *(int scalar, Rectangle r)
    {
        return r*scalar;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFileName = "C:/Users/bykovvd/Desktop/c#/17/input.txt";
        string outputFileName = "C:/Users/bykovvd/Desktop/c#/17/output.txt";

        List<Rectangle> rectangles = new List<Rectangle>();

        Console.WriteLine("--- Чтение прямоугольников из файла {0} ---", inputFileName);

        if (File.Exists(inputFileName))
        {
            using (StreamReader reader = new StreamReader(inputFileName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2 && int.TryParse(parts[0], out int a) && int.TryParse(parts[1], out int b))
                    {
                        try
                        {

                            Rectangle rect = new Rectangle(a, b);
                            rectangles.Add(rect);
                            Console.WriteLine($"Прочитан из файла: {rect}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Ошибка при создании прямоугольника из строки '{line}': {ex.Message}");
                        }
                    }
                    else
                    {

                        Console.WriteLine($"Некорректный формат строки в файле: {line}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine($"Файл {inputFileName} не найден.");
            return;
        }

        if (rectangles.Count == 0)
        {
            Console.WriteLine("Список прямоугольников пуст. Завершение.");
            return;
        }

        Console.WriteLine("\n--- Демонстрация работы класса на основе данных из файла ---");

        Rectangle demoRect = rectangles[0];
        Console.WriteLine($"Демонстрационный прямоугольник: {demoRect}");
        Console.WriteLine($"Периметр: {demoRect.CalculatePerimeter()}");
        Console.WriteLine($"Площадь: {demoRect.CalculateArea()}");
        Console.WriteLine($"IsSquare: {demoRect.IsSquare}");
        Console.WriteLine($"(bool)demoRect: {(bool)demoRect}");

        demoRect.Sides = (7, 7);
        Console.WriteLine($"После изменения на (7,7) через Sides: {demoRect}, IsSquare: {demoRect.IsSquare}");


        demoRect[0] = 8;
        Console.WriteLine($"После изменения a через индексатор на 8: {demoRect}");

        Console.WriteLine($"До инкремента: {demoRect}");
        demoRect++;
        Console.WriteLine($"После инкремента (++): {demoRect}");

        Rectangle scaledRect = 2 * demoRect;
        Console.WriteLine($"Результат demoRect * 2: {scaledRect}");

        Console.WriteLine("\n--- LINQ-запросы на основе данных из файла ---");
        var rectanglesWithAreaOver10 = from rect in rectangles
                                       where rect.CalculateArea() > 10
                                       select rect;

        Console.WriteLine("Прямоугольники с площадью > 10:");
        foreach (var rect in rectanglesWithAreaOver10)
        {
            Console.WriteLine($"  {rect}, Площадь: {rect.CalculateArea()}");
        }


        var sortedByPerimeter = from rect in rectangles
                                orderby rect.CalculatePerimeter() ascending
                                select rect;

        Console.WriteLine("\nПрямоугольники, отсортированные по периметру (по возрастанию):");
        foreach (var rect in sortedByPerimeter)
        {
            Console.WriteLine($"  {rect}, Периметр: {rect.CalculatePerimeter()}");
        }


        var groupedBySquare = from rect in rectangles
                              group rect by rect.IsSquare into squareGroup
                              select new { IsSquare = squareGroup.Key, Rectangles = squareGroup };

        Console.WriteLine("\nГруппировка по признаку квадрата:");
        foreach (var group in groupedBySquare)
        {
            Console.WriteLine($"  Являются квадратами: {group.IsSquare}");
            foreach (var rect in group.Rectangles)
            {
                Console.WriteLine($"    {rect}");
            }
        }

        Console.WriteLine($"\n--- Запись результатов LINQ-запросов в файл {outputFileName} ---");
        using (StreamWriter writer = new StreamWriter(outputFileName))
        {

            writer.WriteLine("=== Прямоугольники с площадью > 10 ===");
            foreach (var rect in rectanglesWithAreaOver10)
            {
                writer.WriteLine($"{rect} -> Площадь: {rect.CalculateArea()}");
            }


            writer.WriteLine("\n=== Прямоугольники, отсортированные по периметру (по возрастанию) ===");
            foreach (var rect in sortedByPerimeter)
            {
                writer.WriteLine($"{rect} -> Периметр: {rect.CalculatePerimeter()}");
            }


            writer.WriteLine("\n=== Группировка по признаку квадрата ===");
            foreach (var group in groupedBySquare)
            {
                writer.WriteLine($"  Являются квадратами: {group.IsSquare}");
                foreach (var rect in group.Rectangles)
                {
                    writer.WriteLine($"    {rect}");
                }
            }
        }
        Console.WriteLine($"Результаты LINQ-запросов успешно записаны в {outputFileName}");
        Console.ReadLine();
    }
}
