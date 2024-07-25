using Microsoft.EntityFrameworkCore;

namespace PDFReader.Server.DB
{
    public class WeatherDB : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherDB(DbContextOptions<WeatherDB> options) : base(options) { }


    }
}
