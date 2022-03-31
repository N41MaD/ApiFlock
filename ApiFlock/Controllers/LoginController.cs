
using ApiFlock.Dtos;
using ApiFlock.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApiFlock.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILoginService _service;

        public LoginController(ILogger<LoginController> logger, ILoginService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequestDto model)
        {
            _logger.LogInformation($"Start Login...");

            if (string.IsNullOrEmpty(model?.Email) || string.IsNullOrEmpty(model?.Password))
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(StatusCodes.Status400BadRequest, "Email and password can not be null"));
            

            var response = _service.Login(model);


            _logger.LogInformation($"Result Login {GetType()}: {JsonConvert.SerializeObject(response)}");

            if(response?.Token == null)
                return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse(StatusCodes.Status404NotFound, "User Not Found"));
            
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
