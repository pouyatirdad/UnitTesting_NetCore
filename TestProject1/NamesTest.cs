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
        [Fact]
        public void NickName_ReturnFalseAlways()
        {
            var name = new AddName();
            var result = name.NickName;
            Assert.Null(result);
        }
        [Fact]
        public void NickName_ReturnTrueAlways()
        {
            var name = new AddName();
            name.NickName = "Jack";
            var result = name.NickName;
            Assert.NotNull(result);
        }
        [Fact]
        public void MakeFullName_ReturnAlwaysNull()
        {
            var name = new AddName();
            var result = name.MakeFullName("", "");
            // not work because string always have value ""
            //Assert.Null(result); 
            // it should work
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
