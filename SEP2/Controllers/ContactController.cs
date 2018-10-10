using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            PhoneBookDbEntities ent = new PhoneBookDbEntities();
            List<ContactViewModel> list = new List<ContactViewModel>();
            var v = ent.Contacts.ToList();
            foreach(var i in v)
            {
                ContactViewModel c = new ContactViewModel();
                c.PersonId = i.PersonId;
                c.ContactNumber = i.ContactNumber;
                c.Type = i.Type;
                list.Add(c);
            }
            return View(list);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities ent = new PhoneBookDbEntities();
                Contact c = new Contact();
                c.PersonId = collection.PersonId;
                c.ContactNumber = collection.ContactNumber;
                c.Type = collection.Type;
                ent.Contacts.Add(c);
                ent.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
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

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
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
