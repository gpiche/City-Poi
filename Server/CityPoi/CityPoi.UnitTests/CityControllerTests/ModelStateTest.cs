using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class ModelStateTest : BaseCityController
    {
        [Fact]
        public void AddPointOfInterest_InvalidPoiData_ReturnBadRequest()
        {
            CityController.ModelState.AddModelError("Error","Model State Error");

            var city =  CityFaker.Generate();
            MockCityRepository.CityExists(city.Id).Returns(true);
            var result = CityController.AddPointOfInterestForCity(city.Id, new PoiDTO());

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void UpdatePointOfInterest_InvalidPoiData_ReturnBadRequest()
        {
            CityController.ModelState.AddModelError("Error", "Model State Error");

            var city = CityFaker.Generate();
            city.Id = 1;
            MockCityRepository.CityExists(city.Id).Returns(true);
            var pointOfInterestId = city.PointsOfInterests.First().Id;
            var result = CityController.UpdatePointOfInterest(city.Id, pointOfInterestId, new PoiDTO());

            result.Should().BeOfType<BadRequestResult>();

        }

        [Fact]
        public void ModelState_ValideItem_ReturnNoError()
        {
            var city = CityFaker.Generate();

            var modelStateValidity = ValidateCity(city);

            modelStateValidity.Should().BeTrue();
        }

        [Fact]
        public void ModelSate_CityWithoutName_NotValide()
        {
            var city = CityFaker.Generate();
            city.Name = null;

            var modelStateValidity = ValidateCity(city);

            modelStateValidity.Should().BeFalse();
        }

        [Fact]
        public void ModelSate_CityWithoutCountry_NotValide()
        {
            var city = CityFaker.Generate();
            city.Country = null;

            var modelStateValidity = ValidateCity(city);

            modelStateValidity.Should().BeFalse();
        }

        [Fact]
        public void ModelSate_PointOfInterestWithoutName_NotValide()
        {
            var city = CityFaker.Generate();
            var pointOfInterest = city.PointsOfInterests.First();
            pointOfInterest.Name = null;
            pointOfInterest.Latitude = "48.55655855";
            pointOfInterest.Longitude = "-70.5598523";


            var modelStateValidity = ValidatePoi(pointOfInterest);

            modelStateValidity.Should().BeFalse();
        }


        [Fact]
        public void ModelSate_PointOfInterestWithoutLatitude_NotValide()
        {
            var city = CityFaker.Generate();
            var pointOfInterest = city.PointsOfInterests.First();
            pointOfInterest.Latitude = null;

            var modelStateValidity = ValidatePoi(pointOfInterest);

            modelStateValidity.Should().BeFalse();
        }


        [Fact]
        public void ModelSate_PointOfInterestWithoutLongitude_NotValide()
        {
            var city = CityFaker.Generate();
            var pointOfInterest = city.PointsOfInterests.First();
            pointOfInterest.Longitude = null;

            var modelStateValidity = ValidatePoi(pointOfInterest);

            modelStateValidity.Should().BeFalse();
        }

        [Theory]
        [InlineData("91.0")]
        [InlineData("-945.0")]
        [InlineData("90.68847896")]
        public void ModelSate_LatitudeWithBadFormat_ReturnFalse(string latitude)
        {
            var city = CityFaker.Generate();
            var pointOfInterest = city.PointsOfInterests.First();
            pointOfInterest.Latitude = latitude; 

            var modelStateValidity = ValidatePoi(pointOfInterest);

            modelStateValidity.Should().BeFalse();
        }

        [Theory]
        [InlineData("-98.0923913")]
        [InlineData("185.22545222")]
        [InlineData("180")]
        public void ModelSate_LongitudeWithBadFormat_ReturnFalse(string longitude)
        {
            var city = CityFaker.Generate();
            var pointOfInterest = city.PointsOfInterests.First();
            pointOfInterest.Latitude = longitude;

            var modelStateValidity = ValidatePoi(pointOfInterest);

            modelStateValidity.Should().BeFalse();
        }


        private static bool ValidateCity(City city)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(city, null, null);
            return Validator.TryValidateObject(city, validationContext, validationResults, true);
        }

        private static bool ValidatePoi(PointOfInterest pointOfInterest)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(pointOfInterest, null, null);
            return Validator.TryValidateObject(pointOfInterest, validationContext, validationResults, true);
        }
    }
}
