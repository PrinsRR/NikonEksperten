using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo;
using NikonRepo.Factories;

namespace NikonEksperten.Areas.Admin.Controllers
{
    public class OmosController : Controller
    {
        facOmos fomos = new facOmos();
        Uploader UP = new Uploader();
        // GET: Admin/Omos
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase billede, Omos O)
        {
            if (billede != null)
            {
                string path = Request.PhysicalApplicationPath + "Content/Images/OmosBilleder/";
                string file = UP.UploadImage(billede, path, 400, true);
                O.Billede = file;
            }
            else
            {
                O.Billede = "Product-Image-Coming-Soon.png";
            }

            fomos.Insert(O);
            

            return View();
        }


    }
}