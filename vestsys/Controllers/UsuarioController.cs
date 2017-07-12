using System.Web.Mvc;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Controllers
{
    public class UsuarioController : Controller
    {
      
        IUsuario usuariorepo;
        public UsuarioController(IUsuario _usuariorepo)
        {
            usuariorepo = _usuariorepo;
        }
        
        // GET: Usuario
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                return View(usuariorepo.ListarUsuarios());
            }

            ViewBag.Mensagem = "Por favor faça o login.";
            return RedirectToAction("Index","Login");
        }

        public ActionResult Inserir()
        {
            if (Session["Id"] != null)
            {
                return View();
            }

            ViewBag.Mensagem = "Por favor faça o login.";
            return RedirectToAction("Index", "Login");
            
        }

        [HttpPost]
        public ActionResult Inserir(Usuario _usuario)
        {
            if (Session["Id"] != null)
            {
                usuariorepo.CadastradarUsuario(_usuario);
                return RedirectToAction("Index");
            }

            ViewBag.Mensagem = "Por favor faça o login.";
            return RedirectToAction("Index", "Login");


            
        }

        public ActionResult Editar(int id)
        {
            if (Session["Id"] != null)
            {
                return View(usuariorepo.BuscarUsuario(id));
            }

            ViewBag.Mensagem = "Por favor faça o login.";
            return RedirectToAction("Index", "Login");
            
        }


        [HttpPost]
        public ActionResult Editar(Usuario _usuario)
        {
            if (Session["Id"] != null)
            {
                usuariorepo.EditarUsuario(_usuario);
                return RedirectToAction("Index");

            }

            ViewBag.Mensagem = "Por favor faça o login.";
            return RedirectToAction("Index", "Login");
            

        }


    }
}