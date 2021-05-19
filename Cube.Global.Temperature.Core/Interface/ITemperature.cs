using Cube.Global.Temperature.Core.Enums;

namespace Cube.Global.Temperature.Core.Interface
{
    public interface ITemperature
    {
        public TemperatureType TemperatureType { get; }
    }
}
