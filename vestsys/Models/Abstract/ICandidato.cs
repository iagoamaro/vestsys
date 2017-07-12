using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vestsys.Models.Entities;

namespace vestsys.Models.Abstract
{
    public interface ICandidato
    {
        int CadastrarCandidato(Candidato param);
        string EditarCandidato(Candidato param);
        string DeletarCandidato(Candidato param);
        List<Candidato> ListarCandidato();
        Candidato BuscarCandidato(int id);
    }
}
