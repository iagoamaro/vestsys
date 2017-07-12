using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vestsys.Models.Entities
{
    public class Vestibular
    {
        public int idVestibular { get; set; }
        public string descVest { get; set; }
        public DateTime dataIni { get; set; }
        public DateTime dataFim { get; set; }
        public DateTime dataProva { get; set; }
        public virtual ICollection<Curso> cursos { get; set; }
        public virtual ICollection<Candidato> candidatos { get; set; }
    }
}