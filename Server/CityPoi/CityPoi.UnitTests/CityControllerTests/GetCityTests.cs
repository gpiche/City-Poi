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
    public class GetCityTests : BaseCityController
    {
        [Fact]
        public void GetCity_CityDontExist_ReturnsNotFoundResult()
        {
            //Arrange
            bool includePoi = true;
            var anyCity = CityFaker.Generate();

            MockCityRepository.CityExists(anyCity.Id).Returns(false);
            MockCityRepository.GetCity(anyCity.Id, includePoi).Returns(anyCity);

            //Action
            var result = CityController.GetCity(anyCity.Id, includePoi);


            // Assert
            result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public void GetCityWithPoi_CityExist_ReturnsCityWithPoiDTO()
        {
            //Arrange
            bool includePoi = true;
            var anyCity = CityFaker.Generate();
            var cityWithPoiDto = ToDTO.ToCityWithPoiDto(anyCity);

            MockCityRepository.CityExists(anyCity.Id).Returns(true);
            MockCityRepository.GetCity(anyCity.Id, includePoi).Returns(anyCity);



            //Action
            var result = CityController.GetCity(anyCity.Id, includePoi);


            // Assert
            result.Should().BeOfType<ObjectResult>()
                    .Which.Value.ShouldBeEquivalentTo(cityWithPoiDto);

        }

        [Fact]
        public void GetCityWithoutPoi_CityExist_ReturnsCityWithoutPoiDTO()
        {
            //Arrange
            bool includePoi = false;
            var anyCity = CityFaker.Generate();
            var cityWithoutPoiDto = ToDTO.ToCityWithoutPoiDto(anyCity);

            MockCityRepository.CityExists(anyCity.Id).Returns(true);
            MockCityRepository.GetCity(anyCity.Id, includePoi).Returns(anyCity);



            //Action
            var result = CityController.GetCity(anyCity.Id, includePoi);


            // Assert
            result.Should().BeOfType<ObjectResult>()
                    .Which.Value.ShouldBeEquivalentTo(cityWithoutPoiDto);

        }
    }
}
