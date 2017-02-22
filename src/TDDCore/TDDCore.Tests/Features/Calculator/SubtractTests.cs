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
    public class SubtractTests
    {
        [TestMethod]
        public async Task Subtract2Digits()
        {
            var query = new Subtract.Query(2, 2);
            var results = await SendAsync(query);
            results.ShouldBe(0);
        }
        [TestMethod]
        public async Task Subtract3Digits()
        {
            var query = new Subtract.Query(20, 2, 10);
            var results = await SendAsync(query);
            results.ShouldBe(8);
        }
        [TestMethod]
        public async Task Subtract4Digits()
        {
            var query = new Subtract.Query(40, 10, 10, 10);
            var results = await SendAsync(query);
            results.ShouldBe(10);
        }
    }
}
