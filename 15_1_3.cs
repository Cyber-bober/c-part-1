/* Дана последовательность целых чисел.  
Замечание. Для хранения последовательности можно использовать одномерный массив 
или любую другую подходящую коллекцию. Выбор структуры данных обосновать. Ввод вывод 
данных – файловый. 

Вывести на экран все числа, попадающий в отрезок [a, b], отсортировав их в порядке 
возрастания. */
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = File.ReadAllText("input.txt");
        var matches = Regex.Matches(text, @"-?\d+");
        List<int> allNumbers = matches.Cast<Match>().Select(m => int.Parse(m.Value)).ToList();

        if (allNumbers.Count < 2)
        {
            File.WriteAllText("output.txt", "Ошибка: недостаточно чисел для определения диапазона [a, b].");
            return;
        }

        int a = allNumbers[^2];
        int b = allNumbers[^1];
        var sequence = allNumbers.Take(allNumbers.Count - 2);

        var result = (from n in sequence
                      where n >= a && n <= b
                      orderby n
                      select n).ToList();

        using (var writer = new StreamWriter("output.txt"))
        {
            if (result.Count == 0)
                writer.WriteLine("Нет чисел в заданном диапазоне.");
            else
                result.ForEach(writer.WriteLine);
        }
    }
}
        }
    }
}
