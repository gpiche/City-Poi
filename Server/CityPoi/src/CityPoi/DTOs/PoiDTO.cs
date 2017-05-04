
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CityPoi.DTOs
{
    public class PoiDTO 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^-?([1-8]?[1-9]|[1-9]0)\.{1}\d{1,6}")]
        public string Latitude { get; set; }
        [Required]
        [RegularExpression(@"^-?([1]?[1-7][1-9]|[1]?[1-8][0]|[1-9]?[0-9])\.{1}\d{1,6}")]
        public string Longitude { get; set; }
        public string Descritption { get; set; }

    }
}
