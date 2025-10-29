/*Дана строка, в которой содержится осмысленное текстовое сообщение. Слова 
сообщения разделяются пробелами и знаками препинания. 
Вывести только те слова сообщения, которые начинаются с прописной буквы. */

using System;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        string word = "";

        for (int i = 0; i <= s.Length; i++)
        {
            char c = (i < s.Length) ? s[i] : ' '; // добавляем завершающий пробел

            if (char.IsLetter(c))
            {
                word += c;
            }
            else if (word != "")
            {
                // Проверяем: первая буква — заглавная?
                if (char.IsUpper(word[0]))
                    Console.Write(word + " ");
                word = "";
            }
        }
        Console.WriteLine();
    }
}
