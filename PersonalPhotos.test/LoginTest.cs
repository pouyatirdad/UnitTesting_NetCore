using Xunit;
using Moq;
using PersonalPhotos.Controllers;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalPhotos.Models;
using System.Threading.Tasks;

namespace PersonalPhotos.test
{
    public class LoginTest
    {
        private readonly LoginsController _controller;
        private readonly Mock<ILogins> _logins;
        private readonly Mock<IHttpContextAccessor> _accessor;

        public LoginTest()
        {
            _logins = new Mock<ILogins>();
            _accessor = new Mock<IHttpContextAccessor>();
            _controller = new LoginsController(_logins.Object, _accessor.Object);
        }
        [Fact]
        public void Index_GivenNoReturnUrl_ReturnLoginView()
        {
            var result = (_controller.Index() as ViewResult);

            // we dont need this beacuse line 30 check it
            // Assert.IsAssignableFrom<IActionResult>(result);

            // we dont need because in line 24 we call that as viewresult
            //Assert.IsType(ViewResult);

            // these code can use on two test class
            Assert.NotNull(result);
            Assert.Equal("Login",result.ViewName,ignoreCase:true);
        }
        [Fact]
        public async Task Login_GivenModelStateInvalid_ReturnLoginView()
        {
            _controller.ModelState.AddModelError("Test","Test");

            var result = await _controller.Login(Mock.Of<LoginViewModel>()) as ViewResult;
            Assert.Equal("Login",result.ViewName,ignoreCase:true);
        }
    }
}
