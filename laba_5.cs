using System;

public class TTriangle
{
    private double a, b, c;

    public TTriangle()
    {
        a = 0;
        b = 0;
        c = 0;
    }

    public TTriangle(double a, double b, double c)
    {
        if (IsValidTriangle(a, b, c))
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else
        {
            throw new ArgumentException("Неможливо створити трикутник з такими сторонами.");
        }
    }

    public TTriangle(TTriangle other)
    {
        this.a = other.a;
        this.b = other.b;
        this.c = other.c;
    }

    public void InputSides()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Введіть довжини сторін трикутника:");
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                c = double.Parse(Console.ReadLine());

                if (!IsValidTriangle(a, b, c))
                {
                    throw new ArgumentException("Неможливо створити трикутник з такими сторонами.");
                }
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + " Повторіть спробу.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка формату введення. Введіть числові значення.");
            }
        }
    }

    public void DisplaySides()
    {
        Console.WriteLine($"Сторони трикутника: a = {a}, b = {b}, c = {c}");
    }

    public double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public double Perimeter()
    {
        return a + b + c;
    }

    public bool IsLargerThan(TTriangle other)
    {
        return this.Area() > other.Area();
    }

    public static TTriangle operator +(TTriangle t1, TTriangle t2)
    {
        return new TTriangle(t1.a + t2.a, t1.b + t2.b, t1.c + t2.c);
    }

    public static TTriangle operator -(TTriangle t1, TTriangle t2)
    {
        return new TTriangle(t1.a - t2.a, t1.b - t2.b, t1.c - t2.c);
    }

    public static TTriangle operator *(TTriangle t, double multiplier)
    {
        return new TTriangle(t.a * multiplier, t.b * multiplier, t.c * multiplier);
    }

    private bool IsValidTriangle(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TTriangle triangle1 = new TTriangle(3, 4, 5);
        triangle1.DisplaySides();
        Console.WriteLine($"Площа трикутника: {triangle1.Area()}");
        Console.WriteLine($"Периметр трикутника: {triangle1.Perimeter()}");

        TTriangle triangle2 = new TTriangle(6, 8, 10);
        Console.WriteLine($"Трикутник 2 більший за трикутник 1: {triangle2.IsLargerThan(triangle1)}");

        TTriangle triangle3 = new TTriangle();
        triangle3.InputSides();
        triangle3.DisplaySides();
        Console.WriteLine($"Площа трикутника: {triangle3.Area()}");

        TTriangle sumTriangle = triangle1 + triangle2;
        sumTriangle.DisplaySides();
        TTriangle scaledTriangle = triangle1 * 2;
        scaledTriangle.DisplaySides();
    }
}
