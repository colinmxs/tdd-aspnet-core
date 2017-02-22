using System;
using System.Threading.Tasks;
using MediatR;

namespace TDDCore.Features.Calculator
{
    public class Subtract
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
                var difference = message.Ints[0];
                for(var i = 1; i < message.Ints.Length; i++)
                {
                    difference = difference - message.Ints[i];
                }
                return difference;
            }
        }
    }
}
