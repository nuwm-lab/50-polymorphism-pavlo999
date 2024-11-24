using System;

class LinearFunction
{
    protected double a1, a0;

    // Віртуальний метод для задання коефіцієнтів лінійної функції (лише для a1 і a0)
    public virtual void SetCoefficients(double a1, double a0)
    {
        this.a1 = a1;
        this.a0 = a0;
    }

    // Віртуальний метод для виведення коефіцієнтів лінійної функції
    public virtual void PrintCoefficients()
    {
        Console.WriteLine($"Лінійна функція: f(x) = {a1}x + {a0}");
    }

    // Віртуальний метод для обчислення значення лінійної функції в точці x
    public virtual double CalculateValue(double x)
    {
        return a1 * x + a0;
    }
}

class Polynomial : LinearFunction
{
    private double a2, a3, a4;

    // Створюємо новий метод для задання коефіцієнтів багаточлена (не перевизначаємо метод із базового класу)
    public void SetCoefficients(double a4, double a3, double a2, double a1, double a0)
    {
        this.a4 = a4;
        this.a3 = a3;
        this.a2 = a2;
        base.SetCoefficients(a1, a0); // Викликаємо метод базового класу для a1 та a0
    }

    // Перевизначений метод для виведення коефіцієнтів багаточлена
    public override void PrintCoefficients()
    {
        Console.WriteLine($"Багаточлен: f(x) = {a4}x^4 + {a3}x^3 + {a2}x^2 + {a1}x + {a0}");
    }

    // Перевизначений метод для обчислення значення багаточлена в точці x
    public override double CalculateValue(double x)
    {
        return a4 * Math.Pow(x, 4) + a3 * Math.Pow(x, 3) + a2 * Math.Pow(x, 2) + a1 * x + a0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Динамічне створення об'єкта
        LinearFunction function;

        // Вибір типу функції користувачем
        Console.WriteLine("Оберіть тип функції: 1 - лінійна, 2 - багаточлен");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            function = new LinearFunction(); // Створюємо лінійну функцію
        }
        else
        {
            function = new Polynomial(); // Створюємо багаточлен
        }

        // Задання коефіцієнтів
        if (choice == 1)
        {
            Console.WriteLine("Задайте коефіцієнти для лінійної функції (a1 та a0):");
            double a1 = double.Parse(Console.ReadLine());
            double a0 = double.Parse(Console.ReadLine());
            function.SetCoefficients(a1, a0);
        }
        else
        {
            Console.WriteLine("Задайте коефіцієнти для багаточлена (a4, a3, a2, a1, a0):");
            double a4 = double.Parse(Console.ReadLine());
            double a3 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double a1 = double.Parse(Console.ReadLine());
            double a0 = double.Parse(Console.ReadLine());
            ((Polynomial)function).SetCoefficients(a4, a3, a2, a1, a0); // Важливо привести до типу Polynomial
        }

        // Виведення коефіцієнтів та обчислення значення в точці
        function.PrintCoefficients();
        Console.Write("Введіть точку x для обчислення значення функції: ");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine($"Значення функції в точці {x} = {function.CalculateValue(x)}");

        Console.ReadLine(); // Для затримки програми
    }
}
