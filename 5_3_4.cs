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
    static string Lunat1(int n)
    {
        if (n > 4 || n == 0)
            return "лунатиков";
        else if (n == 1)
            return "лунатик";
        else
            return "лунатика";
    }
    static string Lunat2(int n)
    {
        return (n == 1) ? "жил" : "жили";
    }
    static string Lunat3(int n)
        {
            return (n == 1) ? "ворочался" : "ворочалось";
        }
    static string Lunat4(int n)
    {
        return (n == 1) ? "остался" : "осталось";
    }
    static void PrintLunaticsPoem(int count)
    {

    if (count == 0)
    {
        Console.WriteLine("И больше лунатиков не стало на луне");
        return;
    }
    string word1 = Lunat1(count);
    string word2 = Lunat2(count);
    string word3 = Lunat3(count);
    string word4 = Lunat1(count - 1);
    string word5 = Lunat4(count - 1);
    Console.WriteLine($"{count} {word1} {word2} на луне");
    Console.WriteLine($"{count} {word1} {word3} во сне");
    Console.WriteLine("Один из лунатиков упал с луны во сне");
    Console.WriteLine($"{count - 1} {word4} {word5} на луне");

    Console.WriteLine();

    PrintLunaticsPoem(count - 1);
    }

    static void Main()
    {
        PrintLunaticsPoem(10);

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    
}
