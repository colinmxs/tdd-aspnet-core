using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading.Tasks;
using TDDCore.Features.Calculator;
using static TDDCore.Tests.TestFixture;

namespace TDDCore.Tests.Features.Calculator
{
    [TestClass]
    public class SumTests
    {
        [TestMethod]
        public async Task Sum2Digits()
        {
            var query = new Sum.Query(2, 2);
            var results = await SendAsync(query);
            results.ShouldBe(4);
        }
        [TestMethod]
        public async Task Sum3Digits()
        {
            var query = new Sum.Query(2, 3, 9);
            var results = await SendAsync(query);
            results.ShouldBe(14);
        }
        [TestMethod]
        public async Task Sum4Digits()
        {
            var query = new Sum.Query(4, 5, 21, 19);
            var results = await SendAsync(query);
            results.ShouldBe(49);
        }
    }
}
