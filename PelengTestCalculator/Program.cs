using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
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
                {"+", new Operation(Arithmetic.Sum)},
                {"-", new Operation(Arithmetic.Sub)},
                {"/", new Operation(Arithmetic.Div)},
                {"*", new Operation(Arithmetic.Mul)},
                {"cos", new Operation(Arithmetic.Cos)},
                {"sin", new Operation(Arithmetic.Sin)},
                {"atan2", new Operation(Arithmetic.Atan2)},
                {"exit", new Operation(ExitFunc)}
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
                                 .Select( number => double.Parse(number, CultureInfo.InvariantCulture))
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
