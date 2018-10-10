using Microsoft.AspNet.Identity;
using SEP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            List<PersonViewModel> li = new List<PersonViewModel>();
            PhoneBookDbEntities ent = new PhoneBookDbEntities();
            var dblist = ent.Person.ToList();
            foreach (var i in dblist)
            {
                    PersonViewModel person = new PersonViewModel();
                    person.PersonId = i.PersonId;
                    person.FirstName = i.FirstName;
                    person.LastName = i.LastName;
                    person.MiddleName = i.MiddleName;
                    person.DateOfBirth = Convert.ToDateTime(i.DateOfBirth);
                    person.AddedBy = User.Identity.GetUserId();
                    person.AddedOn = Convert.ToDateTime(i.AddedOn);
                    person.HomeAddress = i.HomeAddress;
                    person.HomeCity = i.HomeCity;
                    person.FaceBookAccountId = i.FaceBookAccountId;
                    person.LinkedInId = i.LinkedInId;
                    person.UpdateOn = Convert.ToDateTime(i.UpdateOn);
                    person.ImagePath = i.ImagePath;
                    person.TwitterId = i.TwitterId;
                    person.EmailId = i.EmailId;
                    li.Add(person);
                

            }
            return View(li);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities ent = new PhoneBookDbEntities();
                Person p = new Person();
                p.FirstName = collection.FirstName;
                p.MiddleName = collection.MiddleName;
                p.LastName = collection.LastName;
                p.DateOfBirth = collection.DateOfBirth;
                p.AddedBy = User.Identity.GetUserId();
                p.AddedOn = DateTime.Now;
                p.HomeAddress = collection.HomeAddress;
                p.HomeCity = collection.HomeCity;
                p.FaceBookAccountId = collection.FaceBookAccountId;
                p.LinkedInId = collection.LinkedInId;
                p.ImagePath = collection.ImagePath;
                p.TwitterId = collection.TwitterId;
                p.EmailId = collection.EmailId;
                ent.Person.Add(p);
                ent.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                var i = db.Person.Where(y => y.PersonId == id).First();

                i.FirstName = collection.FirstName;
                i.LastName = collection.LastName;
                i.MiddleName = collection.MiddleName;
                i.DateOfBirth = collection.DateOfBirth;
                //i.AddedBy = i.AddedBy;
                //i.AddedOn = Convert.ToDateTime(i.AddedOn);
                i.HomeAddress = i.HomeAddress;
                i.HomeCity = i.HomeCity;
                i.FaceBookAccountId = i.FaceBookAccountId;
                i.LinkedInId = i.LinkedInId;
                i.UpdateOn = DateTime.Now;
                i.ImagePath = i.ImagePath;
                i.TwitterId = i.TwitterId;
                i.EmailId = i.EmailId;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
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
