using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDDCore.Domain
{
    public class Calculator
    {        
        public int Calculate(params int[] ints)
        {
            var sum = 0;
            foreach (var @int in ints)
            {
                sum = sum + @int;
            }

            return sum;
        }
    }
}
