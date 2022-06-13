

using MVC_Basics.Models.ViewModels;

namespace MVC_Basics.Models.ViewModels
{
    public class PeopleViewModel
    {

        public static string Title = "Index";

        public static string Header = "People Index";

        public List<Person> PeopleList { get; set; }

        public string Search { get; set; }
        public List<Person> QueryList { get; set; }


    }
}
