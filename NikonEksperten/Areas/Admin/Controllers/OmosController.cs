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
            

            return View(fomos.Get(1));
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase billede, Omos O, string oldpic)
        {

       

                if (billede != null)
                {
                    string path = Request.PhysicalApplicationPath + "Content/Images/OmosBilleder/";
                    string file = UP.UploadImage(billede, path, 400, true);
                    O.Billede = file;

                }
                else
                {
                    O.Billede = oldpic;
                }

                fomos.Update(O);


           

        


            

            return View(O);
        }


    }
}