

using MVC_Basics.Models.ViewModels;

namespace MVC_Basics.Models.ViewModels
{
    public class PeopleViewModel
    {

        public static List<Person> people = new List<Person>();

        public static int pageCount = 0;

        public static string Title = "Index";

        public static string Header = "People Index";

        public string Search { get; set; }
        public List<Person> QueryList { get; set; }


        // Will only add the default list if this is the first visit,
        // otherwise it will just add one more to the page count.
        // Using pageCount for both determine if this is first visit 
        // and for giving an Id to added new persons to the list atm.
        public static void DefaultList()
        {
            if (pageCount == 0)
            {
                foreach (Person person in People)
                {
                    Person info = new Person()
                    {
                        Id = person.Id,
                        Name = person.Name,
                        City = person.City,
                        PhoneNumber = person.PhoneNumber

                    };
                    people.Add(info);
                    pageCount++;
                }
            }
            pageCount++;
            return;
        }


        public static List<Person> People = new List<Person>()
        {
            new Person(1, "Anna Annasdotter", "08-888888", "Stockholm" ),
            new Person(2, "Bertil Bertilsson", "031-313131", "Göteborg" ),
            new Person(3, "Carl Carlsson", "040-404040", "Malmö" )
        };
    }
}
