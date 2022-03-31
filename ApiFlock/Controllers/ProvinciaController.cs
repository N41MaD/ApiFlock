using ApiFlock.Dtos;
using ApiFlock.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiFlock.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProvinciaService _provinciaService;

        public ProvinciaController(ILogger<ProvinciaController> logger, IProvinciaService provinciaService)
        {
            _logger = logger;
            _provinciaService = provinciaService;
        }

        [HttpGet]
        [Route("GetProvinceLocalization/{nombre}")]
        public async Task<IActionResult> GetData(string nombre)
        {
            _logger.LogInformation($"Start GetData...");

            var response = await _provinciaService.GetLocation(nombre);

            _logger.LogInformation($"Result GetData {GetType()}: {JsonConvert.SerializeObject(response)}");

            if(response == null)
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(StatusCodes.Status400BadRequest, "Ocurrió un error al consultar la api"));

            if (response.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse(StatusCodes.Status404NotFound, "Provincia no encontrada"));

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
