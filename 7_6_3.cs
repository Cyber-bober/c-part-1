/*В массиве размером n×n, элементы которого – целые числа, произвести следующие 
действия: Вставить новую строку после всех строк, в которых нет ни одного четного элемента.
Замечание. Для хранения массив n×n использовать двумерный или ступенчатый массив. Свой выбор 
обосновать.

ДОБАВИТЬ: Сдвиг как в одномерном массиве и сделать разное количество элементов в строке */

using System;

class Program
{

    static bool HasEven(int[] row)
    {
        for (int j = 0; j < row.Length; j++)
        {
            if (row[j] % 2 == 0)
                return true;
        }
        return false;
    }

    static void Print(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write("{0,3} ", matrix[i][j]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
n)
        int[][] a = new int[n][];
        for (int i = 0; i < n; i++)
        {
            a[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                Console.Write("a[{0},{1}] = ", i, j);
                a[i][j] = int.Parse(Console.ReadLine());
            }
        }

        int countNoEven = 0;
        for (int i = 0; i < n; i++)
        {
            if (!HasEven(a[i]))
                countNoEven++;
        }

        int[][] result = new int[n + countNoEven][];

        int resultIndex = 0;
        for (int i = 0; i < n; i++)
        {

            result[resultIndex] = new int[n];
            Array.Copy(a[i], result[resultIndex], n);
            resultIndex++;

            if (!HasEven(a[i]))
            {
                result[resultIndex] = new int[n + 1]; 
                // Заполним нулями 
                for (int k = 0; k < n + 1; k++)
                    result[resultIndex][k] = 0;
                resultIndex++;
            }
        }

        // Вывод
        Console.WriteLine("\nИсходная матрица:");
        Print(a);

        Console.WriteLine("\nМатрица после вставки (ступенчатая, с разной длиной строк):");
        Print(result);

        Console.ReadLine();
    }
}
