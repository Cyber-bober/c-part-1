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
        string text = File.ReadAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/input.txt")
        string[] tokens = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        var allNumbers = (from token in tokens
                          where int.TryParse(token, out _) 
                          select int.Parse(token)).ToList();

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
        var sequence = new int[allNumbersCount - 2];
        for (int i = 0; i < sequence.Length; i++)
            sequence[i] = AllNumbers[i]
        var result = (for n in sequence
                      where n >= a && n <= b
                      orderby n
                      select n).ToList();

        if (result.Count == 0)
            File.WriteAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", "Нет чисел в заданном диапазоне.");
        else
            File.WriteAllLines("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", result.Select(n => n.ToString()));
    }
}
