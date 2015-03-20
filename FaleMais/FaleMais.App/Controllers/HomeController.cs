using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaleMais.Repositorio;
using FaleMais.Models;
using FaleMais.Negocio;
using FaleMais.Negocio.Models;

namespace FaleMais.App.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (var repo = new Entities())
            {

                ViewBag.Planos = repo.PLANO.ToList();
                
            }
            return View();
        }

        public JsonResult Calcular(PedidoCalculo _pedido)
        {
            var _calculos = new Calculos();
            ResultadoCalculo tarifa = _calculos.CalcularTarifa(_pedido);

            return Json(tarifa, JsonRequestBehavior.AllowGet);

        }

    }
}
