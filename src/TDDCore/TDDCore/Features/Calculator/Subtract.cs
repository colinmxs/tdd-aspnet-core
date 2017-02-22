using System;
using System.Threading.Tasks;
using MediatR;

namespace TDDCore.Features.Calculator
{
    public class Subtract
    {
        public class Query : IRequest<int>
        {
            internal int v1;
            internal int v2;
            internal int v3;
            internal int v4;

            public Query(int v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }

            public Query(int v1, int v2, int v3)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.v3 = v3;
            }

            public Query(int v1, int v2, int v3, int v4)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.v3 = v3;
                this.v4 = v4;
            }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, int>
        {
            public async Task<int> Handle(Query message)
            {
                return message.v1 - message.v2 - message.v3 - message.v4;
            }
        }
    }
}
