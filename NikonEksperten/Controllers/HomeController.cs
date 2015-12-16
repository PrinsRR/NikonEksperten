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
        facKategori fkat = new facKategori();
        // GET: Home
        public ActionResult Index()
        {
            return View(fkat.GetForsideProdukter());
        }
        public ActionResult Kategorier()
        {
            return View(fkat.GetAll());
        }

        

    }
}