using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Verificador.Models;

namespace Verificador.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string cartao)
        {
            VerificarCartao obj = new VerificarCartao(cartao);

            string resultado = obj.Validar() ? "válido" : "inválido";

            return Json(new { retorno = obj.Bandeira + ": " + cartao + " (" + resultado + ")" }, JsonRequestBehavior.AllowGet);
        }
    }
}