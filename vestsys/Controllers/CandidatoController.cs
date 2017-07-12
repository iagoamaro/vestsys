using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Controllers
{
    public class CandidatoController : Controller
    {

        ICandidato candidatorepo;
        IVestibular vestrepo;

        public CandidatoController(ICandidato _candidatorepo, IVestibular _vestrepo)
        {
            vestrepo = _vestrepo;
            candidatorepo = _candidatorepo;
        }

        // GET: Candidato
        public ActionResult Index()
        {
            return View(candidatorepo.ListarCandidato());
        }

        public ActionResult Inserir()
        {
            var data = vestrepo.ListarVestibulares();
            ViewBag.vestibulares = data;
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Candidato candidato)
        {

            candidatorepo.CadastrarCandidato(candidato);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            
            return View(candidatorepo.BuscarCandidato(id));
        }

        [HttpPost]
        public ActionResult Editar(Candidato candidato)
        {
            candidatorepo.EditarCandidato(candidato);
            return RedirectToAction("index");

        }
         

    }
}