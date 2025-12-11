/*условие как в 15_1_3
-10 -9 -8 -7 -6 -5 -4 -3 ^ -2 -1 0&% 1 2 3 ! 4 5 6 7 8 9 10 -5 5*/
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        char[] delimiters = { ' ', '\t', '\n', '\r', ',', ';', ':', '.', '!', '?', '(', ')', '[', ']', '{', '}' };

        var allNumbers = File.ReadAllText("input.txt")
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Where(token => int.TryParse(token, out _))
            .Select(token => int.Parse(token))
            .ToList();

        if (allNumbers.Count < 2)
        {
            File.WriteAllText("output.txt", "Ошибка: недостаточно чисел для определения диапазона [a, b].");
            return;
        }

        int a = allNumbers[allNumbers.Count - 2];
        int b = allNumbers[allNumbers.Count - 1];
        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        var result = allNumbers
            .Take(allNumbers.Count - 2)
            .Where(n => n >= a && n <= b)
            .OrderBy(n => n)
            .ToList();

        if (result.Count == 0)
            File.WriteAllText("output.txt", "Нет чисел в заданном диапазоне.");
        else
            File.WriteAllLines("output.txt", result.Select(n => n.ToString()));
    }
}
