using ApiFlock.Controllers;
using ApiFlock.Dtos;
using ApiFlock.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using Xunit;

namespace ApiFlockTest
{
    public class LoginControllerTest
    {
        [Fact]
        public void Login_OK()
        {
            var serviceMock = new Mock<ILoginService>();

            var model = new LoginRequestDto()
            {
                Email = "test@test.com.ar",
                Password = "Test1234!"
            };

            serviceMock
             .Setup(x => x.Login(model))
             .Returns(new LoginResponseDto() { Token = "aasdasddsasdasdasdasd", ExpirateDate = DateTime.UtcNow.AddHours(1).ToString()});

            var loggerMock = new Mock<ILogger<LoginController>>();

            var controller = new LoginController(loggerMock.Object, serviceMock.Object);

            var result = (ObjectResult)controller.Login(model);

            Assert.Equal(((int)HttpStatusCode.OK), result.StatusCode);
        }


        [Fact]
        public void Login_User_Not_Found()
        {
            var serviceMock = new Mock<ILoginService>();

            var model = new LoginRequestDto()
            {
                Email = "user@test.com.ar",
                Password = "Test123422!"
            };


            serviceMock
             .Setup(x => x.Login(model))
             .Returns(new LoginResponseDto());

            var loggerMock = new Mock<ILogger<LoginController>>();

            var controller = new LoginController(loggerMock.Object, serviceMock.Object);

            var result = (ObjectResult)controller.Login(model);

            Assert.Equal(((int)HttpStatusCode.NotFound), result.StatusCode);
        }

        [Fact]
        public void Login_User_Bad_Request()
        {
            var serviceMock = new Mock<ILoginService>();

            var model = new LoginRequestDto()
            {
                Password = "Test123422!"
            };


            serviceMock
             .Setup(x => x.Login(model))
             .Returns(new LoginResponseDto());

            var loggerMock = new Mock<ILogger<LoginController>>();

            var controller = new LoginController(loggerMock.Object, serviceMock.Object);

            var result = (ObjectResult)controller.Login(model);

            Assert.Equal(((int)HttpStatusCode.BadRequest), result.StatusCode);
        }
    }
}
