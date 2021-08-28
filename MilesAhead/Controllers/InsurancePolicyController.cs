using Microsoft.AspNet.Identity;
using MilesAhead.Models;
using MilesAhead.Models.InsurancePolicyModels;
using MilesAhead.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilesAhead.Controllers
{
    [Authorize]
    public class InsurancePolicyController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateInsurancePolicyServices();
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
        public ActionResult Create(InsurancePolicyCreate model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var service = CreateInsurancePolicyServices();

            if (service.CreateInsurancePolicy(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            
            ModelState.AddModelError("", "Note could not be created");
            return View(model);
        }

        // GET: Note/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateInsurancePolicyServices();
            var model = service.GetClientById(id);
            return View(model);
        }

        // GET: Note/Edit/{id}
        public ActionResult Edit(int id)
        {

            var service = CreateInsurancePolicyServices();
            var detail = service.GetClientById(id);
            var model =
                new InsurancePolicyEdit
                {
                    CoverageAmount = detail.CoverageAmount,
                    TypeOfPolicy = detail.TypeOfPolicy,
                    
                };
            
            return View(model);
        }

        // POST: Note/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InsurancePolicyEdit model)
        {
            if (!ModelState.IsValid)
            {
                

                return View(model);
            }

            if (model.InsurancePolicyID != id)
            {
                
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateInsurancePolicyServices();

            if (service.UpdateInsurancePolicy(model))
            {
                TempData["SaveResult"] = "Your Insurance Policy was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Insurance Policy could not be updated.");
            return View();
        }

        // GET: Note/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateInsurancePolicyServices();
            var model = service.GetClientById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInsurancePolicyServices();
            service.DeleteInsurancePolicy(id);

            TempData["SaveResult"] = "Your Insurance Policy was deleted.";
            return RedirectToAction("Index");
        }

        private InsurancePolicyServices CreateInsurancePolicyServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InsurancePolicyServices(userId);
            return service;
        }      
        
    }
}