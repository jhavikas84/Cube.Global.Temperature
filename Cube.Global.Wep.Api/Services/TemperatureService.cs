
using System;
using Cube.Global.Temperature.Core.Enums;
using Cube.Global.Temperature.Core.Interface;
using Cube.Global.Temperature.Core.Models;

namespace Cube.Global.Temperature.Wep.Api.Services
{
    public class TemperatureService : ITemperatureService
    {
        private ICelsiusTemperature _celsiusTemperature;
        private IFahrenheitTemperature _fahrenheitTemperature;
        private IKelvinTemperature _kelvinTemperature;
        public TemperatureService(IKelvinTemperature kelvinTemperature,
                                    ICelsiusTemperature celsiusTemperature,
                                    IFahrenheitTemperature fahrenheitTemperature)
        {
            _celsiusTemperature = celsiusTemperature;
            _kelvinTemperature = kelvinTemperature;
            _fahrenheitTemperature = fahrenheitTemperature;

        }

        public ICelsiusTemperature CelsiusTemperature => _celsiusTemperature;

        public IFahrenheitTemperature FahrenheitTemperature => _fahrenheitTemperature;

        public IKelvinTemperature KelvinTemperature => _kelvinTemperature;


        public TemperatureDTO Convert(double temperature, string type)
        {
            TemperatureDTO temperatureDTO = new();

            if (Enum.TryParse(type.ToUpper(), out TemperatureType temperatureType))
            {
                switch (temperatureType)
                {
                    case TemperatureType.CELSIUS:
                        temperatureDTO.Celsius = $"{temperature}°C";
                        temperatureDTO.Fahrenheit = $"{CelsiusTemperature.ConvertToFahrenheit(temperature)}°F";
                        temperatureDTO.Kelvin = $"{CelsiusTemperature.ConvertToKelvin(temperature)}K";
                        break;
                    case TemperatureType.FAHRENHEIT:
                        temperatureDTO.Fahrenheit = $"{temperature}°F";
                        temperatureDTO.Celsius = $"{FahrenheitTemperature.ConvertToCelsius(temperature)}°C";
                        temperatureDTO.Kelvin = $"{FahrenheitTemperature.ConvertToKelvin(temperature)}K";
                        break;
                    case TemperatureType.KELVIN:
                        temperatureDTO.Kelvin = $"{temperature}K";
                        temperatureDTO.Fahrenheit = $"{KelvinTemperature.ConvertToFahrenheit(temperature)}°F";
                        temperatureDTO.Celsius = $"{KelvinTemperature.ConvertToCelsius(temperature)}°C";
                        break;
                }
            }
            else
            {
                throw new Exception($"Invalid temperature type value provided {nameof(type)}");
            }

            return temperatureDTO;
        }
    }
}
