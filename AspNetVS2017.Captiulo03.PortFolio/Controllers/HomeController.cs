using AspNetVS2017.Captiulo03.PortFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Captiulo03.PortFolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "JBS.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Mensagem = "Entre em contato";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContatoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return View();
        }
    }
}