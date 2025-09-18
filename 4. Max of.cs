using System;
namespace Example
{
    class program
    {
        static void Main()
        {
            Console.Write("Enter number. N =  ");
            int N = int.Parse(Console.ReadLine());
            if (N < 10 || N > 99)
            {
                Console.WriteLine("Error");
                return;
            }
            int first = N / 10;
            int second = N % 10;
            int Max = (first > second) ? first : second;

            Console.Write("Max = ");
            Console.WriteLine(Max);
            Console.WriteLine("Max = {0}", Max);
            Console.ReadKey();   //чтоб окно не вылетало
        }
    }
}
