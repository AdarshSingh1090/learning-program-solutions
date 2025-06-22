using System;

class Program
{
    static void Main(string[] args)
    {
        double initialValue = 1000;
        double growthRate = 0.05; // 5% annual growth
        int years = 5;

        double futureValue = Forecast.RecursiveForecast(initialValue, growthRate, years);
        Console.WriteLine($"Future value after {years} years: {futureValue:F2}");
    }
}
