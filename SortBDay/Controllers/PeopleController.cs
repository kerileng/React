using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using SortBDay.Models;

namespace SortBDay.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            IList<Person> person = new List<Person>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/api/");

                var response = client.GetAsync("default");
                response.Wait();

                var responseResults = response.Result;

                if(responseResults.IsSuccessStatusCode)
                {
                    var readTask = responseResults.Content.ReadAsAsync<IList<Person>>();
                    readTask.Wait();

                    person = readTask.Result;
                }

            };
            
            return View(person.ToList<Person>());
        }

        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Person person = new Person();
                person.Name = collection["name"];
                person.Surname = collection["surname"];
                person.Birthday = collection["birthday"];

                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44354/api/");

                    var response = client.PostAsJsonAsync<Person>("default", person);
                    response.Wait();

                    var results = response.Result;
                    if(results.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError("", "error occured");
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
