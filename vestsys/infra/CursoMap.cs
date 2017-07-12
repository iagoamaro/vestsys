using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using vestsys.Models.Entities;

namespace vestsys.infra
{
    public class CursoMap : EntityTypeConfiguration<Curso>
    {
        public CursoMap()
        {
            ToTable("curso");
            HasKey(x => x.idCurso);
            Property(x => x.idCurso).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.vestibular).WithMany(y => y.cursos).HasForeignKey(x => x.idVestibular);
        }
    }
}