
using Previsao.Api;
using Previsao.Api.Client;
using PrevisaoTempo.Application;
using PrevisaoTempo.Application.Interfaces;
using PrevisaoTempo.Application.ViewModels;
using PrevisaoTempo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PrevisaoTempo.Controllers
{
    public class CadastroCidadeController : Controller
    {

        private readonly ICidadeAppService _cidadeAppService;

        public CadastroCidadeController(ICidadeAppService cidadeAppService)
        {
            _cidadeAppService = cidadeAppService;
        }

        // GET: CadastroCidade
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObterCidades()
        {
            try
            {
                var listaCidadesModel = new List<CidadeViewModel>();
                var listaCidades = _cidadeAppService.ObterTodos();

                foreach (var cidade in listaCidades)
                {
                    CidadeViewModel cidadeModel = new CidadeViewModel()
                    {
                        Nome = cidade.Nome,
                        Id = cidade.Id,
                        OpenWeatherId = cidade.OpenWeatherId
                    };

                    listaCidadesModel.Add(cidadeModel);
                }

                return Json(new { Lista = listaCidadesModel }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CadastrarCidade(string nomeCidade)
        {
            try
            {
                //verifica se a cidade existe na api do openweather
                ClientConfig.ApiUrl = "http://api.openweathermap.org/data/2.5";
                ClientConfig.ApiKey = "a75f4b55aed47dd3b7b65f58a242855f";

                var result = CurrentWeather.GetByCityName(nomeCidade);
                var nova = new CidadeViewModel();

                if (!result.Success || result.Item == null)
                {
                    nova.Sucesso = false;
                    nova.Mensagem = "A cidade informada não foi encontrada na API do OpenWeather.";
                    return Json(new JavaScriptSerializer().Serialize(nova));
                }


                //var nova = new CidadeViewModel();
                nova.Nome = result.Item.City;
                nova.OpenWeatherId = result.Item.CityId;

                var response = _cidadeAppService.Adicionar(nova);
                return Json(new JavaScriptSerializer().Serialize(response));
                
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Cadastro()
        {
            return View("CadastroCidade");
        }

        public ActionResult Previsao(int idAPI)
        {
            return View("Previsao", idAPI);
        }

        private List<Cidade> BuscarCidades()
        {
            var retorno = new List<Cidade>();

            var cidade = new Cidade();
            cidade.Id = 1;
            cidade.Nome = "Rio de Janeiro";
            cidade.OpenWeatherId = 3451190;

            retorno.Add(cidade);

            return retorno;
        }
    }
}