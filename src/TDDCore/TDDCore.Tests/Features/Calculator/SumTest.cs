using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDCore.Features.Calculator;
using static TDDCore.Tests.TestFixture;

namespace TDDCore.Tests.Features.Calculator
{
    [TestClass]
    public class SumTest
    {
        [TestMethod]
        public async Task Sum3Number()
        {
            var query = new Sum.Query(2, 2);
            var result = await SendAsync(query);
            result.ShouldBe(4);
        }
        [TestMethod]
        public async Task Sum2Number()
        {
            var query = new Sum.Query(2, 3, 9);
            var result = await SendAsync(query);
            result.ShouldBe(14);
        }
        [TestMethod]
        public async Task Sum4Number()
        {
            var query = new Sum.Query(4,5,21,19);
            var result = await SendAsync(query);
            result.ShouldBe(49);
        }
    }
}
