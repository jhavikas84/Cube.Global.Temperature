
using Cube.Global.Temperature.Core.Interface;
using Cube.Global.Temperature.Core.Models;

namespace Cube.Global.Temperature.Wep.Api.Services
{
    public interface ITemperatureService
    {
       
       /* ICelsiusTemperature CelsiusTemperature { get; }
        IFahrenheitTemperature FahrenheitTemperature { get; }
        IKelvinTemperature KelvinTemperature { get; } */

        TemperatureDTO Convert(double temperature, string type);
    }
}
