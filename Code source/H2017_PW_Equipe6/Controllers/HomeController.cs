using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H2017_PW_Equipe6.Models;

namespace H2017_PW_Equipe6.Controllers
{
    public class HomeController : Controller
    {
        private H2017_PW_Equipe6Entities db = new H2017_PW_Equipe6Entities();
        private System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
        private int idClub;

        public HomeController()
        {
            idClub = Properties.Settings.Default.idClub;
        }

        public ActionResult Index()
        {
            var photosClub = db.PhotoClubs.Where(p => p.idCLUB == idClub).ToArray();
            int nbPhotoCarrousel = 0;

            for (int i = 0; i < photosClub.Length; i++)
            {
                if (photosClub[i].pathFichier.Contains("carrousel"))
                {
                    ViewData["carrousel" + nbPhotoCarrousel] = photosClub[i].pathFichier;
                    nbPhotoCarrousel++;
                }
            }
            ViewData["nbPhotoCarrousel"] = nbPhotoCarrousel;

            //Communication
            Communication[] com = db.Communications.Where(c => c.Utilisateur.idCLUB == idClub).OrderByDescending(c => c.dateCOM).ToArray();
            int nbCom = (com.Length < 4) ? com.Length : 3;
            ViewData["nbCom"] = nbCom;
            for (int i = 0; i < nbCom; i++)
            {
                ViewData["comTitle" + i] = com[i].titreCOM;
                ViewData["comDescription" + i] = com[i].contenuCOM;
            }

            return View(com);
        }

        public ActionResult APropos()
        {
            Club club = db.Clubs.Find(1);
            if (club == null)
            {
                return HttpNotFound();
            }

            return View(club);
        }

        public ActionResult Contact()
        {
            Club club = db.Clubs.Find(1);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        public ViewResult About()
        {
            throw new NotImplementedException();
        }
    }
}