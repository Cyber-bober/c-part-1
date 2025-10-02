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
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("Error");
            return;
        }
     
        Console.WriteLine($"Сумма цифр числа {N} = {SumDigits(N)}\n");

        // Примерные значения для отрезка и параметров (можно заменить на ввод)
        Console.Write("Enter a ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter C ");
        int C = int.Parse(Console.ReadLine());
        Console.Write("Enter A ");
        int A = int.Parse(Console.ReadLine());
        string s = "";
        string e = "";
        string o = "";


        // a) Сумма цифр для каждого числа на отрезке [a, b]
        Console.WriteLine("a) Суммы цифр на отрезке [a, b]:");
       
        for (int i = a; i <= b; i++)
        {
            int sum = SumDigits(i);
            s += $"{i} -> {sum}\n";
            if (sum == C)
                e += $"{i} ";
            if (sum % 2 == 1)
                o += $"{i} ";

        }
        Console.WriteLine(s);
        Console.WriteLine($"\nb) Числа с суммой цифр = {C}: {e}");
        Console.WriteLine($"\nc) Числа с нечётной суммой цифр = {o}");
        int t = SumDigits(A);
        Console.WriteLine($"\nd) Ближайшее чисело перед {A} с суммой цифр {t}:");
        for (int i = A -1; i >= 1; i--)
        {
            if (SumDigits(i) == t)
            {
                Console.WriteLine(i);
                break;
            }
        }
        Console.ReadLine();
    }
