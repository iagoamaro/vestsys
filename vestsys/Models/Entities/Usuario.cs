using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vestsys.Models.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public bool TipoUser { get; set; }
        public virtual Candidato idCandidato { get; set; }
    }
}