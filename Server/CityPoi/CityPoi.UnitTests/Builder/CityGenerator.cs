using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using CityPoi.Entities;

namespace CityPoi.UnitTests.Builder
{
    public class CityGenerator
    {
        private Faker<City> CityFaker;
        private Faker<PointOfInterest> PoiFaker;

        public CityGenerator()
        {
            InitializeFakerItem();
        }

        public City Generate()
        {
            return CityFaker.Generate();
        }

        public List<City> Generate(int nbOfCities)
        {
            return CityFaker.Generate(nbOfCities).ToList();
        }

        public void InitializeFakerItem()
        {
            PoiFaker = new Faker<PointOfInterest>(locale: "fr")
                .RuleFor(poi => poi.Name, f => f.Lorem.ToString())
                .RuleFor(poi => poi.Latitude, f => f.Address.Latitude().ToString())
                .RuleFor(poi => poi.Longitude, f => f.Address.Longitude().ToString())
                .RuleFor(poi => poi.Descritption, f => f.Lorem.ToString());

            CityFaker = new Faker<City>(locale: "fr")
                .RuleFor(city => city.Name, f => f.Address.City().ToString())
                .RuleFor(city => city.Country, f =>f.Address.Country().ToString())
                .RuleFor(city => city.Description, f => f.Lorem.ToString())
                .RuleFor(city => city.PointsOfInterests, f => PoiFaker.Generate(3).ToList());
        }
    }
}
