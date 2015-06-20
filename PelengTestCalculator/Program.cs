using System;
using System.Collections.Generic;

namespace PelengTestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>
            {
                {"+", new Operations(Arithmetic.Sum)},
                {"-", new Operations(Arithmetic.Sub)},
                {"/", new Operations(Arithmetic.Div)},
                {"*", new Operations(Arithmetic.Mul)},
                {"cos", new Operations(Arithmetic.Cos)},
                {"sin", new Operations(Arithmetic.Sin)},
                {"atan2", new Operations(Arithmetic.Atan2)}
            };
            while (true)
            {
                try
                {
                    Console.Write("op: ");
                    String command = Console.ReadLine();
                    if(command == "exit")
                        break;
                    Console.Write("args: ");
                    String arguments = Console.ReadLine();
                    string[] argStrings = arguments.Split(' ');
                    double[] argsDoubles = new double[argStrings.Length];
                    for (int i = 0; i < argStrings.Length; i++)
                    {
                        argsDoubles[i] = Convert.ToDouble(argStrings[i]);
                    }
                    Console.WriteLine(dictionary[command].Call(argsDoubles));
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Invalid arguments");
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Invalid arguments");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid arguments");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid operation");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
