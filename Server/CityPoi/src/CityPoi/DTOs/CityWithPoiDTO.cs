using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CityPoi.DTOs
{
    public class CityWithPoiDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public ICollection<PointOfInterest> PointsOfInterests { get; set; }
    }
}
