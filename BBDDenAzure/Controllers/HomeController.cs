using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBDDenAzure.Models;

namespace BBDDenAzure.Controllers
{
    public class HomeController : Controller
    {
        private BBDDAzureEntities db = new BBDDAzureEntities();

        // GET: Default
        public ActionResult Index()
        {
            var data = db.Persona;
            return View(data);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Persona.Find(id);
            return View(data);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View(new Persona());
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(Persona model)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(model);
                db.SaveChanges();
                return View(new Persona());
            }

            return View(model);
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Persona.Find(id);
            return View(data);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(Persona model)
        {

            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Persona.Find(id);
            return View(data);
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Persona model)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Remove(db.Persona.Find(id));
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}