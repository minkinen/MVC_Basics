using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Basics.Models.ViewModels
{

    [ModelMetadataType(typeof(Country))]
    public class CreateCountryViewModel : Country
    {

    }

}