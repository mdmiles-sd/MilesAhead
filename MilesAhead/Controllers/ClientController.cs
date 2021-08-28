using Microsoft.AspNet.Identity;
using MilesAhead.Models;
using MilesAhead.Models.ClientModels;
using MilesAhead.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MilesAhead.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateClientService();
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
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your Client was created.";
                return RedirectToAction("Index");
            }

            
            ModelState.AddModelError("", "Client could not be created");
            return View(model);
        }

        // GET: Note/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateClientService();
            var model = service.GetClientById(id);
            return View(model);
        }

        // GET: Note/Edit/{id}
        public ActionResult Edit(int id)
        {

            var service = CreateClientService();
            var detail = service.GetClientById(id);
            var model =
                new ClientEdit
                {
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Age = detail.Age,
                    BirthDate = detail.BirthDate,
                    Sex = detail.Sex,
                    Height = detail.Height,
                    Weight = detail.Weight
                };
            
            return View(model);
        }

        // POST: Note/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid)
            {
                

                return View(model);
            }

            if (model.ClientID != id)
            {
                
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Your Client was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Client could not be updated.");
            return View();
        }

        // GET: Note/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateClientService();
            var model = service.GetClientById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClientService();
            service.DeleteClient(id);

            TempData["SaveResult"] = "Your Client was deleted.";
            return RedirectToAction("Index");
        }

        private ClientServices CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientServices(userId);
            return service;
        }



    }
}
