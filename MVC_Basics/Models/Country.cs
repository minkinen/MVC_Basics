using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Basics.Models
{
    public class Country
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Country Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Country Name Required")]
        public string CountryName { get; set; }

        [Display(Name = "Citys")]
        public List<City>? Cities { get; set; }

        public override string ToString()
        {
            return CountryName;
        }

    }
}