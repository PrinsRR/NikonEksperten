using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo.Factories;

namespace NikonEksperten.Controllers
{
    public class KontakController : Controller
    {
        private facKontakt fkon = new facKontakt();
        // GET: Kontak
        public ActionResult Index()
        {
            return View(fkon.Get(1));
        }
    }
}