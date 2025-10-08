//Разработать рекурсивный метод, возвращающий
//значение количества цифр заданного натурального числа

using System;

class Program
{
    static int Count(int num)
    {
        if (num < 10)
            return 1;
        return 1 + Count(num / 10);
    }
    static void Main(string[] args)
    {
        Console.Write("Enter Natural num: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0)
        {
            int digitCount = Count(num);
            Console.WriteLine($"Numbers of num {num}: {digitCount}");
        }
        else
        {
            Console.WriteLine("Error: incorrect number. Enter natural number");
        }
    }
}
