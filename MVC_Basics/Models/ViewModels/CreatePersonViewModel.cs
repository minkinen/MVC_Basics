using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Basics.Models.ViewModels
{
    // DRY by using annotations from the Person class
    [ModelMetadataType(typeof(Person))] 
    public class CreatePersonViewModel : Person
    {
        // Extra attribute with an internal get to prevent overposting
        public bool IsAdmin { internal get; set; }
    }
}
