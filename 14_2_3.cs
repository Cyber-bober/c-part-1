/*
II. Решить задачу,  разработав собственную структуру для хранения информации 
Замечания: 
 Во всех задачах данного раздела подразумевается, что исходная информация хранится в 
текстовом файле input.txt, каждая строка которого содержит полную информацию о некотором 
объекте; результирующая информация должна быть записана в файл output.txt. 
 Для хранения данных внутри программы организовать массив структур.  
 Сортировку данных реализовать, реализуя метод CompareTo(T) стандартного интерфейса  
IComparable<in T>. 
На основе данных входного файла составить багажную ведомость камеры хранения, 
включив следующие данные: ФИО пассажира, количество вещей, общий вес вещей. 
Вывести в новый файл информацию о тех пассажирах, средний вес багажа которых 
превышает заданный, отсортировав их по количеству вещей, сданных в камеру 
хранения. 
Иванов И.И. 3 24
Петров А.В. 2 10
Сидорова М.К. 5 60
Кузнецов Д.Л. 4 20
7*/

using System;
using System.IO;

struct Passenger : IComparable<Passenger>
{
    public string Name;
    public int Count;
    public double Weight;

    public int CompareTo(Passenger other)
    {
        return Count.CompareTo(other.Count);
    }
}

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("E://study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_2_3/ConsoleApp1/input.txt");
        if (lines.Length < 1) return;

        double threshold = double.Parse(lines[^1]);

        Passenger[] passengers = new Passenger[lines.Length - 1];
        int index = 0;

        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] parts = lines[i].Split(' ');
            int count = int.Parse(parts[^2]);
            double weight = double.Parse(parts[^1]);
            string name = string.Join(" ", parts.Take(parts.Length - 2));

            passengers[index++] = new Passenger
            {
                Name = name,
                Count = count,
                Weight = weight
            };
        }

        Passenger[] temp = new Passenger[passengers.Length];
        int validCount = 0;

        foreach (var p in passengers)
        {
            if (p.Weight / p.Count > threshold)
            {
                temp[validCount++] = p;
            }
        }

        Passenger[] result = new Passenger[validCount];
        Array.Copy(temp, result, validCount);

        Array.Sort(result);

        using (StreamWriter writer = new StreamWriter("E://study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_2_3/ConsoleApp1/output.txt"))
        {
            if (validCount == 0)
                writer.WriteLine("Нет пассажиров со средним весом багажа выше заданного.");
            else
                foreach (var p in result)
                    writer.WriteLine($"{p.Name} {p.Count} {p.Weight}");
        }
    }
}
