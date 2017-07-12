using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vestsys.infra;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Controllers
{
    public class LoginController : Controller
    {
        private Dbcontexto db;
        public LoginController()
        {
            Dbcontexto _db = new Dbcontexto();
            db = _db;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario user)
        {
            var usuario = db.Usuario.FirstOrDefault(x => x.login == user.login && x.senha == user.senha);
            if (usuario != null)
            {
                Session["Id"] = true;
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                ViewBag.Mensagem = "Login ou senha incorreta.";
                return View();
            }
        }
    }
}