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
        // GET: Client
        public ActionResult Index()
        {
            var service = CreateClientService();
            var model = service.GetClients();

            return View(model);
        }

        //GET: Client/Create
        public ActionResult Create()
        {

        }
    }
}