using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Basics.Models
{

    public class Person
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Phone Number Required")]
        public string PhoneNumber { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [Display(Name = "City")]
        public City City { get; set; }

    }
}