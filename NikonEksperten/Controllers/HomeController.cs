﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult SoegeResultater()
        {
            var list = TempData["list"] as List<Produkter>;
            return View(list);
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
                TempData["list"] = pl;
                return RedirectToAction("SoegeResultater");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Produkter(int id = 0)
        {
            if (id != 0)
            {
                facProdukter fp = new facProdukter();
                ViewBag.Kategori = fkat.Get(id).KategoriNavn;
                return View(fp.GetBy("KategoriID", id));
            }
            return RedirectToAction("Kategorier");
        }
        public ActionResult Produkt(int id = 0)
        {
            if (id != 0)
            {
                facProdukter fp = new facProdukter();
                return View(fp.Get(id));
            }

                return RedirectToAction("Kategorier");

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                facBruger bf = new facBruger();

                Bruger bruger = bf.Login(Email, Password);

                if (bruger.ID > 0)
                {
                    FormsAuthentication.SetAuthCookie(bruger.ID.ToString(), false);
                    Session["UserID"] = bruger.ID;
                    Session.Timeout = 120;
                    @ViewBag.Loggedin = "Velkommen " + bruger.Email;
                    return RedirectToAction("Index", "CMS", new { area = "Admin" });
                }
                else
                {
                    
                    @ViewBag.Loggedin = "Fejl i login";
                    return RedirectToAction("Login");
                }
                
            }
            return RedirectToAction("Login");
        }
    }
}