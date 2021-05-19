using System;
using Cube.Global.Temperature.Core.Implementation;
using Cube.Global.Temperature.Core.Interface;
using Cube.Global.Temperature.Wep.Api.Services;
using Cube.Global.Wep.Api.Controllers;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Cube.Global.Temperatture.Test
{
    public class TemperatureServiceTest
    {
        private ITemperatureService _temperatureService;
        private ICelsiusTemperature _celsiusTemperature;
        private IFahrenheitTemperature _fahrenheitTemperature;
        private IKelvinTemperature _kelvinTemperature;
        private TemperatureController _temperatureController;
        private readonly ILogger<TemperatureController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        const string Kelvin = "Kelvin";
        const string Celsius = "Celsius";
        const string Fahrenheit = "Fahrenheit";


        public TemperatureServiceTest()
        {
            _celsiusTemperature = new CelsiusTemperature();
            _fahrenheitTemperature = new FahrenheitTemperature();
            _kelvinTemperature = new KelvinTemperature();
            _temperatureService = new TemperatureService(_kelvinTemperature, _celsiusTemperature, _fahrenheitTemperature);
            _loggerFactory = new LoggerFactory();
            _logger = new Logger<TemperatureController>(_loggerFactory);
            _temperatureController = new TemperatureController(_logger, _temperatureService);
        }


        [Fact]
        public void TestKelvinTemperatureConversion()
        {
           var data = _temperatureController.ConvertTemperature(Kelvin, 122);
            Assert.Equal("-151.15°C", data.Celsius);
            Assert.Equal("122K", data.Kelvin);
            Assert.Equal("-240.07°F", data.Fahrenheit);
        }

        [Fact]
        public void TestCelsiusTemperatureConversion()
        {
            var data = _temperatureController.ConvertTemperature(Celsius, 322);
            Assert.Equal("322°C", data.Celsius);
            Assert.Equal("595.15K", data.Kelvin);
            Assert.Equal("353°F", data.Fahrenheit);
        }

        [Fact]
        public void TestFahrennheitTemperatureConversion()
        {
            var data = _temperatureController.ConvertTemperature(Fahrenheit, 445);
            Assert.Equal("229.44°C", data.Celsius);
            Assert.Equal("502.59K", data.Kelvin);
            Assert.Equal("445°F", data.Fahrenheit);
        }


        [Fact]
        public void TestInvalidTemperatureTypeConversion()
        {

            var ex = Assert.Throws<Exception>(() => _temperatureController.ConvertTemperature("Temp", 445));

            Assert.Equal("Invalid temperature type value provided type", ex.Message);
            
        }
    }
}
