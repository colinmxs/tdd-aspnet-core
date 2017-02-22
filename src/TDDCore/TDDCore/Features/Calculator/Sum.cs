using System;
using System.Threading.Tasks;
using MediatR;
namespace TDDCore.Features.Calculator
{
    public class Sum
    {
        public class Query : IRequest<int>
        {
            internal int[] _ints;

            public Query(params int[] ints)
            {
                _ints = ints;
            }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, int>
        {
            public async Task<int> Handle(Query message)
            {
                var sum = 0;
                foreach (var @int in message._ints)
                {
                    sum = sum + @int;
                }
                return sum;
            }
        }
    }
}
