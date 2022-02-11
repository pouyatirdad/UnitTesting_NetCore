using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalPhotos.Controllers;
using PersonalPhotos.Models;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PersonalPhotos.test
{
    public class PhotosTest
    {
        [Fact]
        public async Task Upload_GivenFileName_ReturnsDisplayAction()
        {
            //Arrange
            var session = Mock.Of<ISession>();
            session.Set("User", Encoding.UTF8.GetBytes("test@gmail.com"));

            var httpContext = Mock.Of<HttpContext>(x => x.Session == session);
            var accessor = Mock.Of<IHttpContextAccessor>(x => x.HttpContext == httpContext);

            var fileStorage = Mock.Of<IFileStorage>();
            var keyGenerator = Mock.Of<IKeyGenerator>();
            var photoMedia = Mock.Of<IPhotoMetaData>();
            var fromFile = Mock.Of<IFormFile>();

            var model = Mock.Of<PhotoUploadViewModel>(x => x.File == fromFile);
            var controller = new PhotosController(keyGenerator, accessor, photoMedia, fileStorage);
            //Act

            var result = await controller.Upload(model) as RedirectToActionResult;

            //Assert
            Assert.Equal("Display", result.ActionName, ignoreCase: true);
        }
    }
}
