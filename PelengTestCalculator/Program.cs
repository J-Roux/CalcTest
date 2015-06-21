using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;


namespace PelengTestCalculator
{
    class Program
    {

        public static double ExitFunc(params double[] args)
        {
           Environment.Exit(0);
           return 0;
        }

        public static Dictionary<String, IOperation> operations = new Dictionary<string, IOperation>
            {
                {"+", new Operations(Arithmetic.Sum)},
                {"-", new Operations(Arithmetic.Sub)},
                {"/", new Operations(Arithmetic.Div)},
                {"*", new Operations(Arithmetic.Mul)},
                {"cos", new Operations(Arithmetic.Cos)},
                {"sin", new Operations(Arithmetic.Sin)},
                {"atan2", new Operations(Arithmetic.Atan2)},
                {"exit", new Operations(ExitFunc)}
            };
 

        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.Write("op: ");
                    var operation = ReadCommand();
                    Console.Write("args: ");
                    var arguments = ReadArguments();
                    Console.WriteLine(operation.Call(arguments));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static double[] ReadArguments()
        {
            try
            {
                var arguments = Console.ReadLine();
                return  arguments.Trim()
                                 .ToLower()
                                 .Split(' ')
                                 .Select(double.Parse)
                                 .ToArray();
            }
            catch (Exception exception)
            {
                throw new ArgumentException("Incorrect arguments", exception);
            }
        }

        private static IOperation ReadCommand()
        {
            var command = Console.ReadLine();
            if (!String.IsNullOrEmpty(command))
            {
                command = command.Trim();
                if (operations.ContainsKey(command))
                {
                    return operations[command];
                }
            }
            throw new ArgumentException("Incorrect operation");
        }
    }
}
