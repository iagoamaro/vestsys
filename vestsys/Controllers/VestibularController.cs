using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Controllers
{
    public class VestibularController : Controller
    {

        IVestibular vestrepo;
        public VestibularController(IVestibular _vestrepo)
        {
            vestrepo = _vestrepo;
        }
        // GET: Vestibular
        public ActionResult Index()
        {
            return View(vestrepo.ListarVestibulares());
        }

        public ActionResult Inserir(int? id)
        {
            if (!id.HasValue)
            {
                return View();
            }
            else
            {
                
                return View(vestrepo.BuscarVestibular(id.Value));
            }
           
        }

        [HttpPost]
        public ActionResult Inserir(Vestibular _vestibular)
        {
            var vest = vestrepo.BuscarVestibular(_vestibular.idVestibular);
            if (vest == null)
            {
                vestrepo.CadastraVestibular(_vestibular);
                return RedirectToAction("Inserir");

            }
            else
            {
                vestrepo.EditarVestibular(vest);
                return RedirectToAction("Inserir");
            }
            
        }

        

    }
}