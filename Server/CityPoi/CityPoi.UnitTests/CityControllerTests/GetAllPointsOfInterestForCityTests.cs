using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.DTOs;
using CityPoi.UnitTests.Builder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CityPoi.UnitTests.CityControllerTests
{
    public class GetAllPointsOfInterestForCityTests : BaseCityController
    {
        [Fact]
        public void GetAllPointsOfInterestForCity_CityDontExist_ReturnsBadRequestResult()
        {
            //Arrange
            var anyCity = CityFaker.Generate();

            MockCityRepository.CityExists(anyCity.Id).Returns(false);
            MockCityRepository.GetPointsOfInterestForCity(anyCity.Id).Returns(anyCity.PointsOfInterests);

            //Action
            var result = CityController.GetAllPointsOfInterestForCity(anyCity.Id);


            // Assert
            result.Should().BeOfType<BadRequestResult>();

        }

        [Fact]
        public void GetAllPointsOfInterestForCity_CityExist_ReturnsAllPoiForACityDTO()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var allPoiForACityDTO = ToDTO.ToPoiDto(anyCity.PointsOfInterests);

            MockCityRepository.CityExists(anyCity.Id).Returns(true);
            MockCityRepository.GetPointsOfInterestForCity(anyCity.Id).Returns(anyCity.PointsOfInterests);



            //Action
            var result = CityController.GetAllPointsOfInterestForCity(anyCity.Id);


            // Assert
            result.Should().BeOfType<ObjectResult>()
                    .Which.Value.ShouldBeEquivalentTo(allPoiForACityDTO);

        }
    }
}
