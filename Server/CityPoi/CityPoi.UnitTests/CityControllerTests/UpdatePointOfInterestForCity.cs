using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.DTOs;
using CityPoi.Entities;
using CityPoi.UnitTests.Builder;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;
using NSubstitute;

namespace CityPoi.UnitTests.CityControllerTests
{
    public class UpdatePointOfInterestForCity : BaseCityController
    {
        [Fact]
        public void UpdatePointOfInterestForCity_CityExist_CallsUpdateOnCityRepository()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoi = anyCity.PointsOfInterests.FirstOrDefault();
            anyPoi.Id = 1;
            var poiDTO = new PoiDTO()
            {
                Name = "Château de Versaille",
                Descritption = "La planque à Marie Antoinette",
                Latitude = "80.090",
                Longitude = "130.234"
            };
            MockCityRepository.CityExists(anyCity.Id).Returns(true);

            //Action
            var result = CityController.UpdatePointOfInterest(anyCity.Id, anyPoi.Id, poiDTO);

            // Assert 
            MockCityRepository.Received().UpdatePointOfInterest(Arg.Is<PointOfInterest>(x => x.Id == anyPoi.Id));
        }


        [Fact]
        public void UpdatePointOfInterestForCity_CityExist_ReturnsNoContentResults()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoi = anyCity.PointsOfInterests.FirstOrDefault();
            anyPoi.Id = 1;
            var poiDTO = new PoiDTO()
            {
                Name = "Château de Versaille",
                Descritption = "La planque à Marie Antoinette",
                Latitude = "80.090",
                Longitude = "130.234"
            };
            MockCityRepository.CityExists(anyCity.Id).Returns(true);

            //Action
            var result = CityController.UpdatePointOfInterest(anyCity.Id, anyPoi.Id, poiDTO);

            // Assert 
            result.Should().BeOfType<NoContentResult>();

        }

        [Fact]
        public void UpdatePointOfInterest_WhenCityDontExist_ReturnNotFoundResult()

        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoi = anyCity.PointsOfInterests.FirstOrDefault();
            var poiDTO = new PoiDTO()
            {
                Name = "Château de Versaille",
                Descritption = "La planque à Marie Antoinette",
                Latitude = "48° 41\' 25.79\" N",
                Longitude = " -81° 19\' 10.80\" W"
            };
            MockCityRepository.CityExists(anyCity.Id).Returns(false);

            //Action
            var result = CityController.UpdatePointOfInterest(anyCity.Id, anyPoi.Id, poiDTO);

            // Assert 
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void UpdatePointOfInterest_WhenPoiDTODontExist_ReturnBadRequestResult()

        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoi = anyCity.PointsOfInterests.FirstOrDefault();
            MockCityRepository.CityExists(anyCity.Id).Returns(true);

            //Action
            var result = CityController.UpdatePointOfInterest(anyCity.Id, anyPoi.Id, null);

            // Assert 
            result.Should().BeOfType<BadRequestResult>();
        }

    }
}
