/*Замечания. (через LINQ запросы)
1. Во всех задачах данного раздела подразумевается, что исходная информация хранится в 
текстовом файле input.txt, каждая строка которого содержит полную информацию о некотором 
объекте; результирующая информация должна быть записана в файл output.txt. 
2. Для хранения данных внутри программы организовать одномерный массив структур или любую 
другую подходящую коллекцию структур. Выбор коллекции обосновать.  
На основе данных входного файла составить список студентов группы, 
включив следующие данные: ФИО, номер группы, результаты сдачи трех экзаменов. 
Вывести в новый файл информацию о студентах, успешно сдавших сессию, отсортировав по 
номеру группы. 
Иванов И.И. 221 5 4 5
Петров А.А. 222 3 5 4
Сидоров М.М. 221 4 4 4
Быков В.Д. 223 5 5 5*/

using System;
using System.IO;
using System.Linq;

struct Student
{
    public string Name;
    public int Group;
    public int Exam1, Exam2, Exam3;
}

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_2_3/ConsoleApp1/input.txt");
        var students = new Student[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(' ');
            students[i] = new Student
            {
                Name = string.Join(" ", parts.Take(parts.Length - 4)),
                Group = int.Parse(parts[parts.Length - 4]),
                Exam1 = int.Parse(parts[parts.Length - 3]),
                Exam2 = int.Parse(parts[parts.Length - 2]),
                Exam3 = int.Parse(parts[parts.Length - 1])
            };
        }

        var result = (
            from s in students
            where s.Exam1 >= 4 && s.Exam2 >= 4 && s.Exam3 >= 4
            orderby s.Group
            select s
        ).ToList();

        using (var w = new StreamWriter("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/15_2_3/ConsoleApp1/output.txt"))
        {
            foreach (var s in result)
                w.WriteLine($"{s.Name} {s.Group} {s.Exam1} {s.Exam2} {s.Exam3}");
        }
    }
}
