using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Controllers
{
    public class CursoController : Controller
    {

        ICurso cursorepo;
        IVestibular vestrepo;
        public CursoController(ICurso _cursorepo, IVestibular _vest)
        {
            cursorepo = _cursorepo;
            vestrepo = _vest;
        }

        // GET: Curso
        public ActionResult Index()
        {
            return View(cursorepo.ListarCursos());
        }


        public ActionResult Inserir()
        {
            //SelectList vest = new SelectList(vestrepo.ListarVestibulares(),"IdVestibular","Nome",1);
            //ViewData["Vestibulares"] = vest;
            var data = vestrepo.ListarVestibulares();
            ViewBag.vestibulares = data;
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Curso _curso)
        {
            cursorepo.CadastrarCurso(_curso);
            return RedirectToAction("Inserir");
        }

        public ActionResult Editar(int id)
        {
            var data = vestrepo.ListarVestibulares();
            ViewBag.vestibulares = data;
            return View(cursorepo.BuscarCurso(id));
        }

        [HttpPost]
        public ActionResult Editar(Curso _curso)
        {

            cursorepo.EditarCurso(_curso);
            return RedirectToAction("Index");
        }
    }
}