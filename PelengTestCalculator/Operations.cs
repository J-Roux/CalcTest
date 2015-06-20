

namespace PelengTestCalculator
{
    public delegate double Operation(params double[] args);

    class Operations : IOperation
    {
        private Operation op;

        public Operations(Operation op)
        {
            this.op = op;
        }

        double IOperation.Call(params double[] args)
        {
            return op(args);
        }
    }


}
