using ConsoleApp1;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Add_GivenTwoInt_ReturnInt()
        {
            var calc = new Calculator();
            var result = calc.Add(2,3);
            Assert.Equal(5,result);
        }
    }
}
