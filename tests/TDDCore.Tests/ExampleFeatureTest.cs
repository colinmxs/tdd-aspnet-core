using Xunit;
using TDDCore.Domain;
using Shouldly;

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
    }
}
