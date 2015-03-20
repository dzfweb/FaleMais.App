using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaleMais.Models;
using FaleMais.Repositorio;
using System.Web.Security;

namespace FaleMais.App.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Login(ADMIN admin)
        {
            try
            {
                using (var repo = new Entities())
                {
                    var objADMIN = repo.ADMIN.FirstOrDefault(p => p.ADMIN_LOGIN == admin.ADMIN_LOGIN && p.ADMIN_PASS == admin.ADMIN_PASS);

                    if (objADMIN != null)
                    {
                        FormsAuthentication.SetAuthCookie(admin.ADMIN_LOGIN, true);
                        return Json(new { text = "Autenticado, redirecionando...", type = "success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { text = "Usuario ou senha inválido", type = "warning" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { text = "Não foi possivel autenticar.", type = "error" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}
