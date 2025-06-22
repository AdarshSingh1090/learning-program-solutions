using System;

public class Logger
{
    private static Logger? instance = null;
    private static readonly object lockObj = new object();

    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                    instance = new Logger();
            }
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}