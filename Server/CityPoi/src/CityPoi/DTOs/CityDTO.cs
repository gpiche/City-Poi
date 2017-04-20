using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CityPoi.DTOs
{
    public class CityDTO 
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public ICollection<PointOfInterest> PointsOfInterests { get; set; }
    }
}

