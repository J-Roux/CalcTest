

namespace PelengTestCalculator
{
    public delegate double OperationAction(params double[] args);

    class Operation : IOperation
    {
        private  OperationAction op;

        public Operation(OperationAction op)
        {
            this.op = op;
        }

        double IOperation.Call(params double[] args)
        {
            return op(args);
        }
    }


}
