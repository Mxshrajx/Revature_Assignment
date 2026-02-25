namespace MyApp;

public interface IWeatherService
{
    IEnumerable<double> GetTemperature(string city);
}