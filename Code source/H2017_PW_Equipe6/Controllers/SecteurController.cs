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
    public class SecteurController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();
        private int idClub;

        public SecteurController()
        {
            idClub = Properties.Settings.Default.idClub;
        }

        // GET: /Secteur/
        public ActionResult Index()
        {
            var secteur = db.Secteurs;
            return View(secteur.ToList());
        }

        // GET: /Secteur/Details/5
        public ActionResult Details()
        {
            List<Secteur> secteurs;
            secteurs = db.Secteurs.Where(p => p.idCLUB == idClub).ToList();
            return View(secteurs);
        }

        // GET: /Secteur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Secteur> secteurs;
            secteurs = db.Secteurs.Where(p => p.idCLUB == idClub && p.idSECTEUR == id).ToList();
            if (secteurs == null)
            {
                return HttpNotFound();
            }
            return View(secteurs);
        }

        // POST: /Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secteur secteur = db.Secteurs.Find(id);
            db.Secteurs.Remove(secteur);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        // GET: /Secteur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Secteur> secteurs;
            secteurs = db.Secteurs.Where(p => p.idCLUB == idClub && p.idSECTEUR == id).ToList();

            if (secteurs == null)
            {
                return HttpNotFound();
            }
            //ViewBag.TypeSECTEUR = new SelectList(db.REF_Secteur, "idSECTEUR", "NomSECTEUR", niveau.TypeSECTEUR);
            return View(secteurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Secteur secteur)
        {
            var secteurToUpdate = db.Secteurs.Find(secteur.idSECTEUR);

            if (TryUpdateModel(secteurToUpdate, "", new string[] { "nomSECTEUR", "descriptionSECTEUR" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Details");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(secteurToUpdate);
        }

        // GET: /Secteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Secteur/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSECTEUR,descriptionSECTEUR,nomSECTEUR")] Secteur secteur)
        {
            if (ModelState.IsValid)
            {
                secteur.idCLUB = idClub;
                db.Secteurs.Add(secteur);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View();
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
