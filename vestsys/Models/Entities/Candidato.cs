using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vestsys.Models.Entities
{
    public class Candidato
    {
        public int idCandidato { get; set; }
        public string nomeCandidato { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public DateTime dataNasc { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public bool status { get; set; }
        public int idVestibular { get; set; }
        public virtual Vestibular vestibular { get; set; }
        public virtual Curso Curso { get; set; }
       
    }
}