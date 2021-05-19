using System;
using Cube.Global.Temperature.Core.Enums;
using Cube.Global.Temperature.Core.Interface;

namespace Cube.Global.Temperature.Core.Implementation
{
    public class CelsiusTemperature : ICelsiusTemperature
    {
        private readonly TemperatureType _TemperatureType;

        public CelsiusTemperature()
        {
            _TemperatureType = TemperatureType.CELSIUS;
        }

        #region [ ICelsiusTemperature implementation ]

        public TemperatureType TemperatureType => _TemperatureType;

        public double ConvertToKelvin(double temperature)
        {
            double temperatureValue;
            try
            {
                if (double.TryParse(temperature.ToString(), out temperatureValue))
                {
                    temperatureValue += 273.15;
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
                    temperatureValue = (temperatureValue - 9/5) + 32;
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
