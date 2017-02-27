using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using H2017_PW_Equipe6.Models;

namespace H2017_PW_Equipe6.Controllers
{
    public class CompetitionController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();
        private int idClub;

        public CompetitionController()
        {
            idClub = Properties.Settings.Default.idClub;
        }

        // GET: /Competition/
        public ActionResult Index()
        {
            return View(db.Competitions.ToList());
        }

        public ActionResult Liste()
        {
            return View(db.Competitions.ToList());
        }

        // GET: /Competition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // GET: /Competition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Competition/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCOMP,nomCOMP,dateDebutCOMP,dateFinCOMP,adresseCOMP,descriptionCOMP,urlFichierResultatsCOMP")] Competition competition, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                competition.idCLUB = idClub;
                db.Competitions.Add(competition);
                db.SaveChanges();

                foreach (var file in files)
                {
                    if (file.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        Directory.CreateDirectory(Server.MapPath("~/Content/media/photo/competition/" + competition.idCOMP + "/"));
                        file.SaveAs(Server.MapPath("~/Content/media/photo/competition/" + competition.idCOMP + "/" + fileName));
                        string filePath = competition.idCOMP + "/" + fileName;

                        db.P_INSERT_photo(competition.idCOMP, filePath);
                    }
                }

                return RedirectToAction("Liste");
            }

            return View(competition);
        }

        // GET: /Competition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: /Competition/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idCOMP,nomCOMP,dateDebutCOMP,dateFinCOMP,adresseCOMP,descriptionCOMP,urlFichierResultatsCOMP")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                competition.idCLUB = idClub;
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View(competition);
        }

        // GET: /Competition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: /Competition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competitions.Find(id);
            db.Competitions.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Liste");
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
