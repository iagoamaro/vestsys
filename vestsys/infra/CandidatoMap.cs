using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using vestsys.Models.Entities;

namespace vestsys.infra
{
    public class CandidatoMap : EntityTypeConfiguration<Candidato>
    {
        

        public CandidatoMap()
        {
            ToTable("cadidato");

            HasKey(x => x.idCandidato);

            Property(x => x.idCandidato).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.vestibular).WithMany(y => y.candidatos).HasForeignKey(x => x.idVestibular);



        }
    }
}