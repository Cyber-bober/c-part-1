/*Дана строка, в которой содержится осмысленное текстовое сообщение. Слова 
сообщения разделяются пробелами и знаками препинания. 
Вывести только те слова сообщения, которые начинаются с прописной буквы.

ДОБАВИТЬ: Массив сплит и чтобы работало со знаками */

using System;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();

        // Массив разделителей: пробелы и основные знаки препинания
        char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '-', '(', ')', '[', ']', '"', '\'', '\t', '\n', '\r' };

        // Разбиваем строку на части, удаляя пустые фрагменты
        string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        // Перебираем все полученные "слова"
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            // Проверяем, что слово не пустое и начинается с буквы
            if (word.Length > 0 && char.IsLetter(word[0]))
            {
                // Если первая буква — заглавная, выводим слово
                if (char.IsUpper(word[0]))
                {
                    Console.Write(word + " ");
                }
            }
        }

        Console.WriteLine();
    }
}
