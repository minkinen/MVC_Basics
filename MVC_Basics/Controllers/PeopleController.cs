using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;
using MVC_Basics.Models.ViewModels;

namespace MVC_Basics.Controllers
{
    public class PeopleController : Controller
    {

        public IActionResult Index()
        {
            PeopleViewModel.DefaultList();
            PeopleViewModel peopleViewModelInstance = new PeopleViewModel();
            return View("Index", peopleViewModelInstance);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {

                List<Person> queryList = new List<Person>();

                foreach (Person p in PeopleViewModel.people)
                {
                    bool searchHit = p.Name.ToString().ToUpper().Contains(search.ToUpper()) || p.City.ToString().ToUpper().Contains(search.ToUpper());
                    if (searchHit == true)
                    {
                        queryList.Add(p);
                    }
                }

                PeopleViewModel peopleViewModelSearchInstance = new PeopleViewModel()
                {
                    Search = search,
                    QueryList = queryList,
                };

                ViewBag.SearchMessage = "Search: " + search;

                return View("Index", peopleViewModelSearchInstance);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }



        public IActionResult DeletePerson(int id)
        {
            if (ModelState.IsValid)
            {
                var updateList = PeopleViewModel.people.RemoveAll(y => y.Id == id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.Where(z => z.Value.Errors.Count > 0).ToList();
                return RedirectToAction(nameof(Index));
            }
        }


        // Will set Id to a unique random number when I have learned how to do that instead of the current pageCount that I use now
        [HttpPost]
        public IActionResult AddNewPerson(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                Person newPerson = new(PeopleViewModel.pageCount, person.Name, person.PhoneNumber, person.City);
                PeopleViewModel.people.Add(newPerson);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
