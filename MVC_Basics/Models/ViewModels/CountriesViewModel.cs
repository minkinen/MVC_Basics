using Microsoft.AspNetCore.Mvc;

namespace MVC_Basics.Models.ViewModels
{

    [ModelMetadataType(typeof(Country))]
    public class CountriesViewModel
    {

        public static string Title = "Index";

        public static string Header = "Countries Index";

        public List<Country> Countries { get; set; }

        public string Search { get; set; }

    }
}