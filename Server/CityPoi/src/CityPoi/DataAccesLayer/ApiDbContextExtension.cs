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

                },
                new City()
                {
                    Name = "Paris",
                    Country = "France",
                    Description = "Ville lumineuse et romantique",

                }
            };

            cities[0].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Château Frontenac",
                Descritption = "Emblème de la ville",
                Latitude = "46.8114843",
                Longitude = "-71.20519279999996"
            });

            cities[0].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Chute-Montmorency",
                Descritption = "Plus belles chutes de Quebec",
                Latitude = "46.890804",
                Longitude = "-71.14768400000003"
            });

            cities[0].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Musée national des beaux-art",
                Descritption = "La destination parfaite pour les amoureux de l'art",
                Latitude = "46.8009687",
                Longitude = "-71.22502739999999"
            });

            cities[1].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Statue de la liberté",
                Descritption = "Embleme principal de la ville",
                Latitude = "40.6892494",
                Longitude = "-74.0445004"
            });

            cities[1].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Time Square",
                Descritption = "La petite jungle de New York, plusieurs spectacles y sont donnés",
                Latitude = "40.759011",
                Longitude = "-73.98447220000003"
            });

            cities[1].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Chinatown",
                Descritption = "Quartier asiatique dans le sud de Manhattan",
                Latitude = "40.7157509",
                Longitude = "-73.99703069999998"
            });

            cities[2].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Le Sacré coeur",
                Descritption = "L'un des plus beaux monuments de Paris dans le quartier de Montmartre",
                Latitude = "48.88670459999999",
                Longitude = "2.34310430000005"
            });

            cities[2].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Tour Eiffel",
                Descritption = "Célebre tour en fer de Gustave Eiffel, elle est l'emblème de Paris",
                Latitude = "48.85837009999999",
                Longitude = "2.2944813000000295"
            });

            cities[2].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Moulin Rouge",
                Descritption = "Cabaret mondialement connu pour ses spectacles et ses danseuses",
                Latitude = "48.8841232",
                Longitude = "2.33225189999996"
            });


            apiDbContext.Cities.AddRange(cities);
            apiDbContext.SaveChanges();
        }

    }
}
