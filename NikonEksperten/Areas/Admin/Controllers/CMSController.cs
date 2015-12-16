using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo;
using NikonRepo.Factories;

namespace NikonEksperten.Areas.Admin.Controllers
{
    public class CMSController : Controller
    {
        facKategori facKat = new facKategori();
        facKontakt facKon = new facKontakt();
        facOmos facOm = new facOmos();
        facProdukter facPro = new facProdukter();
        Uploader UP = new Uploader();
        // GET: Admin/CMS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kategorier()
        {

            return View(facKat.GetAll());

        }

        public ActionResult Rediger(int id)
        {
          
            return View(  facKat.Get(id));
        }

        [HttpPost]
        public ActionResult Rediger(HttpPostedFileBase billede, Kategori k, string oldpic)
        {
       

            if (billede != null)
            {
                string path = Request.PhysicalApplicationPath + "Content/Images/KategoriBilleder/";
            string file = UP.UploadImage(billede, path, 400, true);
                k.Billede = file;
            }
            else
            {
                k.Billede = oldpic;
            }

            facKat.Update(k);
            return RedirectToAction("Kategorier");

        }
        
        public ActionResult AddKat()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Addkat(Kategori k, HttpPostedFileBase billede)
        {
            if (ModelState.IsValid)
                

            {
                string path = Request.PhysicalApplicationPath + "Content/Images/KategoriBilleder/";
                string file = UP.UploadImage(billede, path, 400, true);
                k.Billede = file;
                
               
            }
            else
            {
                k.Billede = "Product-Image-Coming-Soon.png";
            }
            facKat.Insert(k);
            return RedirectToAction("Kategorier");
        }



        public ActionResult Delete(int id)
        {
            facKat.Delete(id);
            return RedirectToAction("Kategorier");
        }
    }
}