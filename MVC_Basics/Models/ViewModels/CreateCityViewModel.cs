using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Basics.Models.ViewModels
{

    [ModelMetadataType(typeof(City))]
    public class CreateCityViewModel : City
    {

        [Required]
        public string Country { get; set; }

    }

}