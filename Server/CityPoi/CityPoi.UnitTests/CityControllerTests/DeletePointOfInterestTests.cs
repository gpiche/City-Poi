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
    public class DeletePointOfInterestTests : BaseCityController
    {
        [Fact]
        public void DeletePointOfInterest_WhenCityNotFound_ReturnNotFoundResult()

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
            var result = CityController.DeletePointOfInterest(anyCity.Id, anyPoi.Id, poiDTO);

            // Assert 
            result.Should().BeOfType<NotFoundResult>();

        }

         [Fact]
         public void DeletePointOfInterest_WhenCityExist_ReturnNoContentResult()

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
             var result = CityController.DeletePointOfInterest(anyCity.Id, anyPoi.Id, poiDTO);

             // Assert 
             result.Should().BeOfType<NoContentResult>();

         }
    }
}
