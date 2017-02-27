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
    public class TarifController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();

        // GET: /Tarif/
        public ActionResult Index()
        {
            var niveausessions = db.NiveauSessions.Include(n => n.Niveau).Include(n => n.Session);
            return View(niveausessions.ToList());
        }

        // GET: /Tarif/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NiveauSession niveausession = db.NiveauSessions.Find(id);
            if (niveausession == null)
            {
                return HttpNotFound();
            }
            return View(niveausession);
        }

        // GET: /Tarif/Create
        public ActionResult Create()
        {
            ViewBag.idNIVEAU = new SelectList(db.Niveaux, "idNIVEAU", "nomNIVEAU");
            ViewBag.idSESSION = new SelectList(db.Sessions, "idSESSION", "detailsAncienMembre");
            return View();
        }

        // POST: /Tarif/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idNIVEAU_SESSION,idNIVEAU,idSESSION,duree,tarif,affiliation,competitions,dateSuppression")] NiveauSession niveausession)
        {
            if (ModelState.IsValid)
            {
                db.NiveauSessions.Add(niveausession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNIVEAU = new SelectList(db.Niveaux, "idNIVEAU", "nomNIVEAU", niveausession.idNIVEAU);
            ViewBag.idSESSION = new SelectList(db.Sessions, "idSESSION", "detailsAncienMembre", niveausession.idSESSION);
            return View(niveausession);
        }

        // GET: /Tarif/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NiveauSession niveausession = db.NiveauSessions.Find(id);
            if (niveausession == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNIVEAU = new SelectList(db.Niveaux, "idNIVEAU", "nomNIVEAU", niveausession.idNIVEAU);
            ViewBag.idSESSION = new SelectList(db.Sessions, "idSESSION", "detailsAncienMembre", niveausession.idSESSION);
            return View(niveausession);
        }

        // POST: /Tarif/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idNIVEAU_SESSION,idNIVEAU,idSESSION,duree,tarif,affiliation,competitions,dateSuppression")] NiveauSession niveausession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niveausession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNIVEAU = new SelectList(db.Niveaux, "idNIVEAU", "nomNIVEAU", niveausession.idNIVEAU);
            ViewBag.idSESSION = new SelectList(db.Sessions, "idSESSION", "detailsAncienMembre", niveausession.idSESSION);
            return View(niveausession);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "dateSuppression")] NiveauSession niveauSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niveauSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View(niveauSession);
        }

        // POST: /Tarif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NiveauSession niveausession = db.NiveauSessions.Find(id);
            db.NiveauSessions.Remove(niveausession);
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
