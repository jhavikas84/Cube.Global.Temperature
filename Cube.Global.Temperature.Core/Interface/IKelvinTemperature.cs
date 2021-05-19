namespace Cube.Global.Temperature.Core.Interface
{
    public interface IKelvinTemperature : ITemperature
    {
        double ConvertToFahrenheit(double temperature);
        double ConvertToCelsius(double temperature);
    }
}
