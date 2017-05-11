using System;
using System.Linq;
using CityPoi.DTOs;
using CityPoi.Services;
using Microsoft.AspNetCore.Mvc;
using CityPoi.Entities;

namespace CityPoi.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private ICityRepository CitiesRepository;
        private EntitiesToDTO ToDto = new EntitiesToDTO();
        private DtosToEntities toEntity = new DtosToEntities();


        public CitiesController(ICityRepository cities)
        {
            CitiesRepository = cities;
        }


        [HttpGet]
        public IActionResult GetCities(string name)
        {
            var cities = CitiesRepository.GetCities(); // retourne toute la collection 

            if (name != null)
            {
                cities = cities.Where(city => city.Name.Contains(name));
            }

            var citiesDTO = ToDto.ToCitiesDto(cities);

            return new ObjectResult(citiesDTO);
        }


        [HttpGet("{cityId}")]
        public IActionResult GetCity(int cityId, bool includePointsOfInterest)
        {
            var city = CitiesRepository.GetCity(cityId, includePointsOfInterest);

            if (!CitiesRepository.CityExists(cityId))
            {
                return NotFound();
            }


            if (!includePointsOfInterest)
            {
                var cityWithoutPoiDTO = ToDto.ToCityWithoutPoiDto(city);

                return new ObjectResult(cityWithoutPoiDTO);
            }

            else
            {
                var cityWithPoiDTO = ToDto.ToCityWithPoiDto(city);

                return new ObjectResult(cityWithPoiDTO);
            }
        }

        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetAllPointsOfInterestForCity(int cityId)
        {
            if (!CitiesRepository.CityExists(cityId))
            {
                return BadRequest();
            }

            var pointsOfInterest = CitiesRepository.GetPointsOfInterestForCity(cityId);

            var pointOfInterestDto = ToDto.ToPoiDto(pointsOfInterest);

            return new ObjectResult(pointOfInterestDto);
        }


        [HttpGet("{cityId}/pointsOfInterest/{poiId}")]
        public IActionResult GetAPointOfInterestForCity(int cityId, int poiId)
        {
            if (!CitiesRepository.CityExists(cityId))
            {
                return BadRequest();
            }

            var pointOfInterest = CitiesRepository.GetPointOfInterestForCity(cityId, poiId);

            if (pointOfInterest == null) return BadRequest();

            var pointOfInterestDto = ToDto.ToAPoiForACityDto(pointOfInterest);
            return new ObjectResult(pointOfInterestDto);
        }


        [HttpPost("{cityId}/pointsOfInterest", Name = "GetCity")]
        public IActionResult AddPointOfInterestForCity(int cityId, [FromBody] PoiDTO pointOfInterestData)
        {
            if (!CitiesRepository.CityExists(cityId))
            {
                return NotFound();
            }

            if (pointOfInterestData == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pointOfInterest = toEntity.ConvertToEntity(cityId, pointOfInterestData);

            CitiesRepository.AddPointOfInterestForCity(cityId, pointOfInterest);

            return CreatedAtRoute("GetCity", new {id = pointOfInterest.Id}, pointOfInterest);
        }


        [HttpPut("{cityId}/pointsOfInterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PoiDTO pointOfInterestData)
        {
            if (!CitiesRepository.CityExists(cityId))
            {
                return NotFound();
            }

            if (pointOfInterestData == null || id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pointOfInterest = toEntity.ConvertToEntity(cityId, id, pointOfInterestData);


            CitiesRepository.UpdatePointOfInterest(pointOfInterest);

            return new NoContentResult(); // Pourquoi NoContentResult ?
        }


        [HttpDelete("{cityId}/pointsOfInterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id, [FromBody] PoiDTO pointOfInterestData)
        {
            if (!CitiesRepository.CityExists(cityId))
            {
                return NotFound();
            }

            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pointOfInterest = toEntity.ConvertToEntity(cityId, id, pointOfInterestData);

            CitiesRepository.DeletePointOfInterest(pointOfInterest);

            return new NoContentResult();
        }
    }
}