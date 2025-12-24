/*Решить задачу, разработав собственную структуру для хранения информации 
Замечания: 
- Во всех задачах данного раздела подразумевается, что исходная информация хранится в 
текстовом файле input.txt, каждая строка которого содержит полную информацию о некотором 
объекте; результирующая информация должна быть записана в файл output.txt. 
- Для хранения данных внутри программы организовать массив структур.  
- Сортировку данных реализовать, реализуя метод CompareTo(T) стандартного интерфейса  
IComparable<in T>.

На основе данных входного файла составить багажную ведомость камеры хранения,
включив следующие данные: ФИО пассажира, количество вещей, общий вес вещей. 
Вывести в новый файл информацию о тех пассажирах, средний вес багажа которых 
превышает заданный, отсортировав их по количеству вещей, сданных в камеру 
хранения

4.5
Иванов Иван Иванович;3;15.5
Петрова Мария Алексеевна;2;12.0
Сидоров Петр;5;20.0*/

using System;
using System.IO;
using System.Globalization;

namespace BaggageStorage
{
    struct Passenger : IComparable<Passenger>
    {
        public string FullName;
        public int ItemCount;
        public double TotalWeight;

        public Passenger(string name, int count, double weight)
        {
            FullName = name;
            ItemCount = count;
            TotalWeight = weight;
        }

        public double AvgWeight()
        {
            return ItemCount != 0 ? TotalWeight / ItemCount : 0.0;
        }

        public int CompareTo(Passenger other)
        {
            return ItemCount.CompareTo(other.ItemCount);
        }

        public override string ToString()
        {
            return $"{FullName};{ItemCount};{TotalWeight:F1}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/14_2_3/ConsoleApp1/input.txt";
            string outputFile = "E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/14_2_3/ConsoleApp1/output.txt";

            string[] lines = File.ReadAllLines(inputFile);
            double threshold = double.Parse(lines[0].Trim(), System.Globalization.CultureInfo.InvariantCulture);

            Passenger[] passengers = new Passenger[lines.Length - 1];

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                string name = parts[0].Trim();
                int count = int.Parse(parts[1]);
                double weight = double.Parse(parts[2].Trim(), System.Globalization.CultureInfo.InvariantCulture);
                passengers[i - 1] = new Passenger(name, count, weight);
            }

            int filteredCount = 0;
            foreach (var p in passengers)
            {
                if (p.AvgWeight() > threshold)
                {
                    filteredCount++;
                }
            }

            Passenger[] filteredPassengers = new Passenger[filteredCount];
            int filteredIndex = 0;
            foreach (var p in passengers)
            {
                if (p.AvgWeight() > threshold)
                {
                    filteredPassengers[filteredIndex] = p;
                    filteredIndex++;
                }
            }

            Array.Sort(filteredPassengers);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var p in filteredPassengers)
                {
                    writer.WriteLine(p.ToString());
                }
            }
        }
    }
}
