using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TDDCore.Features.Calculator
{
    public class Sum
    {
        public class Query : IRequest<int>
        {
            internal int[] Ints;

            public Query(params int[] ints)
            {
                Ints = ints;
            }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, int>
        {
            public async Task<int> Handle(Query message)
            {
                var sum = 0;
                foreach (var @int in message.Ints)
                {
                    sum = sum + @int;
                }
                return sum;
            }
        }
    }
}
