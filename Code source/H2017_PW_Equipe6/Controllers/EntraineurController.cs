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
    public class EntraineurController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();
        private int idClub;

        public EntraineurController()
        {
            idClub = Properties.Settings.Default.idClub;
        }

        // GET: /Entraineur/
        public ActionResult Index()
        {
            var entraineurs = db.Entraineurs.Where(e => e.Utilisateur.idCLUB == idClub);
            return View(entraineurs.ToList());
        }

        // GET: /Entraineur/Details/5
        public ActionResult Details()
        {
            List<Entraineur> entraineurs = db.Entraineurs.Where(e => e.Utilisateur.idCLUB == idClub).ToList();
            
            return View(entraineurs);
        }

        // GET: /Entraineur/Create
        public ActionResult Create()
        {
            ViewBag.idUTIL = new SelectList(from u in db.Utilisateurs
                                            where u.idCLUB == idClub && (from ent in db.Entraineurs select ent).All(ent => ent.idUTIL != u.idUTIL)
                                            select u,"idUTIL", "nomUTIL");
            return View();
        }

        // POST: /Entraineur/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entraineur entraineur)
        {
            if (ModelState.IsValid)
            {
                if (db.Entraineurs.Where(ent => ent.idUTIL == entraineur.idUTIL).Count() == 0)
                {
                    db.Entraineurs.Add(entraineur);
                    db.SaveChanges();
                    return RedirectToAction("Details");
                }
                else
                {

                }
                
            }
            ViewBag.idUTIL = new SelectList(from u in db.Utilisateurs
                                            where u.idCLUB == idClub && (from ent in db.Entraineurs select ent).All(ent => ent.idUTIL != u.idUTIL)
                                            select u, "idUTIL", "nomUTIL", entraineur.idUTIL);
            return View(entraineur);
        }

        // GET: /Entraineur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entraineur entraineur = db.Entraineurs.Find(id);
            if (entraineur == null)
            {
                return HttpNotFound();
            }

            return View(entraineur);
        }

        // POST: /Entraineur/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Entraineur entraineur, Utilisateur utilisateur)
        {
            var entraineurToUpdate = db.Entraineurs.Find(entraineur.idENT);
            var utilisateurToUpdate = db.Utilisateurs.Find(utilisateur.idUTIL);

            utilisateurToUpdate.nomUTIL = utilisateur.nomUTIL;
            utilisateurToUpdate.prenomUTIL = utilisateur.prenomUTIL;
            utilisateurToUpdate.courrielUTIL = utilisateur.courrielUTIL;

            if (TryUpdateModel(entraineurToUpdate, "", new string[] { "descriptionENT", "photoENT", "estActifENT" }))
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

            if (ModelState.IsValid)
            {
                db.Entry(entraineur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View();
        }

        // GET: /Entraineur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entraineur entraineur = db.Entraineurs.Find(id);
            if (entraineur == null)
            {
                return HttpNotFound();
            }
            return View(entraineur);
        }

        // POST: /Entraineur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entraineur entraineur = db.Entraineurs.Find(id);
            db.Entraineurs.Remove(entraineur);
            db.SaveChanges();
            return RedirectToAction("Details");
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
