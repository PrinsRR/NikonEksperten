using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo;
using NikonRepo.Factories;

namespace NikonEksperten.Controllers
{
    public class HomeController : Controller
    {
        private facKategori fkat = new facKategori();
        private facProdukter fp = new facProdukter();
        // GET: Home
        public ActionResult Index()
        {
            return View(fkat.GetForsideProdukter());
        }

        public ActionResult Kategorier()
        {
            return View(fkat.GetAll());
        }

        public ActionResult SoegeResultater(List<Produkter> pl)
        {
            return View(pl);
        }
        [HttpPost]
        public ActionResult SoegProdukter(int KatID, int Maxpris, string SoegeOrd)
        {

            if (ModelState.IsValid)
            {
                List<Produkter> pl = new List<Produkter>();

                foreach (Produkter produkt in fp.AdvSearch(KatID, Maxpris, SoegeOrd))
                {
                    pl.Add(produkt);
                }
                ViewBag.SoegError = "Korrekt Input";
                return View("SoegeResultater", pl);
            }
            return View("Index");
        }
    }
}