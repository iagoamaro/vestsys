using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vestsys.Models.Entities
{
    public class Curso
    {
        public int idCurso { get; set; }
        public string descricao { get; set; }
        public int numeroVaga { get; set; }
        public int idCandidato { get; set; }
        public virtual ICollection<Candidato> candidatos { get; set; }
        public virtual Vestibular vestibular { get; set; }
        public int idVestibular { get; set; }
        public int teste { get; set; }
    }
}