using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using H2017_PW_Equipe6.Models;

namespace H2017_PW_Equipe6.Controllers
{
    public class ClubController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();

        // GET: /Club/
        public ActionResult Index()
        {
            return View(db.Clubs.ToList());
        }

        // GET: /Club/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: /Club/DetailsDescription
        public ActionResult DetailsDescription()
        {
            int id = Properties.Settings.Default.idClub;
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: /Club/DetailsDescription
        public ActionResult DetailsCoord()
        {
            int id = Properties.Settings.Default.idClub;
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: /Club/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Club/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nom,adresse,ville,province,codePostal,numTelephone,courriel,description")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(club);
        }

        // GET: /Club/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: /Club/EditDescription/
        public ActionResult EditDescription()
        {
            int id = Properties.Settings.Default.idClub;
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDescription(Club club)
        {
            var clubToUpdate = db.Clubs.Find(club.id);

            if (TryUpdateModel(clubToUpdate, "", new string[] { "description"}))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("DetailsDescription");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(clubToUpdate);
        }


        // GET: /Club/EditCoord/
        public ActionResult EditCoord()
        {
            int id = Properties.Settings.Default.idClub;
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCoord(Club club)
        {
            var clubToUpdate = db.Clubs.Find(club.id);

            if (TryUpdateModel(clubToUpdate, "", new string[] { "nom", "adresse", "ville", "province", "codePostal", "numTelephone", "courriel" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("DetailsCoord");
                }
                catch (DataException dex)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    Console.WriteLine(dex.ToString());
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(clubToUpdate);
        }

        // POST: /Club/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nom,adresse,ville,province,codePostal,numTelephone,courriel,description")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        // GET: /Club/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: /Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
