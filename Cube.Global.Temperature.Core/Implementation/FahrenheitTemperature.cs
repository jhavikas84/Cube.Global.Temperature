using System;
using Cube.Global.Temperature.Core.Enums;
using Cube.Global.Temperature.Core.Interface;

namespace Cube.Global.Temperature.Core.Implementation
{
    public class FahrenheitTemperature : IFahrenheitTemperature
    {
        private readonly TemperatureType _TemperatureType;

        public FahrenheitTemperature()
        {
            _TemperatureType = TemperatureType.FAHRENHEIT;
        }

        #region [ IFahrenheitTemperature implementation ]

        public TemperatureType TemperatureType => _TemperatureType;

        public double ConvertToCelsius(double temperature)
        {
            double temperatureValue;
            try
            {
                if (double.TryParse(temperature.ToString(), out temperatureValue))
                {
                    temperatureValue = (temperatureValue - 32) * 5 / 9;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Math.Round(temperatureValue, 2);
        }

        public double ConvertToKelvin(double temperature)
        {
            double temperatureValue;
            try
            {
                if (double.TryParse(temperature.ToString(), out temperatureValue))
                {
                    temperatureValue = (temperatureValue - 32) * 5 / 9 + 273.15;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Math.Round(temperatureValue, 2);
        }

        #endregion
    }
}
