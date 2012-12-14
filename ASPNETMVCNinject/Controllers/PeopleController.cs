using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonModel;
using ASPNETMVCNinject.Models;
using PersonRepository;

namespace ASPNETMVCNinject.Controllers
{   
    public class PeopleController : Controller
    {
        private readonly IRepositoryMethods<Person> _peopleRepository; 

        public PeopleController(IRepositoryMethods<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        //
        // GET: /People/
        public ViewResult Index()
        {
            return View(_peopleRepository.AllIncluding().ToList());
        }

        //
        // GET: /People/Details/5
        public ViewResult Details(long id)
        {
            return View(_peopleRepository.Find(id));
        }

        //
        // GET: /People/Create
        public ActionResult Create()
        {
            return View(new Person());
        } 

        //
        // POST: /People/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _peopleRepository.InsertOrUpdate(person);
                _peopleRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }
        
        //
        // GET: /People/Edit/5
        public ActionResult Edit(long id)
        {
            return View(_peopleRepository.Find(id));
        }

        //
        // POST: /People/Edit/5
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _peopleRepository.InsertOrUpdate(person);
                _peopleRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }

        //
        // GET: /People/Delete/5
        public ActionResult Delete(long id)
        {
            return View(_peopleRepository.Find(id));
        }

        //
        // POST: /People/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            _peopleRepository.Delete(id);
            _peopleRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}