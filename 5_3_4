/*Разработать рекурсивный метод для вывода на экран стихотворения: 
10 лунатиков жили на луне 
10 лунатиков ворочались во сне 
Один из лунатиков упал с луны во сне 
9 лунатиков осталось на луне 
8 
 
9 лунатиков жили на луне 
9 лунатиков ворочались во сне 
Один из лунатиков упал с луны во сне 
8 лунатиков осталось на луне 
…... 
И больше лунатиков не стало на луне */
using System;

class Program
{

    static void PrintLunaticsPoem(int count)
    {

        if (count == 0)
        {
            Console.WriteLine("И больше лунатиков не стало на луне");
            return; 
        }

        Console.WriteLine($"{count} лунатиков жили на луне");
        Console.WriteLine($"{count} лунатиков ворочались во сне");
        Console.WriteLine("Один из лунатиков упал с луны во сне");
        Console.WriteLine($"{count - 1} лунатиков осталось на луне");

        Console.WriteLine();

        PrintLunaticsPoem(count - 1);
    }

    static void Main(string[] args)
    {
        int startCount = 10;

        PrintLunaticsPoem(startCount);

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
