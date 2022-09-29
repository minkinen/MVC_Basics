using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Basics.Models
{
    public class City
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "City Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Display(Name = "Country")]
        public Country Country { get; set; }

        [Display(Name = "People")]
        public virtual List<Person>? People { get; set; }

        public override string ToString()
        {
            return CityName;
        }

    }
}