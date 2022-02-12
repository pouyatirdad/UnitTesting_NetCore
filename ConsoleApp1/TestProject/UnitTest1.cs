using ConsoleApp1;
using System;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        // in tdd first write test and next write other code
        private string MakeTestPassword(int leng, bool UperCase)
        {
            var res = "";
            for (int i = 0; i < leng; i++)
            {
                res += "a";
            }

            if (UperCase)
                res += "A";

            return res;
        }
        [Fact]
        public void Validate_GivenLongerThan8Char_ReturnTrue()
        {
            var model = new DefaultPasswordValidator();
            var Password =MakeTestPassword(8,true);
            var result = model.Validate(Password);

            Assert.True(result);
        }
        [Fact]
        public void Validate_GivenShorterThan8Char_ReturnFalse()
        {
            var model = new DefaultPasswordValidator();
            var Password = MakeTestPassword(6, true);
            var result = model.Validate(Password);

            Assert.False(result);
        }
        [Fact]
        public void Validate_GivenUpperCase_ReturnTrue()
        {
            var model = new DefaultPasswordValidator();
            var Password = MakeTestPassword(8, true);
            var result = model.Validate(Password);

            Assert.True(result);
        }
        [Fact]
        public void Validate_GivenNoUpperCase_ReturnFalse()
        {
            var model = new DefaultPasswordValidator();
            var Password = MakeTestPassword(8, false);
            var result = model.Validate(Password);

            Assert.False(result);
        }

    }
}
