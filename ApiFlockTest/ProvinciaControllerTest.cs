using ApiFlock.Controllers;
using ApiFlock.Dtos;
using ApiFlock.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiFlockTest
{
    public class ProvinciaControllerTest
    {
        [Fact]
        public void Get_Data_OK()
        {
            var serviceMock = new Mock<IProvinciaService>();

            string nombreProvincia = "Entre Rios";

            serviceMock
             .Setup(x => x.GetLocation(nombreProvincia))
             .ReturnsAsync(new List<ProvinciaResponseDto>() { new ProvinciaResponseDto() { Nombre = nombreProvincia, Longitud = "-59.2014475514635", Latitud = "-32.0588735436448" } });

            var loggerMock = new Mock<ILogger<ProvinciaController>>();

            var controller = new ProvinciaController(loggerMock.Object, serviceMock.Object);

            var result = (ObjectResult)controller.GetData(nombreProvincia).Result;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }


        [Fact]
        public void Get_Data_OK_Varias_Provincias()
        {
            var serviceMock = new Mock<IProvinciaService>();

            string nombreProvincia = "Santa";

            var provinciaDto = GetProvinciaDto();


            serviceMock
             .Setup(x => x.GetLocation(nombreProvincia))
             .ReturnsAsync(provinciaDto);

            var loggerMock = new Mock<ILogger<ProvinciaController>>();

            var controller = new ProvinciaController(loggerMock.Object, serviceMock.Object);

            var result = (ObjectResult)controller.GetData(nombreProvincia).Result;

            var lstProvincias = (List<ProvinciaResponseDto>)result.Value;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(provinciaDto.Count, lstProvincias.Count);
        }

        [Fact]
        public void Get_Data_Provincia_No_Encontrada()
        {
            var serviceMock = new Mock<IProvinciaService>();

            string nombreProvincia = "Madrid";

            serviceMock
             .Setup(x => x.GetLocation(nombreProvincia))
             .ReturnsAsync(new List<ProvinciaResponseDto>());

            var loggerMock = new Mock<ILogger<ProvinciaController>>();

            var controller = new ProvinciaController(loggerMock.Object, serviceMock.Object);

            var result = (ObjectResult)controller.GetData(nombreProvincia).Result;

            Assert.Equal(((int)HttpStatusCode.NotFound), result.StatusCode);
        }


        private List<ProvinciaResponseDto> GetProvinciaDto()
        {
            return new List<ProvinciaResponseDto>() {
                 new ProvinciaResponseDto() { Nombre = "Santa Fe", Longitud = "-60.9498369430241", Latitud = "-30.7069271588117" },
                 new ProvinciaResponseDto() { Nombre = "Santa Cruz", Longitud = "-69.9557621671973", Latitud = "-48.8154851827063" }
             };
        }

    }
}
