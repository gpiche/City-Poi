using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Controllers;
using CityPoi.DTOs;
using CityPoi.Services;
using NSubstitute;

namespace CityPoi.UnitTests.Builder
{
    public class BaseCityController
    {
        protected ICityRepository MockCityRepository;
        protected CitiesController CityController;
        protected CityGenerator CityFaker;
        protected EntitiesToDTO ToDTO;

        public BaseCityController()
        {
            MockCityRepository= Substitute.For<ICityRepository>();// Création du mock à partir d'un interafce 
            CityController = new CitiesController(MockCityRepository); // Injection du mock dans le controleur
            CityFaker = new CityGenerator();
            ToDTO = new EntitiesToDTO();

        }
    }
}
