using Microsoft.AspNet.Identity;
using MilesAhead.Models;
using MilesAhead.Models.BeneficiaryModels;
using MilesAhead.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace MilesAhead.Controllers
{
    [Authorize]
    public class BeneficiaryController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateBeneficiaryService();
            var model = service.GetBeneficiaryDetailLists();

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
        public ActionResult Create(BeneficiaryCreate model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var service = CreateBeneficiaryService();

            if (service.CreateBeneficiary(model))
            {
                TempData["SaveResult"] = "Your Beneficiary was created.";
                return RedirectToAction("Index");
            }

           
            ModelState.AddModelError("", "Beneficiary could not be created");
            return View(model);
        }

        // GET: Note/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateBeneficiaryService();
            var model = service.GetBeneficiaryById(id);
            return View(model);
        }

        // GET: Note/Edit/{id}
        public ActionResult Edit(int id)
        {

            var service = CreateBeneficiaryService();
            var detail = service.GetBeneficiaryById(id);
            var model =
                new BeneficiaryEdit
                {
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Relationship = detail.Relationship,
                    PhoneNumber = detail.PhoneNumber
                };
            
            return View(model);
        }

        // POST: Note/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BeneficiaryEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.BeneficiaryID != id)
            {                
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBeneficiaryService();

            if (service.UpdateBeneficiary(model))
            {
                TempData["SaveResult"] = "Your Beneficiary was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Beneficiary could not be updated.");
            return View();
        }

        // GET: Note/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateBeneficiaryService();
            var model = service.GetBeneficiaryById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBeneficiaryService();
            service.DeleteBeneficiary(id);

            TempData["SaveResult"] = "Your Beneficiary was deleted.";
            return RedirectToAction("Index");
        }

        private BeneficiaryServices CreateBeneficiaryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeneficiaryServices(userId);
            return service;
        }

    }
}