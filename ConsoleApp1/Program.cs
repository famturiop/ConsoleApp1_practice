using System;
using System.Reflection;

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
            Type D;
            D = C.GetType();

            Console.WriteLine($"Переменная А: {A}  Переменная Б: {B} Переменная С: {C} Переменная D: {D} ");
        }
    }
}
