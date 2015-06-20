using System;
using System.Linq;

namespace PelengTestCalculator
{
    public static class Arithmetic
    {
        public static double Sum(params double[] args)
        {
            return args.Sum();
        }

        public static double Mul(params double[] args)
        {
            return args.Aggregate<double, double>(1, (current, t) => current*t);
        }

        public static double Sub(params double[] args)
        {
            if (args.Length <= 2)
            {
                return args[0] - args[1];
            }
            throw new ArgumentException("Incorrect number of arguments for subtraction");
        }

        public static double Div(params double[] args)
        {
            if (args.Length <= 2)
            {
                return args[0] / args[1];
            }
            throw new ArgumentException("Incorrect number of arguments for division");
        }

        public static double Sin(params double[] args)
        {
            if (args.Length <= 1)
            {
                return Math.Sin(args[0]);
            }
            throw new ArgumentException("Incorrect number of arguments for sin");
        }

        public static double Cos(params double[] args)
        {
            if (args.Length <= 1)
            {
                return Math.Cos(args[0]);
            }
            throw new ArgumentException("Incorrect number of arguments for cos");
        }

        public static double Atan2(params double[] args)
        {
            if (args.Length <= 2)
            {
                return Math.Atan2(args[0], args[1]);
            }
            throw new ArgumentException("Incorrect number of arguments for atan2");
        }

    }
}
