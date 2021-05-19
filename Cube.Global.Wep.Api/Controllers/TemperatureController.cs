using System;
using Cube.Global.Temperature.Core.Models;
using Cube.Global.Temperature.Wep.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cube.Global.Wep.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;
        private ITemperatureService _temperatureService;

        public TemperatureController(ILogger<TemperatureController> logger, ITemperatureService temperatureService)
        {
            _logger = logger;
            _temperatureService = temperatureService;
        }

        [HttpGet("{type}/{temperature}")]
        public TemperatureDTO ConvertTemperature(string type, double temperature)
        {
            try
            {
                if (double.TryParse(temperature.ToString(), out double temperatureValue))
                {
                    var temperatureDto = _temperatureService.Convert(temperature, type);

                    return temperatureDto;
                }
                else
                {
                    throw new Exception($"Invalid temperature has been provided {nameof(temperature)}");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
