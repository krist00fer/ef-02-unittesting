using System;
using System.Collections.Generic;

namespace EF2.UnitTesting
{
    public class RpnCalculator
    {
        Stack<double> internalStack = new Stack<double>();

        public double Result()
        {
            if (internalStack.Count == 0)
                return 0;

            return internalStack.Peek();
        }

        public void Push(double v)
        {
            internalStack.Push(v);
        }

        public double[] Stack()
        {
            return internalStack.ToArray();
        }

        public void Pop()
        {
            internalStack.Pop();
        }

        public void Clear()
        {
            internalStack.Clear();
        }

        public void Add()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v1 + v2);
        }

        public void Sub()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v2 - v1);
        }

        public void Mul()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v1 * v2);
        }

        public void Div()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v2 / v1);
        }

        private void ExecuteTwoValueOperator(Func<double, double, double> op)
        {
            double v1 = internalStack.Pop();
            double v2 = internalStack.Pop();

            var result = op(v1, v2);

            internalStack.Push(result);
        }

        public void Sqrt()
        {
            double v = internalStack.Pop();

            var result = Math.Sqrt(v);

            internalStack.Push(result);
        }
    }
}
