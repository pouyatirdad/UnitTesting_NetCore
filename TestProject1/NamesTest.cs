using ConsoleApp1;
using Xunit;

namespace TestProject1
{
    public class NamesTest
    {
        [Fact]
        public void FullNameTest()
        {
            var name = new AddName();
            var result = name.MakeFullName("Pouya","Tirdad");
            Assert.Equal("Pouya Tirdad", result);
            //case sensetive
            //Assert.Equal("pouya tirdad",result,ignoreCase:true);
            //contains
            //Assert.Contains("Pouya", result);
            //contains ignore case sensetive
            //Assert.Contains("Pouya", result,System.StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
