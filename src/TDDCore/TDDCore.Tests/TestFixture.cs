using System;
using System.Collections.Generic;
namespace TDDCore.Tests
{
    using System.Text;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using FakeItEasy;
    using MediatR;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class TestFixture
    {
        private static readonly IConfigurationRoot _configuration;
        private static readonly IServiceScopeFactory _scopeFactory;

        static TestFixture()
        {
            var host = A.Fake<IHostingEnvironment>();            
            A.CallTo(() => host.ContentRootPath)
                .Returns("C:\\Users\\colinsmith1\\Source\\Repos\\tdd-aspnet-core\\src\\TDDCore\\TDDCore.Tests\\");
            //.Returns(Directory.GetCurrentDirectory());

            var startup = new Startup(host);
            _configuration = startup.Configuration;
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