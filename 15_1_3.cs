/* Дана последовательность целых чисел.  
Замечание. Для хранения последовательности можно использовать одномерный массив 
или любую другую подходящую коллекцию. Выбор структуры данных обосновать. Ввод вывод 
данных – файловый. 

Вывести на экран все числа, попадающий в отрезок [a, b], отсортировав их в порядке 
возрастания. */
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        char[] delimiters = { ' ', '\t', '\n', '\r', ',', ';', ':', '.', '!', '?', '(', ')', '[', ']', '{', '}' };
        var numbers = File.ReadAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/input.txt")
                           .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                           .Where(s => int.TryParse(s, out _))
                           .Select(s => int.Parse(s))
                           .ToList();

        if (numbers.Count < 2)
        {
            File.WriteAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", "Ошибка: недостаточно чисел для определения диапазона [a, b].");
            return;
        }

        int a = numbers[numbers.Count - 2];
        int b = numbers[numbers.Count - 1];
        if (a > b)
        {
            int x = a;
            a = b;
            b = x;
        }

        var result = numbers.Take(numbers.Count - 2)
                            .Where(n => n >= a && n <= b)
                            .OrderBy(n => n)
                            .ToList();

        if (result.Count == 0)
            File.WriteAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", "Нет чисел в заданном диапазоне.");
        else
            File.WriteAllLines("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", result.Select(n => n.ToString()));
    }
}
