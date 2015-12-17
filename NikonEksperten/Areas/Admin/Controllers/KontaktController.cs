using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo;
using NikonRepo.Factories;

namespace NikonEksperten.Areas.Admin.Controllers
{
    public class KontaktController : Controller
    {
        facKontakt fkon = new facKontakt();
        // GET: Admin/Kontakt
        public ActionResult Index()
        {
           
            
            return View(fkon.Get(1));
        }

        [HttpPost]
        public ActionResult Index(Kontakt k)
        {
            if (ModelState.IsValid)
            {
                fkon.Update(k);
            }
            

            return View(k);
        }

    }
}