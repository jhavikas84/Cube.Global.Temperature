namespace Cube.Global.Temperature.Core.Interface
{
    public interface IFahrenheitTemperature : ITemperature
    {
        double ConvertToKelvin(double temperature);
        double ConvertToCelsius(double temperature);
    }
}
