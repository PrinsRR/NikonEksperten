using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikonRepo;
using NikonRepo.Factories;

namespace NikonEksperten.Areas.Admin.Controllers
{
    public class CMSController : Controller
    {
        private facSlider fslider = new facSlider();
        private facKategori facKat = new facKategori();
        private facKontakt facKon = new facKontakt();
        private facOmos facOm = new facOmos();
        private facProdukter facPro = new facProdukter();
        private Uploader UP = new Uploader();
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

            return View(facKat.Get(id));
        }

        [HttpPost]
        public ActionResult Rediger(HttpPostedFileBase billede, Kategori k, string oldpic)
        {
            if (ModelState.IsValid)
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


            }
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
                if (billede != null)
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


            }
            return RedirectToAction("Kategorier");
        }

        public ActionResult Delete(int id)
        {
            facKat.Delete(id);
            return RedirectToAction("Kategorier");
        }

        public ActionResult Sliders()
        {
            return View(fslider.GetAll());
        }

        [HttpPost]
        public string EditSlide(HttpPostedFileBase pic, int id)
        {

            Slider slide = new Slider();
            if (ModelState.IsValid)
            {

                if (pic != null)
                {

                    Uploader u = new Uploader();
                    string path = Request.PhysicalApplicationPath + "Content/Images/SliderBilleder/";
                    string file = Path.GetFileName(u.UploadImage(pic, path, 960, true));


                    slide.ID = id;
                    slide.Img = Path.GetFileName(file);
                    fslider.Update(slide);

                }
                else
                {

                }

            }
            return slide.Img;
        }

        [HttpPost]
        public void RemoveSlide(int id)
        {
            string file = fslider.Get(id).Img;
            string path = Request.PhysicalApplicationPath + "Content/Images/SliderBilleder/" + file;
            System.IO.File.Delete(path);
            fslider.Delete(id);
        }

        [HttpPost]
        public ActionResult AddSlide(HttpPostedFileBase slidepic)
        {

            Slider slide = new Slider();
            if (ModelState.IsValid)
            {

                if (slidepic != null)
                {

                    Uploader u = new Uploader();
                    string path = Request.PhysicalApplicationPath + "Content/Images/SliderBilleder/";
                    string file = Path.GetFileName(u.UploadImage(slidepic, path, 960, true));

                    slide.Img = Path.GetFileName(file);
                    fslider.Insert(slide);
                }
            }
            return RedirectToAction("Sliders");
        }
    }
}