using System;
using CsharpVjestina.Dz1.Zadatak1;
using CsharpVjestina.Dz1.Zadatak2;

namespace CsharpVjestina.Dz1
{
    class MainClass
    {
        static void Main()
        {
            // 1. Zadatak
            Console.WriteLine("******* 1. Zadatak *******");

            IntegerList test = new IntegerList();
            test.ListExample(test);

            // 2. Zadatak
            Console.WriteLine("\n******* 2. Zadatak *******");

            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("!");

            Console.WriteLine(stringList.Count); // 3
            Console.WriteLine(stringList.Contains("Hello")); // true
            Console.WriteLine(stringList.IndexOf("Hello")); // 0
            Console.WriteLine(stringList.GetElement(1)); // World

            IGenericList<double> doubleList = new GenericList<double>();
            doubleList.Add(0.2);
            doubleList.Add(0.7);
            doubleList.Add(3.7);
            Console.WriteLine(doubleList.Remove(0.7)); // true
            Console.WriteLine(doubleList.Count); // 2
            doubleList.Clear();
            Console.WriteLine(doubleList.Count); // 0

            // 4. Zadatak
            Console.WriteLine("\n******* 4. Zadatak *******");

            foreach (string value in stringList)
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();

        }
    }
}
