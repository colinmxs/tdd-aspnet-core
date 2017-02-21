using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDDCore.Domain
{
    public class Calculator
    {
        public object Calculate(int v1, int v2)
        {
            return v1 + v2;
        }

        public object Calculate(int v1, int v2, int v3)
        {
            return v1 + v2 + v3;
        }

        public object Calculate(int v1, int v2, int v3, int v4)
        {
            return v1 + v2 + v3 + v4;
        }
    }
}
