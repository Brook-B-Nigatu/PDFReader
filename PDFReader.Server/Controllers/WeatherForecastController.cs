using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDFReader.Server.DB;

namespace PDFReader.Server.Controllers
{
    

    [ApiController] 
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        private readonly WeatherDB _weatherDB;
        public WeatherForecastController(WeatherDB weatherDB)
        {
            _weatherDB = weatherDB;
            _weatherDB.Database.EnsureCreated();

            //_weatherDB.Database.ExecuteSqlRaw("delete from WeatherForecasts");
            if (_weatherDB.WeatherForecasts.Any())
            {
                return; 
            }
            
            for (int i = 1; i < 6; ++i)
            {
                _weatherDB.WeatherForecasts.Add(new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                });
            }
            _weatherDB.SaveChanges();
            
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherDB.WeatherForecasts.ToArray();
        }
    }
}
