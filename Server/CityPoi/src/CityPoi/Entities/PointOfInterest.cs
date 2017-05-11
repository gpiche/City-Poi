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
        [RegularExpression("-?([0-8]?[0-9][,.][0-9]+|90[,.]0+)")]
        public string Latitude { get; set; }
        [Required]
        [RegularExpression("-?((1[0-7]|[0-9])?[0-9][,.][0-9]+|180[,.]0+)")]
        public string Longitude { get; set; }

        public string Descritption { get; set; }

        [ForeignKey("CityId")]
        public int CityId { get; set; }
       
       

    }
}
