using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Data;
using MVC_Basics.Models;
using MVC_Basics.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Basics.Controllers
{
    public class CountriesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CountriesViewModel countriesViewModelInstance = new CountriesViewModel();
            countriesViewModelInstance.Countries = _context.Countries.ToList();
            return View("Index", countriesViewModelInstance);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                CountriesViewModel countriesViewModelSearchInstance = new CountriesViewModel();
                countriesViewModelSearchInstance.Countries = _context.Countries.ToList();

                List<Country> queryList = new List<Country>();

                foreach (Country c in countriesViewModelSearchInstance.Countries)
                {
                    bool searchHit = c.CountryName.ToString().ToUpper().Contains(search.ToUpper());
                    if (searchHit == true)
                    {
                        queryList.Add(c);
                    }
                }

                countriesViewModelSearchInstance.Search = search;
                countriesViewModelSearchInstance.Countries = queryList;

                ViewBag.SearchMessage = "Search: " + search;

                return View("Index", countriesViewModelSearchInstance);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult DeleteCountry(int Id)
        {
            if (ModelState.IsValid)
            {
                var countryToRemove = _context.Countries.Find(Id);
                _context.Countries.Remove(countryToRemove);
                _context.SaveChanges();
            }
            else
            {
                ModelState.Where(z => z.Value.Errors.Count > 0).ToList();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddNewCountry(CreateCountryViewModel newCountry)
        {
            if (ModelState.IsValid)
            {
                var country = new Country()
                {
                    CountryName = newCountry.CountryName,
                };
                _context.Countries.Add(country);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}