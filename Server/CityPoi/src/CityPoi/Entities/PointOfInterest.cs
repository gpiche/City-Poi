using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CityPoi.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^-?([1-8]?[1-9]|[1-9]0)\.{1}\d{1,6}")]
        public string Latitude { get; set; }
        [Required]
        [RegularExpression(@"^-?([1]?[1-7][1-9]|[1]?[1-8][0]|[1-9]?[0-9])\.{1}\d{1,6}")]
        public string Longitude { get; set; }

        public string Descritption { get; set; }

        [ForeignKey("CityId")]
        public int CityId { get; set; }
       
       

    }
}
