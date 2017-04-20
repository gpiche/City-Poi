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
    public class GetAPointOfInterestForCityTests : BaseCityController
    {
        [Fact]
        public void GetAPointOfInterestForCity_CityDontExist_ReturnsBadRequestResult()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoiKey = anyCity.PointsOfInterests.FirstOrDefault();

            MockCityRepository.CityExists(anyCity.Id).Returns(false);

            //Action
            var result = CityController.GetAPointOfInterestForCity(anyCity.Id, anyPoiKey.Id);


            // Assert
            result.Should().BeOfType<BadRequestResult>();

        }

        [Fact]
        public void GetAPointOfInterestForCity_PoiDontExist_ReturnsBadRequestResult()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoiId = anyCity.PointsOfInterests.FirstOrDefault().Id;
            anyCity.PointsOfInterests.Clear();
            
            

            MockCityRepository.CityExists(anyCity.Id).Returns(true);

            //Action
            var result = CityController.GetAPointOfInterestForCity(anyCity.Id, anyPoiId);


            // Assert
            result.Should().BeOfType<BadRequestResult>();

        }

        [Fact]
        public void GetAPointOfInterestForCity_CityAndPoiExist_ReturnsThePoiForTheCity()
        {
            //Arrange
            var anyCity = CityFaker.Generate();
            var anyPoi = anyCity.PointsOfInterests.FirstOrDefault();
            var aPoiForACityDTO = ToDTO.ToAPoiForACityDto(anyPoi);

            MockCityRepository.CityExists(anyCity.Id).Returns(true);
            MockCityRepository.GetPointOfInterestForCity(anyCity.Id, anyPoi.Id).Returns(anyPoi);

            //Action
            var result = CityController.GetAPointOfInterestForCity(anyCity.Id, anyPoi.Id);


            // Assert
            result.Should().BeOfType<ObjectResult>()
                    .Which.Value.ShouldBeEquivalentTo(aPoiForACityDTO);

        }

    }
}
