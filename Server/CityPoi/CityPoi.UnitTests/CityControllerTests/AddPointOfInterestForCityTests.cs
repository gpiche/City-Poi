using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.DTOs;
using CityPoi.Entities;
using CityPoi.UnitTests.Builder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CityPoi.UnitTests.CityControllerTests
{
    public class AddPointOfInterestForCityTests : BaseCityController
    {
        [Fact]
        public void AddPointOfInterestForCity_CityDontExist_ReturnsNotFoundResult()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoi = new PointOfInterest()
            {
                Name = "Château Frontenac",
                Descritption = "Emblème de la ville",
                Latitude = "46° 48\' 25.79\" N",
                Longitude = " -71° 12\' 10.80\" W"
            };

            var poiDTO = new PoiDTO()
            {
                Name = anyPoi.Name,
                Descritption = anyPoi.Descritption,
                Latitude = anyPoi.Latitude,
                Longitude = anyPoi.Longitude
            };

            MockCityRepository.CityExists(anyCity.Id).Returns(false);

            //Action
            var result = CityController.AddPointOfInterestForCity(anyCity.Id, poiDTO);


            // Assert
            result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public void AddPointOfInterestForCity_PoiIsNull_ReturnsBadRequestResult()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            MockCityRepository.CityExists(anyCity.Id).Returns(true);
            MockCityRepository.AddPointOfInterestForCity(anyCity.Id, null);

            //Action
            var result = CityController.AddPointOfInterestForCity(anyCity.Id, null);


            // Assert
            result.Should().BeOfType<BadRequestResult>();

        }

        [Fact]
        public void AddPointOfInterestForCity_CityExist_ReturnsCreatedAtRouteResult()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoi = new PointOfInterest()
            {
                Name = "Château Frontenac",
                Descritption = "Emblème de la ville",
                Latitude = "46° 48\' 25.79\" N",
                Longitude = " -71° 12\' 10.80\" W"
            };

            var poiDTO = new PoiDTO()
            {
                Name = anyPoi.Name,
                Descritption = anyPoi.Descritption,
                Latitude = anyPoi.Latitude,
                Longitude = anyPoi.Longitude
            };

            MockCityRepository.CityExists(anyCity.Id).Returns(true);

            //Action
            var result = CityController.AddPointOfInterestForCity(anyCity.Id, poiDTO);


            // Assert
            result.Should().BeOfType<CreatedAtRouteResult>();

        }
    }
}
