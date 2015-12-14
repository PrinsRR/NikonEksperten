using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo.Factories;

namespace NikonEksperten.Areas.Admin.Controllers
{
    public class CMSController : Controller
    {
        facKategori facKat = new facKategori();
        facKontakt facKon = new facKontakt();
        facOmos facOm = new facOmos();
        facProdukter facPro = new facProdukter();
        // GET: Admin/CMS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kategorier()
        {

            return View(facKat.GetAll());

        }
    }
}