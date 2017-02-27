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
using System.Net.Mail;

namespace H2017_PW_Equipe6.Controllers
{
    public class CommunicationController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();
        private int idClub;

        public CommunicationController()
        {
            idClub = Properties.Settings.Default.idClub;
        }

        // GET: /Communication/
        public ActionResult Index()
        {
            var communications = db.Communications.Include(c => c.Utilisateur).Where(c => c.Utilisateur.idCLUB == idClub);
            return View(communications.OrderByDescending(c => c.dateCOM).ToList());
        }

        // GET: /Communication/Details/5
        public ActionResult Details()
        {
            var communications = db.Communications.Include(c => c.Utilisateur).Where(c => c.Utilisateur.idCLUB == idClub);
            return View(communications.OrderByDescending(c => c.dateCOM).ToList());
        }

        // GET: /Communication/Create
        public ActionResult Create()
        {
            ViewBag.secteurs = db.Secteurs.Where(s => s.idCLUB == idClub).ToList();
            ViewBag.niveaux = db.NiveauSessions.Where(n => n.Niveau.Secteur.idCLUB == idClub && n.Session.estActif == true).ToList();
            ViewBag.groupes = db.Groupes.Where(g => g.NiveauSession.Niveau.Secteur.idCLUB == idClub && g.NiveauSession.Session.estActif == true).ToList();
            return View();
        }

        // POST: /Communication/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NouvelleCommunication modeleCommunication, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                // TODO: Lié l'utilisateur connecté à la communication
                modeleCommunication.communication.idUTIL = 1;
                modeleCommunication.communication.dateCOM = DateTime.Now;

                db.Communications.Add(modeleCommunication.communication);
                db.SaveChanges();

                Communication communication = modeleCommunication.communication;
                List<String> pathFichiers = EnregistrerPiecesJointes(files, communication);
                
                // Envoie du courriel
                foreach(String courriel in GenererListeCourriels(modeleCommunication)) {
                    //EnvoyerCourriel(courriel, communication.titreCOM, communication.contenuCOM, pathFichiers);
                }

                return RedirectToAction("Details");
            }

            ViewBag.secteurs = db.Secteurs.Where(s => s.idCLUB == idClub).ToList();
            ViewBag.niveaux = db.NiveauSessions.Where(n => n.Niveau.Secteur.idCLUB == idClub && n.Session.estActif == true).ToList();
            ViewBag.groupes = db.Groupes.Where(g => g.NiveauSession.Niveau.Secteur.idCLUB == idClub && g.NiveauSession.Session.estActif == true).ToList();
            return View(modeleCommunication);
        }

        // GET: /Communication/Edit/5
        /*public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUTIL = new SelectList(db.Utilisateurs.Where(u => u.idCLUB == idClub), "idUTIL", "prenomUTIL", communication.idUTIL);
            return View(communication);
        }*/

        // POST: /Communication/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Communication communication, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                // TODO: Lié l'utilisateur connecté à la communication
                communication.idUTIL = 1;

                db.Entry(communication).State = EntityState.Modified;
                db.SaveChanges();

                EnregistrerPiecesJointes(files, communication);
            }
            return RedirectToAction("Details");
        }

        // GET: /Communication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            db.FichierCommunications.RemoveRange(communication.FichierCommunications);
            db.Communications.Remove(communication);
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



        protected List<String> EnregistrerPiecesJointes(HttpPostedFileBase[] files, Communication communication)
        {
            List<String> pathFichiers = new List<String>();

            try
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        Directory.CreateDirectory(Server.MapPath("~/Content/media/communication/" + communication.idCOM + "/"));
                        file.SaveAs(Server.MapPath("~/Content/media/communication/" + communication.idCOM + "/" + fileName));
                        string filePath = communication.idCOM + "/" + fileName;

                        db.P_INSERT_fichierCommunication(fileName, filePath, communication.idCOM);

                        pathFichiers.Add("~/Content/media/communication/" + filePath);
                    }
                }

                return pathFichiers;
            }
            catch (IOException e)
            {
                throw new Exception("Erreur lors de l'enregistrement de la pièce jointe. (" + e.Message + ")");
            }
        }

        protected List<String> GenererListeCourriels(NouvelleCommunication modeleCommunication)
        {
            List<String> courriels = new List<String>();

            // courriel par les secteurs
            List<int> idSecteurs = new List<int>();
            if (modeleCommunication.SelectedSecteurId != null)
                idSecteurs = modeleCommunication.SelectedSecteurId.ToList();
            foreach (int idSecteur in idSecteurs)
            {
                foreach (var membre in db.P_SELECT_MembreSessionActiveParSecteur(idSecteur))
                {
                    String courriel = membre.courriel;

                    if (!courriels.Contains(courriel))
                    {
                        courriels.Add(courriel);
                    }
                }
            }

            // courriels par niveauSession
            List<int> idNiveaux = new List<int>();
            if (modeleCommunication.SelectedNiveauId != null)
                idNiveaux = modeleCommunication.SelectedNiveauId.ToList();
            foreach (int idNiveau in idNiveaux)
            {
                foreach (var membre in db.P_SELECT_MembreSessionActiveParNiveauSession(idNiveau))
                {
                    String courriel = membre.courriel;

                    if (!courriels.Contains(courriel))
                    {
                        courriels.Add(courriel);
                    }
                }
            }

            // courriels par groupe
            List<int> idGroupes = new List<int>();
            if (modeleCommunication.SelectedGroupId != null)
                idGroupes = modeleCommunication.SelectedGroupId.ToList();
            foreach (int idGroupe in idGroupes)
            {
                Groupe groupe = db.Groupes.Find(idGroupe);
                foreach (var membre in groupe.Membres)
                {
                    String courriel = membre.courriel;

                    if (!courriels.Contains(courriel))
                    {
                        courriels.Add(courriel);
                    }
                }
            }

            return courriels;
        }

        protected void EnvoyerCourriel(String recipient, String subject, String body, List<String> pathAttachments)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(recipient));
            message.From = new MailAddress("truchon.hugo@cgmatane.qc.ca");  // mettre ici l'adresse no-reply du club
            message.Subject = subject;
            message.Body = body;

            if (pathAttachments.Count > 0)
            {
                foreach (var attachment in pathAttachments)
                {
                    message.Attachments.Add(new Attachment(HttpContext.Server.MapPath(attachment)));
                }
            }

            var smtp = new SmtpClient();
            var credential = new NetworkCredential
            {
                UserName = "truchon.hugo@cgmatane.qc.ca",
                Password = "monmotdepasse"
            };

            smtp.Credentials = credential;
            smtp.Host = "mail.cgmatane.qc.ca";
            smtp.Port = 25;
            smtp.EnableSsl = false;

            System.Threading.Thread.Sleep(2000); // pas une bonne idée avec un thread synchrone
            smtp.Send(message);
        }

    }
}
