using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class İstatistikController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var sonuc = context.Categories.Count();
            var sonuc2 = context.Headings.Count(x => x.Category.CategoryID == 7);
            var sonuc3 = context.Writers.Count(x => x.WriterName.Contains("a"));
            var sonuc4 = context.Headings.Max(x => x.Category.CategoryName);
            var sonuc5 = context.Categories.Count(x => x.CategoryStatus == true);
            var sonuc6 = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.CategoryCount = sonuc;
            ViewBag.Heading = sonuc2;
            ViewBag.Writer = sonuc3;
            ViewBag.HeadingMax = sonuc4;
            ViewBag.StatusFark = (sonuc5 - sonuc6);

            return View();
        }
    }
}