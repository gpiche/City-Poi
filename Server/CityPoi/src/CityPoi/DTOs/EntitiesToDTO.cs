using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;
using CityPoi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityPoi.DTOs
{
    public class EntitiesToDTO
    {
        public List<CitiesDto> ToCitiesDto(IEnumerable<Entities.City> cities)
        {
            var citiesDTO = cities.Select(city => new CitiesDto()
            {
                Key = city.Id,
                Name = city.Name,
                Description = city.Description,
                Country = city.Country,

            }).ToList();

            return citiesDTO;
        }

        public CityWithoutPoiDTO ToCityWithoutPoiDto(City city)
        {
            var cityWithoutPoiDTO = new CityWithoutPoiDTO()
            {
                Name = city.Name,
                Country = city.Country,
                Description = city.Description,
                Key = city.Id,

            };

            return cityWithoutPoiDTO;
        }

        public CityWithPoiDTO ToCityWithPoiDto(City city)
        {
            var cityWithPoiDTO = new CityWithPoiDTO()
            {
                Name = city.Name,
                Country = city.Country,
                Description = city.Description,
                PointsOfInterests = city.PointsOfInterests.ToList()

            };

            return cityWithPoiDTO;
        }

        public List<PoiDTO> ToPoiDto(IEnumerable<PointOfInterest> pointsOfInterest)
        {
            var poiDTO= pointsOfInterest.Select(pointOfInterest=> new PoiDTO()
            {
                Id = pointOfInterest.Id,
                Name = pointOfInterest.Name,
                Descritption = pointOfInterest.Descritption,
                FullDescription = pointOfInterest.FullDescritption,
                Logo = pointOfInterest.Logo,
                Picture = pointOfInterest.Picture,
                Latitude = pointOfInterest.Latitude,
                Longitude = pointOfInterest.Longitude,

            }).ToList();

            return poiDTO;
        }

        public PoiDTO ToAPoiForACityDto(PointOfInterest pointOfInterest)
        {
            var pointOfInterestDto = new PoiDTO()
            {
                Id = pointOfInterest.Id,
                Name = pointOfInterest.Name,
                Descritption = pointOfInterest.Descritption,
                FullDescription = pointOfInterest.FullDescritption,
                Logo = pointOfInterest.Logo,
                Picture = pointOfInterest.Picture,
                Longitude = pointOfInterest.Longitude,
                Latitude = pointOfInterest.Latitude,

            };

            return pointOfInterestDto;
        }
    }

}
