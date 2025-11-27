/* Дана последовательность целых чисел.  
Замечание. Для хранения последовательности можно использовать одномерный массив 
или любую другую подходящую коллекцию. Выбор структуры данных обосновать. Ввод вывод 
данных – файловый. 

Вывести на экран все числа, попадающий в отрезок [a, b], отсортировав их в порядке 
возрастания. */
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");

        string[] numbersStr = lines[0].Split(' ');
        int[] array = new int[numbersStr.Length];
        for (int i = 0; i < numbersStr.Length; i++)
        {
            array[i] = int.Parse(numbersStr[i]);
        }

        string[] rangeStr = lines[1].Split(' ');
        int a = int.Parse(rangeStr[0]);
        int b = int.Parse(rangeStr[1]);

        List<int> result = new List<int>();

        foreach (int num in array)
        {
            if (num >= a && num <= b)
            {
                result.Add(num); 
            }
        }

        result.Sort();

        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            if (result.Count == 0)
            {
                writer.WriteLine("Нет чисел в заданном диапазоне.");
                Console.WriteLine("Нет чисел в заданном диапазоне.");
            }
            else
            {
                foreach (int num in result)
                {
                    writer.WriteLine(num);
                    Console.WriteLine(num);
                }
            }
        }
    }
}
