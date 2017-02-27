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
    public class FichierCommunicationController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();

        // POST: /FichierCommunication/Delete/5
        public void Delete(int? id)
        {
            FichierCommunication fichier = null;
            if (id != null)  fichier = db.FichierCommunications.Find(id);
            if (fichier != null) 
            {
                db.FichierCommunications.Remove(fichier);
                db.SaveChanges();
            }
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
