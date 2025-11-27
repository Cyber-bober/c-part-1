using System;

struct SPoint
{
    public double x;
    public double y;

    public SPoint(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double Distance()
    {
        return x * x + y * y;  //return Math.Sqrt(x * x + y * y); cost much
    }
}

class Program
{
    static void Main()
    {
        SPoint[] points = {
            new SPoint(3, 4),
            new SPoint(-1, 2),
            new SPoint(0, 1),
            new SPoint(5, -5),
            new SPoint(-2, -3)
        };

        if (points.Length == 0)
        {
            Console.WriteLine("Множество точек пусто.");
            return;
        }

        int index = 0;
        double minDistance = points[0].Distance();

        for (int i = 1; i < points.Length; i++)
        {
            double Distance1 = points[i].Distance();
            if (Distance1 < minDistance)
            {
                minDistance = Distance1;
                index = i;
            }
        }

        SPoint closestPoint = points[index];
        Console.WriteLine($"Точка, наименее удаленная от начала координат: ({closestPoint.x}, {closestPoint.y})");
    }
}
