using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shiv.MyProject.Controllers;
using Shiv.MyProject.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Shiv.MyProject.Web.Host.Controllers
{
    public class StateController : MyProjectControllerBase
    {
        private MyProjectDbContext myProjectDbContext;
        public static List<SelectListItem> countries;
        public StateController(MyProjectDbContext myProjectDbContext)
        {
            this.myProjectDbContext = myProjectDbContext;
            countries = myProjectDbContext.Mycountries.Select(x => new SelectListItem { Text = x.country, Value = x.id.ToString() }).ToList();

            countries.Insert(0, new SelectListItem { Text = "Select Country", Value = "" });
            ViewBag.countries=countries;
        }

        // GET: CountryController
        public IActionResult Index()
        {
            var list = myProjectDbContext.Mystates.Select(x => new MyStates
            {
                StateName = x.state,
                id = x.id,
                cid = x.id,
                Country = myProjectDbContext.Mycountries.Where(y => y.id == x.Countriesid).FirstOrDefault().country
            }).ToList();
            return View(list);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.countries = countries;
            return View();
        }

        // GET: CountryController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countries = countries;
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create([FromForm] MyStates states)
        {
            try
            {
                ViewBag.countries = countries;
                if (!ModelState.IsValid)
                    return View(states);

                myProjectDbContext.Mystates.Add(new States
                {
                    state = states.StateName,
                    Countriesid = states.cid
                });

                myProjectDbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.countries = countries;
            var st = myProjectDbContext.Mystates.Select(x => new MyStates
            {
                id = x.id,
                StateName = x.state,
                cid = x.Countriesid
            }).Where(x => x.id == id).FirstOrDefault();
            return View(st);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MyStates state)
        {
            try
            {
                ViewBag.countries = countries;
                if (!ModelState.IsValid)
                    return View(state);

                var c = myProjectDbContext.Mystates.Find(state.id);

                c.state = state.StateName;
                c.Countriesid = state.cid;

                myProjectDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(state);
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            myProjectDbContext.Mystates.Remove(myProjectDbContext.Mystates.Find(id));
            myProjectDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //// POST: CountryController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }


    public class MyStates
    {
        [Required(ErrorMessage = "State can not be empty.")]
        [DisplayName("State")]
        public string StateName { get; set; }
        public string Country { get; set; }

        public int id { get; set; }

        [Required(ErrorMessage = "Please select country.")]
        public int cid { get; set; }
        public bool isError { get; set; }
        public string Message { get; set; }

    }
}
