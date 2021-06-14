using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramewrok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context _context = new Context();
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetById(id);
            if (contactvalues != null)
            {
                contactvalues.ContactID = cm.GetById(id).ContactID;
                contactvalues.ContactDate = cm.GetById(id).ContactDate;
                contactvalues.Message = cm.GetById(id).Message;
                contactvalues.Subject = cm.GetById(id).Subject;
                contactvalues.UserMail = cm.GetById(id).UserMail;
                contactvalues.UserName = cm.GetById(id).UserName;
                contactvalues.IsRead = true;
                cm.ContactUpdate(contactvalues);
            }
            return View(contactvalues);
        }

        public PartialViewResult ContactSideBarPartial()
        {
            var receiverMail = _context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com").ToString();
            ViewBag.receiverMail = receiverMail;

            var senderMail = _context.Messages.Count(x => x.SenderMail == "admin@gmail.com").ToString();
            ViewBag.senderMail = senderMail;

            var contact = _context.Contacts.Count().ToString();
            ViewBag.contact = contact;

            var draft = _context.Messages.Count(x => x.isDraft == true).ToString();
            ViewBag.draft = draft;

            return PartialView();
        }    
    }
}