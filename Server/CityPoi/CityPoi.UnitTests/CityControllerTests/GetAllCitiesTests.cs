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
    public class GetAllCitiesTests : BaseCityController
    {
        [Fact]
        public void GetAll_CitiesExist_ReturnCitiesDTO()
        {
            //Arrange
            int nbOfCities = 4;
            var cities = CityFaker.Generate(nbOfCities);
            string name = "";
            var citiesDTO = ToDTO.ToCitiesDto(cities);

            MockCityRepository.GetCities().Returns(cities); 

            //Action
            var result = CityController.GetCities(name);


            // Assert
            result.Should().BeOfType<ObjectResult>()
             .Which.Value.ShouldBeEquivalentTo(citiesDTO);
        }

        [Fact]
        public void GetAll_ForASpecificCity_ReturnTheCityDTO()
        {
            //Arrange
            int nbOfCities = 4;
            var cities = CityFaker.Generate(nbOfCities);
            cities[0].Name = "Paris";
            string name = cities[0].Name;
            var citiesDTO = ToDTO.ToCitiesDto(cities);

            MockCityRepository.GetCities().Returns(cities);

            //Action
            var result = CityController.GetCities(name);


            // Assert
            result.Should().BeOfType<ObjectResult>();
            citiesDTO[0].Name.ShouldBeEquivalentTo(name);
        }

    }
}
