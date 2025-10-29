/*В массиве размером n×n, элементы которого – целые числа, произвести следующие 
действия: Вставить новую строку после всех строк, в которых нет ни одного четного элемента.
Замечание. Для хранения массив n×n использовать двумерный или ступенчатый массив. Свой выбор 
обосновать. */

using System;

class Program
{
    // Проверяет, есть ли хотя бы один чётный элемент в строке
    static bool HasEven(int[] row)
    {
        for (int j = 0; j < row.Length; j++)
        {
            if (row[j] % 2 == 0)
                return true;
        }
        return false;
    }

    // Вывод ступенчатого массива
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

        // Ввод исходной матрицы (ступенчатый массив)
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

        // Подсчитать, сколько строк НЕ содержат чётных элементов
        int countNoEven = 0;
        for (int i = 0; i < n; i++)
        {
            if (!HasEven(a[i]))
                countNoEven++;
        }

        // Итоговое количество строк
        int newRows = n + countNoEven;

        // Создать новую матрицу
        int[][] result = new int[newRows][];

        int resultIndex = 0;
        for (int i = 0; i < n; i++)
        {
            // Копируем текущую строку
            result[resultIndex] = new int[n];
            for (int j = 0; j < n; j++)
                result[resultIndex][j] = a[i][j];
            resultIndex++;

            // Если в строке нет чётных — вставляем строку из нулей
            if (!HasEven(a[i]))
            {
                result[resultIndex] = new int[n]; // все элементы = 0
                resultIndex++;
            }
        }

        // Вывод
        Console.WriteLine("\nИсходная матрица:");
        Print(a);

        Console.WriteLine("\nМатрица после вставки:");
        Print(result);
        Console.ReadLine();
    }
}
