using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;

namespace CityPoi.DataAccesLayer
{
    public static class ApiDbContextExtension
    {
        public static void EnsureSeedDataForContext(this ApiDbContext apiDbContext)
        {
            if (apiDbContext.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "Québec",
                    Country = "Canada",
                    Description = "Ville renomé pour sa poutine",

                },
                new City()
                {
                    Name = "New-York",
                    Country = "États-Unis",
                    Description = "Connu aussi sous le nom de la grosse pomme",

                }
            };

            cities[0].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Château Frontenac",
                Descritption = "Emblème de la ville",
                Latitude =  "80",
                Longitude = "178"
            });

            cities[1].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Statue de la liberté",
                Descritption = "Embleme principal de la ville",
                Latitude = "78.77",
                Longitude = "180"
            });




            apiDbContext.Cities.AddRange(cities);
            apiDbContext.SaveChanges();
        }

    }
}
