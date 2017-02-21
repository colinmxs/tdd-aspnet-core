using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TDDCore.Tests
{
    public class TestFixture
    {
        private static readonly IServiceScopeFactory _scopeFactory;

        static TestFixture()
        {
            var host = A.Fake<IHostingEnvironment>();
            var startup = new Startup(host);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            _scopeFactory = provider.GetService<IServiceScopeFactory>();
        }
        public static async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                try
                {
                    await action(scope.ServiceProvider);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                try
                {
                    var result = await action(scope.ServiceProvider);
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }
        public static Task SendAsync(IRequest request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

    }
}
