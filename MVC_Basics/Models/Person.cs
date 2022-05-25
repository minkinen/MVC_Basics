

using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC_Basics.Models
{

    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Phone Number Required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [MaxLength(50)]
        [Required(ErrorMessage = "City Required")]
        public string City { get; set; }


        public Person()
        {
        }

        public Person(int id,  string name, string phone, string city)
        {
            Id = id;
            Name = name;
            PhoneNumber = phone;
            City = city;
        }

    }
}
