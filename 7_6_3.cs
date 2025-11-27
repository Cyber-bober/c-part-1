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

        // Создаём ступенчатый массив
        int[][] matrix = new int[n][];

        // Шаг 2: Ввод строк разной длины
        for (int i = 0; i < n; i++)
        {
            Console.Write($" {i + 1} ");
            string[] input = Console.ReadLine().Split(' ');
            matrix[i] = new int[input.Length];
            for (int j = 0; j < input.Length; j++)
            {
                matrix[i][j] = int.Parse(input[j]);
            }
        }

        // Выводим исходную матрицу
        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix);

        // Шаг 3: Проходим по строкам и вставляем новые
        int currentRowCount = matrix.Length;
        for (int i = 0; i < currentRowCount; i++)
        {
            // Проверяем, есть ли в строке хотя бы один чётный элемент
            bool hasEven = false;
            foreach (int element in matrix[i])
            {
                if (element % 2 == 0)
                {
                    hasEven = true;
                    break;
                }
            }

            // Если в строке нет чётных элементов
            if (!hasEven)
            {
                // Вставляем новую строку (например, длиной 3, заполненную нулями)
                // Можно задать любую длину, например, длину предыдущей строки
                int newRowLength = matrix[i].Length; // длина новой строки = длина текущей
                InsertNewRow(matrix, i + 1, newRowLength);
                i++; // пропускаем новую строку, чтобы не проверять её снова
                currentRowCount++; // увеличиваем общее количество строк
            }
        }

        // Выводим результат
        Console.WriteLine("\nМатрица после вставки строк:");
        PrintMatrix(matrix);
    }

    // Метод для вставки новой строки в ступенчатый массив
    static void InsertNewRow(int[][] matrix, int insertIndex, int newRowLength)
    {
        // Создаём новую строку (например, заполненную нулями)
        int[] newRow = new int[newRowLength];

        // Сдвигаем все строки с индекса insertIndex и ниже вниз на одну строку
        for (int i = matrix.Length - 1; i >= insertIndex; i--)
        {
            matrix[i + 1] = matrix[i];
        }

        // Вставляем новую строку
        matrix[insertIndex] = newRow;
    }

    // Метод для вывода матрицы на экран
    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] row in matrix)
        {
            foreach (int element in row)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}