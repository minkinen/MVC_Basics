using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Data;
using MVC_Basics.Models;
using MVC_Basics.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Basics.Controllers
{
    public class CitiesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CitiesViewModel citiesViewModelInstance = new CitiesViewModel();
            citiesViewModelInstance.Cities = _context.Cities.ToList();
            ViewBag.Countries = new SelectList(_context.Countries.ToList());
            return View("Index", citiesViewModelInstance);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                CitiesViewModel citiesViewModelSearchInstance = new CitiesViewModel();
                citiesViewModelSearchInstance.Cities = _context.Cities.ToList();
                ViewBag.Countries = new SelectList(_context.Countries.ToList());

                List<City> queryList = new List<City>();

                foreach (City c in citiesViewModelSearchInstance.Cities)
                {
                    bool searchHit = c.CityName.ToString().ToUpper().Contains(search.ToUpper()) || c.Country.CountryName.ToString().ToUpper().Contains(search.ToUpper());
                    if (searchHit == true)
                    {
                        queryList.Add(c);
                    }
                }

                citiesViewModelSearchInstance.Search = search;
                citiesViewModelSearchInstance.Cities = queryList;

                ViewBag.SearchMessage = "Search: " + search;

                return View("Index", citiesViewModelSearchInstance);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult DeleteCity(int Id)
        {
            if (ModelState.IsValid)
            {
                var cityToRemove = _context.Cities.Find(Id);
                _context.Cities.Remove(cityToRemove);
                _context.SaveChanges();
            }
            else
            {
                ModelState.Where(z => z.Value.Errors.Count > 0).ToList();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddNewCity(CreateCityViewModel newCity)
        {
            if (ModelState.IsValid)
            {
                var city = new City()
                {
                    CityName = newCity.CityName,
                    Country = _context.Countries.Where(c => c.CountryName == newCity.Country).FirstOrDefault(),
                };
                _context.Cities.Add(city);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}