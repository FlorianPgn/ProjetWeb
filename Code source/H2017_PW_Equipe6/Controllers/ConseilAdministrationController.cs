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
    public class ConseilAdministrationController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();
        private int idClub;

        public ConseilAdministrationController()
        {
            idClub = Properties.Settings.Default.idClub;
        }

        // GET: /ConseilAdministration/
        public ActionResult Index()
        {
            var conseiladministrations = db.ConseilAdministrations.Include(c => c.REF_RoleCA).Where(c => c.REF_RoleCA.idClub == idClub);
            return View(conseiladministrations.ToList());
        }

        // GET: /ConseilAdministration/Details/
        public ActionResult Details()
        {
            List<ConseilAdministration> conseilAdministrations = db.ConseilAdministrations.Include(p => p.REF_RoleCA).Where(p => p.REF_RoleCA.idClub == idClub).ToList();
            if (conseilAdministrations == null)
            {
                return HttpNotFound();
            }
            return View(conseilAdministrations);
        }

        // GET: /ConseilAdministration/Create
        public ActionResult Create()
        {
            ViewBag.idROLECA = new SelectList(db.REF_RoleCA, "idROLECA", "descriptionROLECA");
            return View();
        }

        // POST: /ConseilAdministration/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idCA,nomCA,prenomCA,descriptionCA,idROLECA")] ConseilAdministration conseiladministration)
        {
            if (ModelState.IsValid)
            {
                db.ConseilAdministrations.Add(conseiladministration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idROLECA = new SelectList(db.REF_RoleCA.Where(p => p.idClub == idClub), "idROLECA", "descriptionROLECA", conseiladministration.idROLECA);
            return View(conseiladministration);
        }

        // GET: /ConseilAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConseilAdministration conseiladministration = db.ConseilAdministrations.Find(id);
            if (conseiladministration == null)
            {
                return HttpNotFound();
            }
            ViewBag.idROLECA = new SelectList(db.REF_RoleCA.Where(p => p.idClub == idClub), "idROLECA", "descriptionROLECA", conseiladministration.idROLECA);
            return View(conseiladministration);
        }

        // POST: /ConseilAdministration/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idCA,nomCA,prenomCA,descriptionCA,idROLECA")] ConseilAdministration conseiladministration)
        {
            var conseilToUpdate = db.ConseilAdministrations.Find(conseiladministration.idCA);

            if (TryUpdateModel(conseilToUpdate, "", new string[] { "nomCA", "prenomCA", "descriptionCA", "idROLECA" }))
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
            return View(conseilToUpdate);
        }

        // GET: /ConseilAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConseilAdministration conseiladministration = db.ConseilAdministrations.Find(id);
            if (conseiladministration == null)
            {
                return HttpNotFound();
            }
            return View(conseiladministration);
        }

        // POST: /ConseilAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConseilAdministration conseiladministration = db.ConseilAdministrations.Find(id);
            db.ConseilAdministrations.Remove(conseiladministration);
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
