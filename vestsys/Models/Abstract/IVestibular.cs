using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vestsys.Models.Entities;

namespace vestsys.Models.Abstract
{
    public interface IVestibular
    {
        int CadastraVestibular(Vestibular param);
        string EditarVestibular(Vestibular param);
        string DeletarVestibular(Vestibular param);
        List<Vestibular> ListarVestibulares();
        Vestibular BuscarVestibular(int id);
    }
}
