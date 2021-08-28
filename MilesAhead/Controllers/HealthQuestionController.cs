using Microsoft.AspNet.Identity;
using MilesAhead.Models;
using MilesAhead.Models.BasicHealthQuestionModels;
using MilesAhead.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilesAhead.Controllers
{
    [Authorize]
    public class HealthQuestionController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateHealthQuestionServices();
            var model = service.GetBasicHealthQuestionLists();

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
        public ActionResult Create(BasicHealthQuestionCreate model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var service = CreateHealthQuestionServices();

            if (service.CreateBasicHealthQuestion(model))
            {
                TempData["SaveResult"] = "Your question was created.";
                return RedirectToAction("Index");
            }

            
            ModelState.AddModelError("", "Question could not be created");
            return View(model);
        }

        // GET: Note/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateHealthQuestionServices();
            var model = service.GetBasicHealthQuestionById(id);
            return View(model);
        }

        // GET: Note/Edit/{id}
        public ActionResult Edit(int id)
        {

            var service = CreateHealthQuestionServices();
            var detail = service.GetBasicHealthQuestionById(id);
            var model =
                new BasicHealthQuestionEdit
                {
                    IsDiabetic = detail.IsDiabetic,
                    IsSmoker = detail.IsSmoker,
                    IsTakingMedication = detail.IsTakingMedication
                };
            
            return View(model);
        }

        // POST: Note/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BasicHealthQuestionEdit model)
        {
            if (!ModelState.IsValid)
            {
               

                return View(model);
            }

            if (model.BasicHealthQuestionID != id)
            {
                
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHealthQuestionServices();

            if (service.UpdateBasicHealthQuestion(model))
            {
                TempData["SaveResult"] = "Your question was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your question could not be updated.");
            return View();
        }

        // GET: Note/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateHealthQuestionServices();
            var model = service.GetBasicHealthQuestionById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHealthQuestionServices();
            service.DeleteBasicHealthQuestion(id); 

            TempData["SaveResult"] = "Your Question was deleted.";
            return RedirectToAction("Index");
        }

        private HealthQuestionsServices CreateHealthQuestionServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HealthQuestionsServices(userId);
            return service;
        }


     
    }
}