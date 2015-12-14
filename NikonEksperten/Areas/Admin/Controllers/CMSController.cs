using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikonEksperten.Areas.Admin.Controllers
{
    public class CMSController : Controller
    {
        // GET: Admin/CMS
        public ActionResult Index()
        {
            return View();
        }
    }
}