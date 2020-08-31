using System;

namespace Testing_Project
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var val = Urgency.High;
            Console.WriteLine(val.ToString());
        }
    }

    public enum Urgency
    {
        VeryHigh = 1,
        High = 2,
        Low = 4
    }
}
