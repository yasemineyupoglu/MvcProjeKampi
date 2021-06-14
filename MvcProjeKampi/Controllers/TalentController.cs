using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramewrok;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TalentController : Controller
    {
        readonly private TalentManager tm = new TalentManager(new EfTalentDal());
        // GET: Talent
        [Authorize]
        public ActionResult Index()
        {
            return View(tm.GetList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Talent talent)
        {
            if (ModelState.IsValid)
            {
                tm.TalentAddBL(talent);
                return RedirectToAction("Index");
            }

            return View(talent);
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var talent = tm.GetById(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }
        [HttpPost]
        public ActionResult Edit(Talent talent)
        {
            if (ModelState.IsValid)
            {
                tm.TalentUpdate(talent);
                return RedirectToAction("Index");
            }
            return View(talent);
        }

        public ActionResult Delete(int id)
        {
            var talent = tm.GetById(id);
            if (talent != null)
            {
                tm.TalentDelete(talent);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }

        }

        public ActionResult Yetenekler()
        {
            return View(tm.GetList());
        }
    }
}