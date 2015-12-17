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
            if (pl != null)
            {
                foreach (Produkter prod in pl)
                {
                    if (prod.Tilbudspris <= 0)
                    {
                        ViewBag.Tilbud = "IngenTilbud";
                        ViewBag.Istilbud = "<br/>";
                    }
                    else
                    {
                        ViewBag.Tilbud = "HarTilbud";
                        ViewBag.Istilbud = prod.Tilbudspris + " kr.";
                    }
                }
                @ViewBag.Encounters = pl.Count;
                
            }
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
                return RedirectToAction("SoegeResultater", pl);
            }
            return RedirectToAction("Index");
        }
    }
}