using Microsoft.AspNet.Identity;
using MilesAhead.Models;
using MilesAhead.Models.ContactInfoModels;
using MilesAhead.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilesAhead.Controllers
{
    [Authorize]
    public class ContactInfoController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateContactInfoService();
            var model = service.GetClientLists();

            return View(model);
        }

        // GET: Note/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Note/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactinfoCreate model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var service = CreateContactInfoService();

            if (service.CreateContactInfo(model))
            {
                TempData["SaveResult"] = "Your Contact was created.";
                return RedirectToAction("Index");
            }

            
            ModelState.AddModelError("", "Contact could not be created");
            return View(model);
        }

        // GET: Note/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateContactInfoService();
            var model = service.GetContactInfoById(id);
            return View(model);
        }

        // GET: Note/Edit/{id}
        public ActionResult Edit(int id)
        {

            var service = CreateContactInfoService();
            var detail = service.GetContactInfoById(id);
            var model =
                new ContactInfoEdit
                {
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    PhoneNumber = detail.PhoneNumber,
                    Email = detail.Email,
                    BestTimeToCall = detail.BestTimeToCall
                };
            
            return View(model);
        }

        // POST: Note/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactInfoEdit model)
        {
            if (!ModelState.IsValid)
            {
                

                return View(model);
            }

            if (model.ContactInfoID != id)
            {
                
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateContactInfoService();

            if (service.UpdateContactInfo(model))
            {
                TempData["SaveResult"] = "Your Contact Info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Contact Info could not be updated.");
            return View();
        }

        // GET: Note/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateContactInfoService();
            var model = service.GetContactInfoById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateContactInfoService();
            service.DeleteContactInfo(id);

            TempData["SaveResult"] = "Your contact Info was deleted.";
            return RedirectToAction("Index");
        }

        private ContactInfoServices CreateContactInfoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContactInfoServices(userId);
            return service;
        }      
    }
}