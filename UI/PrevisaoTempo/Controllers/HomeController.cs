using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrevisaoTempo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CadastroCidade()
        {
            ViewBag.Message = "Página de cadastro";

            return View();
        }

        public ActionResult Previsao()
        {
            ViewBag.Message = "Verificar clima";

            return View();
        }
    }
}