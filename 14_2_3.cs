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
            return TotalWeight / ItemCount;
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
        static void Main()
        {
            using (StreamReader reader = new StreamReader("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/14_2_3/ConsoleApp1/input.txt"))
            {
                double threshold = double.Parse(reader.ReadLine().Replace('.', ','));

                string line;
                Passenger[] passengers = new Passenger[100]; 
                int total = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(';');
                    if (parts.Length != 3) continue;

                    string name = parts[0].Trim();
                    int count = int.Parse(parts[1]);
                    double weight = double.Parse(parts[2].Replace('.', ','));

                    passengers[total] = new Passenger(name, count, weight);
                    total++;
                }

                Passenger[] selected = new Passenger[total];
                int selectedCount = 0;

                for (int i = 0; i < total; i++)
                {
                    if (passengers[i].AvgWeight() > threshold)
                    {
                        selected[selectedCount] = passengers[i];
                        selectedCount++;
                    }
                }
                Passenger[] result = new Passenger[selectedCount];
                for (int i = 0; i < selectedCount; i++)
                {
                    result[i] = selected[i];
                }

                Array.Sort(result);

                using (StreamWriter writer = new StreamWriter("E:/study/ВУЗ/3 семестр/структура данных и алгоритмы/code3smtr/14_2_3/ConsoleApp1/output.txt"))
                {
                    foreach (Passenger p in result)
                    {
                        writer.WriteLine(p.ToString());
                    }
                }
            }
        }
    }
}
