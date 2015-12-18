using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo;
using NikonRepo.Factories;

namespace NikonEksperten.Areas.Admin.Controllers
{
    [Authorize]
    public class CMSProController : Controller
    {
        facProdukter Fpro = new facProdukter();
        Uploader UP = new Uploader();
        facKategori Fkat = new facKategori();
        // GET: Admin/CMSPro
        public ActionResult Index()
        {
            
            return View(Fpro.GetAll());
        }


        public ActionResult Addpro()
        {
            
            return View( Fkat.GetAll());

        }
        [HttpPost]
        public ActionResult Addpro(HttpPostedFileBase pic, Produkter p)
        {
            if (ModelState.IsValid)
            {
                if(pic != null) {
                string path = Request.PhysicalApplicationPath + "/Content/Images/ProduktBilleder/";
                string file = UP.UploadImage(pic, path, 400, true);
                p.Billede = file;
               
                }
                else
                {
                    p.Billede = "Product-Image-Coming-Soon.png";
                }
            }
            
          
                
           
            Fpro.Insert(p);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            Fpro.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Rediger(int id)
        {
            
            return View(Fpro.KLP(id));
        }
        [HttpPost]
        public ActionResult Rediger(HttpPostedFileBase pic , Produkter p, string oldpic)
        {
            if (ModelState.IsValid)
            {
                if (pic != null) 
                {
                string path = Request.PhysicalApplicationPath + "/Content/Images/ProduktBilleder/";
                string file = UP.UploadImage(pic, path, 400, true);

                p.Billede = file;
                    
                }
                else
                {
                    p.Billede = oldpic;
                   
                }
                 Fpro.Update(p);
                
            }
         
            return RedirectToAction("Index");
           

        }

    }
}