/*Дан массив размером  n×n, элементы которого целые числа. 
Замечание. Для хранения массив n×n использовать двумерный или ступенчатый массив. Свой выбор 
обосновать. Четные столбцы таблицы заменить на вектор Х. */

using System;

class Program
{
    // Вывод матрицы
    static void Print(int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write("{0,3} ", a[i, j]);
            }
            Console.WriteLine();
        }
    }

    // Ввод квадратной матрицы n×n
    static void Input(out int[,] a)
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());
        a = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("a[{0},{1}]= ", i, j);
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    // Ввод вектора X длиной n
    static void InputVector(int n, out int[] x)
    {
        x = new int[n];
        Console.WriteLine("Введите вектор X (длина {0}):", n);
        for (int i = 0; i < n; i++)
        {
            Console.Write("x[{0}]= ", i);
            x[i] = int.Parse(Console.ReadLine());
        }
    }

    // Замена чётных столбцов (с индексами 0, 2, 4, ...) на вектор X
    static void Change(int[,] a, int[] x)
    {
        int n = a.GetLength(0); // так как квадратная матрица

        for (int j = 0; j < n; j++)
        {
            if (j % 2 == 0) 
            {
                for (int i = 0; i < n; i++)
                {
                    a[i, j] = x[i];
                }
            }
        }
    }

    static void Main()
    {
        int[,] a;
        Input(out a);
        int n = a.GetLength(0);

        int[] x;
        InputVector(n, out x);

        Console.WriteLine("Исходный массив:");
        Print(a);

        Change(a, x);

        Console.WriteLine("Изменённый массив:");
        Print(a);
        Console.ReadLine();
    }
}
