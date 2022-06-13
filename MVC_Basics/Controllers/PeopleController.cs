using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Data;
using MVC_Basics.Models;
using MVC_Basics.Models.ViewModels;

namespace MVC_Basics.Controllers
{
    public class PeopleController : Controller
    {
        //  Use Dependency Injection to inject database context into your controller
        private readonly ApplicationDbContext _context;

        // Use the database context to persist our Person data on the database and retrieve the data when needed.
        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            PeopleViewModel peopleViewModelInstance = new PeopleViewModel();
            peopleViewModelInstance.PeopleList = _context.People.ToList();
            return View("Index", peopleViewModelInstance);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                PeopleViewModel peopleViewModelSearchInstance = new PeopleViewModel();
                peopleViewModelSearchInstance.PeopleList = _context.People.ToList();

                List<Person> queryList = new List<Person>();

                foreach (Person p in peopleViewModelSearchInstance.PeopleList)
                {
                    bool searchHit = p.Name.ToString().ToUpper().Contains(search.ToUpper()) || p.City.ToString().ToUpper().Contains(search.ToUpper());
                    if (searchHit == true)
                    {
                        queryList.Add(p);
                    }
                }

                peopleViewModelSearchInstance.Search = search;
                peopleViewModelSearchInstance.QueryList = queryList;

                ViewBag.SearchMessage = "Search: " + search;

                return View("Index", peopleViewModelSearchInstance);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }



        public IActionResult DeletePerson(int Id)
        {
            if (ModelState.IsValid)
            {
                var personToRemove = _context.People.Find(Id);
                _context.People.Remove(personToRemove);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.Where(z => z.Value.Errors.Count > 0).ToList();
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        public IActionResult AddNewPerson(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
