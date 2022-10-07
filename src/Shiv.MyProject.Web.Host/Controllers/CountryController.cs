using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shiv.MyProject.Controllers;
using Shiv.MyProject.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Shiv.MyProject.Web.Host.Controllers
{
    public class CountryController : MyProjectControllerBase
    {
        private MyProjectDbContext myProjectDbContext;
        private static string msg="";

        public CountryController(MyProjectDbContext myProjectDbContext)
        {
            this.myProjectDbContext = myProjectDbContext;
        }

        // GET: CountryController
        public IActionResult Index()
        {
            ViewBag.msg = msg;
            var list = myProjectDbContext.Mycountries.Select(x => new MyCountry { CountryName = x.country, id = x.id }).ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create([FromForm] MyCountry country)
        {

            if (!ModelState.IsValid)
                return View(country);
            myProjectDbContext.Mycountries.Add(new Countries
            {
                country = country.CountryName,
            });


            myProjectDbContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            return View(myProjectDbContext.Mycountries.Select(x => new MyCountry
            {
                id = x.id,
                CountryName = x.country,
            }).Where(x => x.id == id).FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MyCountry country)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(country);

                var c = myProjectDbContext.Mycountries.Find(country.id);

                c.country = country.CountryName;
                myProjectDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(country);
            }
        }

        public ActionResult Delete(int id)
        {


            if (myProjectDbContext.Mystates.Where(x => x.Countriesid == id).FirstOrDefault() == null)
            {
                myProjectDbContext.Mycountries.Remove(myProjectDbContext.Mycountries.Find(id));
                myProjectDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
                msg = "";
            }
            else
            {
                msg = "referenced with state dac.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }


    public class MyCountry
    {
        [Required(ErrorMessage = "Country can not be empty.")]
        [DisplayName("Country")]
        public string CountryName { get; set; }

        public int id { get; set; }
        public bool isError { get; set; }
        public string Message { get; set; }

    }
}
