using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo.Factories;

namespace NikonEksperten.Controllers
{
    public class OmController : Controller
    {

        facOmos fomos = new facOmos();
        // GET: Om
        public ActionResult Index()
        {
            return View(fomos.Get(1));
        }
    }
}