using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramewrok;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        YöneticiManager ym = new YöneticiManager(new EfYöneticiDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        public ActionResult Index()
        {
            var yöneticivalues = ym.GetList();
            return View(yöneticivalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            ym.YöneticiAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueadminrole = (from c in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;

            var adminvalue = ym.GetById(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            admin.AdminStatus = true;
            ym.YöneticiUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}