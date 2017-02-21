using Xunit;
using TDDCore.Domain;
using Shouldly;
using static TDDCore.Tests.TestFixture;
using System.Threading.Tasks;
using TDDCore.Features.Calculator;

namespace TDDCore.Tests
{
    public class ExampleFeatureTest
    {
        [Fact]
        public void SumTwoNumbersTest()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(2, 2);
            result.ShouldBe(4);
        }

        [Fact]
        public void SumThreeNumbersTest()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(2, 2, 2);
            result.ShouldBe(6);
        }

        [Fact]
        public void SumFourNumbersTest()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(2, 2, 2, 3);
            result.ShouldBe(9);
        }

        [Fact]
        public async Task SumQueryTest()
        {            
            var query = new Sum.Query(2, 4, 8, 10);
            var result = await SendAsync(query);
            result.ShouldBe(24);

            query = new Sum.Query(2, 3);
            result = await SendAsync(query);
            result.ShouldBe(5);
        }
    }
}
