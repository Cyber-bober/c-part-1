/*Дан массив размером  n×n, элементы которого целые числа. 
Замечание. Для хранения массив n×n использовать двумерный или ступенчатый массив. Свой выбор 
обосновать. Четные столбцы таблицы заменить на вектор Х. */

class Program
{
    static void Main()
    {

        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        // Ввод элементов матрицы
        Console.WriteLine("Введите элементы матрицы построчно:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int[] X = new int[n];
        Console.WriteLine("Введите элементы вектора X:");
        for (int i = 0; i < n; i++)
        {
            X[i] = int.Parse(Console.ReadLine());
        }

        // Заменяем чётные столбцы (нумерация с 1, индексы 1, 3, 5...)
        for (int j = 1; j < n; j += 2) 
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i, j] = X[i];
            }
        }

        Console.WriteLine("Результат:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
