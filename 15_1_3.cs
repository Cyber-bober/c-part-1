/* Дана последовательность целых чисел.  
Замечание. Для хранения последовательности можно использовать одномерный массив 
или любую другую подходящую коллекцию. Выбор структуры данных обосновать. Ввод вывод 
данных – файловый. 

Вывести на экран все числа, попадающий в отрезок [a, b], отсортировав их в порядке 
возрастания. -10 -9 -8 -7 -6 -5 -4 -3 ^ -2 -1 0&% 0 1 2 3 ! 1 2 3 №;*(:№% 4 5 6 7 8 9 10 -5 6 */
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        char[] delimiters = { ' ', '\t', '\n', '\r', ',', ';', ':', '.', '!', '?', '(', ')', '[', ']', '{', '}' };
        string text = File.ReadAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/input.txt");
        string[] tokens = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        var allNumbersQuery = from token in tokens
                              where int.TryParse(token, out int number)
                              select number;

        int[] allNumbersArray = allNumbersQuery.ToArray();

        if (allNumbersArray.Length < 2)
        {
            File.WriteAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", "Ошибка: недостаточно чисел для определения диапазона [a, b].");
            return;
        }

        int a = allNumbersArray[allNumbersArray.Length - 2];
        int b = allNumbersArray[allNumbersArray.Length - 1];
        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        var sequenceQuery = from i in Enumerable.Range(0, allNumbersArray.Length - 2)
                            select allNumbersArray[i];

        var resultQuery = from n in sequenceQuery
                          where n >= a && n <= b
                          orderby n
                          select n.ToString();

        string[] resultArray = resultQuery.ToArray();

        if (resultArray.Length == 0)
        {
            File.WriteAllText("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", "Нет чисел в заданном диапазоне.");
        }
        else
        {
            File.WriteAllLines("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_1_3/ConsoleApp1/output.txt", resultArray);
        }
    }
}
