/*условие как в 15_2_3
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
        string[] lines = File.ReadAllLines("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/16_2_3/ConsoleApp1/input.txt");

        var students = lines.Select(line =>
        {
            var parts = line.Split(' ');
            string name = string.Join(" ", parts.Take(parts.Length - 4));
            return new Student
            {
                Name = name,
                Group = int.Parse(parts[parts.Length - 4]),
                Exam1 = int.Parse(parts[parts.Length - 3]),
                Exam2 = int.Parse(parts[parts.Length - 2]),
                Exam3 = int.Parse(parts[parts.Length - 1])
            };
        });

        var result = students
            .Where(s => s.Exam1 >= 4 && s.Exam2 >= 4 && s.Exam3 >= 4)
            .OrderBy(s => s.Group);

        using (var writer = new StreamWriter("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/16_2_3/ConsoleApp1/output.txt"))
        {
            foreach (var student in result)
            {
                writer.WriteLine($"{student.Name} {student.Group} {student.Exam1} {student.Exam2} {student.Exam3}");
            }
        }
    }
}
