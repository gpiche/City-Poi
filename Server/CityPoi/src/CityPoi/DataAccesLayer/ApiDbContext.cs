using CityPoi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityPoi.DataAccesLayer
{
    public class ApiDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
           : base(options)
        {
        }
    }
}
