/*Даны два файла с числами. Поменять местами их содержимое (использовать 
вспомогательный файл). Работа с символьными потоками*/

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string file1 = "file1.txt";
        string file2 = "file2.txt";
        string tempFile = "temp.txt"; // вспомогательный файл

        try
        {
            // Шаг 1: копируем содержимое file1 во временный файл
            using (StreamReader reader = new StreamReader(file1))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }

            // Шаг 2: копируем содержимое file2 в file1
            using (StreamReader reader = new StreamReader(file2))
            using (StreamWriter writer = new StreamWriter(file1))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }

            // Шаг 3: копируем содержимое временного файла в file2
            using (StreamReader reader = new StreamReader(tempFile))
            using (StreamWriter writer = new StreamWriter(file2))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }

            // Шаг 4: удаляем временный файл
            File.Delete(tempFile);

            Console.WriteLine("Содержимое файлов успешно обменено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
