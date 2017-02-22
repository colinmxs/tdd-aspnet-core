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
            private int v1;
            private int v2;
            private int v3;
            private int v4;

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
            public Task<int> Handle(Query message)
            {
                throw new NotImplementedException();
            }
        }
    }
}
