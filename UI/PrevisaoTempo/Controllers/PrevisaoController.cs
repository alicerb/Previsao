
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Previsao.Api;
using Previsao.Api.Client;
using Previsao.Api.Model;

namespace PrevisaoTempo.Controllers
{
    public class PrevisaoController : Controller
    {
        // GET: Previsao
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ObterPrevisao(int idAPI)
        {
            try
            {
                var listaPrevisao = ObterPrevisaoServico(idAPI);
                return Json(new { Lista = listaPrevisao }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        private Result<FiveDaysForecastResult> ObterPrevisaoServico(int idApi)
        {
            try
            {
                //consulta a previsao na api
                ClientConfig.ApiUrl = "http://api.openweathermap.org/data/2.5";
                ClientConfig.ApiKey = "c4a764a9a9fcc4e7734648c6c7ec8381";
                var result = FiveDaysForecast.GetByCityId(idApi);

                return result;

            }
            catch (Exception)
            {
                return new Result<FiveDaysForecastResult>();
            }
        }
    }
}