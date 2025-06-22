public class Forecast
{
    public static double RecursiveForecast(double currentValue, double rate, int years)
    {
        if (years == 0)
            return currentValue;
        return RecursiveForecast(currentValue * (1 + rate), rate, years - 1);
    }
}