using System;
using System.Collections.Generic;
using System.Linq;

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static double Distance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }
}

public class Polygon
{
    private Point[] vertices;

    public Polygon(Point[] points)
    {
        if (points.Length < 3)
            throw new ArgumentException("Багатокутник повинен мати принаймні 3 вершини.");
        vertices = points;
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= vertices.Length)
                throw new IndexOutOfRangeException("Некоректний індекс сторони.");
            
            Point p1 = vertices[index];
            Point p2 = vertices[(index + 1) % vertices.Length]; // Замикаємо останню точку з першою
            return Point.Distance(p1, p2);
        }
    }

    public double GetPerimeter()
    {
        double perimeter = 0;
        for (int i = 0; i < vertices.Length; i++)
        {
            perimeter += this[i]; // Використовуємо наш індексатор
        }
        return perimeter;
    }

    public double GetArea()
    {
        double area = 0;
        int n = vertices.Length;
        for (int i = 0; i < n; i++)
        {
            area += (vertices[i].X * vertices[(i + 1) % n].Y);
            area -= (vertices[(i + 1) % n].X * vertices[i].Y);
        }
        return Math.Abs(area) / 2.0;
    }

    public static Polygon InputPolygon()
    {
        Console.Write("Введіть кількість вершин: ");
        int n = int.Parse(Console.ReadLine());
        Point[] pts = new Point[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть X та Y для вершини {i + 1} (через пробіл): ");
            string[] parts = Console.ReadLine().Split(' ');
            pts[i] = new Point(double.Parse(parts[0]), double.Parse(parts[1]));
        }
        return new Polygon(pts);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Багатокутник з {vertices.Length} вершинами.");
        Console.WriteLine($"Периметр: {GetPerimeter():F2}");
        Console.WriteLine($"Площа: {GetArea():F2}");
        Console.WriteLine("Сторони:");
        for (int i = 0; i < vertices.Length; i++)
        {
            Console.WriteLine($"Сторона {i + 1}: {this[i]:F2}");
        }
    }
}