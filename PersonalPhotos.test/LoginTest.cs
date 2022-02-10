using Xunit;
using Moq;
using PersonalPhotos.Controllers;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalPhotos.Models;
using System.Threading.Tasks;
using Core.Models;

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

            var session = Mock.Of<ISession>();
            var httpsContext = Mock.Of<HttpContext>(x => x.Session == session);

            _accessor = new Mock<IHttpContextAccessor>();
            _accessor.Setup(x => x.HttpContext).Returns(httpsContext);

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
            Assert.Equal("Login", result.ViewName, ignoreCase: true);
        }
        [Fact]
        public async Task Login_GivenModelStateInvalid_ReturnLoginView()
        {
            _controller.ModelState.AddModelError("Test", "Test");

            var result = await _controller.Login(Mock.Of<LoginViewModel>()) as ViewResult;
            Assert.Equal("Login", result.ViewName, ignoreCase: true);
        }
        [Fact]
        public async Task Login_GivenCorrectPassword_RedirectoDisplayAction()
        {

            /*
              
             tip :

            if you want test a method , everything in method should be mock

            ,

            if clear one below line test not work , because the method need this , you must see login method

            */

            const string pass = "Test1234";
            var modelView = Mock.Of<LoginViewModel>(x => x.Email == "test@gmail.com" && x.Password == pass);
            var model = Mock.Of<User>(x => x.Password == pass);

            _logins.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(model);

            var result = await _controller.Login(modelView);

            Assert.IsType<RedirectToActionResult>(result);
        }

        // practice : write test for ,if the user password is incorect 
        [Fact]
        public async Task Login_GivenInCorrectPassword_RedirecToLogin()
        {
            const string CorrectPassword = "Test1234";
            const string InCorrectPassword = "Test123";

            var modelView = Mock.Of<LoginViewModel>(x => x.Email == "test@gmail.com" && x.Password == CorrectPassword);
            var model = Mock.Of<User>(x => x.Password == InCorrectPassword);

            _logins.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(model);

            var result = await _controller.Login(modelView) as ViewResult;

            Assert.Equal("Login",result.ViewName,ignoreCase:true);
        }
    }
}
