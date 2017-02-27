using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using H2017_PW_Equipe6.Models;
using System.Data.SqlClient;

namespace H2017_PW_Equipe6.Controllers
{
    public class HoraireController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();

        // GET: /Horaire/
        public ActionResult Index(int id)
        {
            //var groupes = db.Groupes.Include(g => g.NiveauSession);
            ViewData["idSecteur"] = id;
            return View();
            
        }

         // GET: /Horaire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoraireGroupe horairegroupe = db.HoraireGroupes.Find(id);
            if (horairegroupe == null)
            {
                return HttpNotFound();
            }
            return View(horairegroupe);
        }

        // GET: /Horaire/Create
        public ActionResult Create()
        {
            ViewBag.idGRP = new SelectList(db.Groupes, "idGRP", "descriptionGRP");
            ViewBag.idJOUR = new SelectList(db.REF_Jour, "idJOUR", "nomJOUR");
            return View();
        }

        // POST: /Horaire/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idHOR,idGRP,idJOUR,horaireDebut,horaireFin")] HoraireGroupe horairegroupe)
        {
            if (ModelState.IsValid)
            {
                db.HoraireGroupes.Add(horairegroupe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGRP = new SelectList(db.Groupes, "idGRP", "descriptionGRP", horairegroupe.idGRP);
            ViewBag.idJOUR = new SelectList(db.REF_Jour, "idJOUR", "nomJOUR", horairegroupe.idJOUR);
            return View(horairegroupe);
        }

        // GET: /Horaire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoraireGroupe horairegroupe = db.HoraireGroupes.Find(id);
            if (horairegroupe == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGRP = new SelectList(db.Groupes, "idGRP", "descriptionGRP", horairegroupe.idGRP);
            ViewBag.idJOUR = new SelectList(db.REF_Jour, "idJOUR", "nomJOUR", horairegroupe.idJOUR);
            return View(horairegroupe);
        }

        // POST: /Horaire/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idHOR,idGRP,idJOUR,horaireDebut,horaireFin")] HoraireGroupe horairegroupe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horairegroupe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGRP = new SelectList(db.Groupes, "idGRP", "descriptionGRP", horairegroupe.idGRP);
            ViewBag.idJOUR = new SelectList(db.REF_Jour, "idJOUR", "nomJOUR", horairegroupe.idJOUR);
            return View(horairegroupe);
        }

        // GET: /Horaire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoraireGroupe horairegroupe = db.HoraireGroupes.Find(id);
            if (horairegroupe == null)
            {
                return HttpNotFound();
            }
            return View(horairegroupe);
        }

        // POST: /Horaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoraireGroupe horairegroupe = db.HoraireGroupes.Find(id);
            db.HoraireGroupes.Remove(horairegroupe);
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
