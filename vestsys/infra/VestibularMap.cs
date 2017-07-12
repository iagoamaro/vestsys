using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using vestsys.Models.Entities;

namespace vestsys.infra
{
    public class VestibularMap : EntityTypeConfiguration<Vestibular>
    {
        public VestibularMap()
        {
            ToTable("vestibular");
            HasKey(x => x.idVestibular);
            Property(x => x.idVestibular).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            

        }
    }
}