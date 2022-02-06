using ConsoleApp1;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class FiboSeriesFixture
    {
        public Calculator Calc => new Calculator();
    }
    public class FiboSeriesTest : IClassFixture<FiboSeriesFixture>
    {
        private readonly FiboSeriesFixture _fiboSeriesFixture;
        public FiboSeriesTest(FiboSeriesFixture fiboSeriesFixture)
        {
            _fiboSeriesFixture = fiboSeriesFixture;
        }

        [Fact]
        [Trait("Category", "FiboSeries")]
        public void FiboSeriesNotContainsZero()
        {
            var fibo = _fiboSeriesFixture.Calc;
            var result = fibo.FiboSeries;
            Assert.All(result, n => Assert.NotEqual(0, n));
            //another way
            //Assert.DoesNotContain(0,result);
        }
        [Fact]
        [Trait("Category", "FiboSeries")]
        public void FiboSeriesContains13()
        {
            var fibo = _fiboSeriesFixture.Calc;
            var result = fibo.FiboSeries;
            Assert.Contains(13, result);
        }
        [Fact]
        [Trait("Category", "FiboSeries")]
        public void CheckFiboList()
        {
            var expectedFiboSeriesList = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var result = _fiboSeriesFixture.Calc.FiboSeries;
            Assert.Equal(expectedFiboSeriesList, result);
        }
    }
}
