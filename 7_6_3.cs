/*В массиве размером n×n, элементы которого – целые числа, произвести следующие 
действия: Вставить новую строку после всех строк, в которых нет ни одного четного элемента.
Замечание. Для хранения массив n×n использовать двумерный или ступенчатый массив. Свой выбор 
обосновать.

ДОБАВИТЬ: Сдвиг как в одномерном массиве и сделать разное количество элементов в строке */

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine());

        int maxRows = 2 * n;
        int[][] matrix = new int[maxRows][];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элементы {i + 1}-й строки через пробел: ");
            string[] parts = Console.ReadLine().Split(' ');
            matrix[i] = new int[parts.Length];
            for (int j = 0; j < parts.Length; j++)
            {
                matrix[i][j] = int.Parse(parts[j]);
            }
        }

        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix, n);

        int currentRows = n;

        for (int i = currentRows - 1; i >= 0; i--)
        {
            bool hasEven = false;
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] % 2 == 0)
                {
                    hasEven = true;
                    break;
                }
            }

            if (!hasEven)
            {
                for (int k = currentRows; k > i + 1; k--)
                {
                    matrix[k] = matrix[k - 1];
                }

                matrix[i + 1] = new int[matrix[i].Length];
                currentRows++;
            }
        }

        Console.WriteLine("\nМатрица после вставки строк:");
        PrintMatrix(matrix, currentRows);
    }

    static void PrintMatrix(int[][] matrix, int rows)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
