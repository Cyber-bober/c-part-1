using System;

class Program
{
    static int SumDigits(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10; // добавляем последнюю цифру
            n /= 10;       // убираем последнюю цифру
        }
        return sum;
    }

    static void Main()
    {
        // Ввод натурального числа N
        Console.Write("Введите натуральное число N: ");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine($"Сумма цифр числа {N} = {SumDigits(N)}\n");

        // Примерные значения для отрезка и параметров (можно заменить на ввод)
        int a = 10, b = 30, C = 5, A = 23;

        // a) Сумма цифр для каждого числа на отрезке [a, b]
        Console.WriteLine("a) Суммы цифр на отрезке [a, b]:");
        for (int i = a; i <= b; i++)
            Console.WriteLine($"{i} -> {SumDigits(i)}");

        // b) Числа с суммой цифр, равной C
        Console.WriteLine($"\nb) Числа с суммой цифр = {C}:");
        for (int i = a; i <= b; i++)
            if (SumDigits(i) == C)
                Console.Write($"{i} ");
        Console.WriteLine();

        // c) Числа с нечётной суммой цифр
        Console.WriteLine("\nc) Числа с нечётной суммой цифр:");
        for (int i = a; i <= b; i++)
            if (SumDigits(i) % 2 == 1)
                Console.Write($"{i} ");
        Console.WriteLine();

        // d) Ближайшее предшествующее число с такой же суммой цифр, как у A
        Console.WriteLine($"\nd) Ближайшее число перед {A} с суммой цифр {SumDigits(A)}:");
        int targetSum = SumDigits(A);
        for (int i = A - 1; i >= 1; i--)
        {
            if (SumDigits(i) == targetSum)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}
