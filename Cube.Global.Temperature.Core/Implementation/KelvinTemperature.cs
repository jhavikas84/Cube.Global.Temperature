using System;
using Cube.Global.Temperature.Core.Enums;
using Cube.Global.Temperature.Core.Interface;

namespace Cube.Global.Temperature.Core.Implementation
{
    public class KelvinTemperature : IKelvinTemperature
    {
        private readonly TemperatureType _TemperatureType;

        public KelvinTemperature()
        {
            _TemperatureType = TemperatureType.KELVIN;
        }

        #region [ IKelvinTemperature implementation ]

        public TemperatureType TemperatureType => _TemperatureType;

        public double ConvertToCelsius(double temperature)
        {
            double temperatureValue;
            try
            {
                if (double.TryParse(temperature.ToString(), out temperatureValue))
                {
                    temperatureValue -= 273.15;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Math.Round(temperatureValue, 2);
        }

        public double ConvertToFahrenheit(double temperature)
        {
            double temperatureValue;
            try
            {
                if (double.TryParse(temperature.ToString(), out temperatureValue))
                {
                    temperatureValue = (temperatureValue - 273.15) * 9 / 5 + 32;
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
