using Microsoft.AspNetCore.Mvc;

namespace MVC_Basics.Models.ViewModels
{

    [ModelMetadataType(typeof(City))]
    public class CitiesViewModel
    {

        public static string Title = "Index";

        public static string Header = "Cities Index";

        public List<City> Cities { get; set; }

        public string Search { get; set; }

    }

}