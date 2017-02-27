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
    public class NiveauController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();
        private int idClub;

        public NiveauController()
        {
            idClub = Properties.Settings.Default.idClub;
        }

        public ActionResult Index()
        {
            var niveaux = db.Niveaux.Where(n => n.Secteur.idCLUB == idClub);
            var secteurs = db.Secteurs.Where(s => s.idCLUB == idClub);
            return View(secteurs.ToList());
        }

        // GET: /Niveau/
        public ActionResult Liste()
        {
            var niveaux = db.Niveaux.Include(n => n.Secteur).Where(n => n.Secteur.idCLUB == idClub);
            return View(niveaux.ToList());
        }

        // GET: /Niveau/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveaux.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // GET: /Niveau/Create
        public ActionResult Create()
        {
            ViewBag.TypeSECTEUR = new SelectList(db.Secteurs, "idSECTEUR", "nomSECTEUR");
            return View();
        }

        // POST: /Niveau/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idNIVEAU,TypeSECTEUR,nomNIVEAU,descriptionNIVEAU,ordreAffichageNIVEAU")] Niveau niveau)
        {
            if (ModelState.IsValid)
            {
                db.Niveaux.Add(niveau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeSECTEUR = new SelectList(db.Secteurs, "idSECTEUR", "nomSECTEUR", niveau.TypeSECTEUR);
            return View(niveau);
        }

        // GET: /Niveau/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveaux.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeSECTEUR = new SelectList(db.Secteurs, "idSECTEUR", "nomSECTEUR", niveau.TypeSECTEUR);
            return View(niveau);
        }

        // POST: /Niveau/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idNIVEAU,TypeSECTEUR,nomNIVEAU,descriptionNIVEAU,ordreAffichageNIVEAU")] Niveau niveau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niveau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeSECTEUR = new SelectList(db.Secteurs, "idSECTEUR", "nomSECTEUR", niveau.TypeSECTEUR);
            return View(niveau);
        }

        // GET: /Niveau/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveaux.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // POST: /Niveau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Niveau niveau = db.Niveaux.Find(id);
            db.Niveaux.Remove(niveau);
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
