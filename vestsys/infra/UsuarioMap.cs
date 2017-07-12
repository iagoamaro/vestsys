using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using vestsys.Models.Entities;

namespace vestsys.infra
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("usuario");
            HasKey(x => x.IdUsuario);
            Property(x => x.IdUsuario).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.nome).HasMaxLength(50);
            Property(x => x.email).HasMaxLength(50);
            Property(x => x.senha).HasMaxLength(20);
        }
    }
}