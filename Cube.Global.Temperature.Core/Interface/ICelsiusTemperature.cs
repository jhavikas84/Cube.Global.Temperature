namespace Cube.Global.Temperature.Core.Interface
{
    public interface ICelsiusTemperature : ITemperature
    {
        double ConvertToFahrenheit(double temperature);
        double ConvertToKelvin(double temperature);
    }
}
