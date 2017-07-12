using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vestsys.Models.Entities;

namespace vestsys.Models.Abstract
{
    public interface ICurso
    {
        int CadastrarCurso(Curso param);
        string EditarCurso(Curso param);
        string DeletarCurso(Curso param);
        List<Curso> ListarCursos();
        Curso BuscarCurso(int id);


    }
}
