using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            float A;
            A = 5.5F;
            string B="any%";
            object C;
            C = B.GetType();

            Console.WriteLine($"Переменная А: {A}  Переменная Б: {B} Переменная С: {C} ");
        }
    }
}
