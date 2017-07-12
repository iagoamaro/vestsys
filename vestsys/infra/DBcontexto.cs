using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using vestsys.Models.Entities;

namespace vestsys.infra
{
    public class Dbcontexto : DbContext
    {
        public Dbcontexto() : base("casa")
        {

        }

        public IDbSet<Usuario> Usuario { get; set; }
        public IDbSet<Candidato> Candidato { get; set; }
        public IDbSet<Vestibular> Vestibular { get; set; }
        public IDbSet<Curso> Curso { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Database.Log = (query) => Debug.Write(query);

            //modelBuilder.HasDefaultSchema("public");
            //modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new CandidatoMap());
            modelBuilder.Configurations.Add(new CursoMap());
            modelBuilder.Configurations.Add(new VestibularMap());
            modelBuilder.ComplexType<CursoMap>();
            modelBuilder.ComplexType<UsuarioMap>();
            modelBuilder.ComplexType<VestibularMap>();
            modelBuilder.ComplexType<VestibularMap>();


            base.OnModelCreating(modelBuilder);
        }



        //Classe interna que implementa a interface IDatabasInitializer
        public class ContextoInicializar : IDatabaseInitializer<Dbcontexto>
        {
            //Método responsavel por inicializar o banco de dados, recebe como parametro um objeto contexto.
            public void InitializeDatabase(Dbcontexto context)
            {
                //Verifica se o banco de dados já existe
                if (context.Database.Exists())
                {
                    //Verifica se o banco de dados é compativel com o modelo.
                    if (!context.Database.CompatibleWithModel(false))
                    {
                        //Atualiza o banco de dados.
                        var dbMigrator = new DbMigrator(new vestsys.Migrations.Configuration());
                        dbMigrator.Update();
                    }
                }
                //Se não existir
                else
                {
                    //Cria o Banco de dados com base no contexto.
                    //context.Database.Create();
                    //            Database.SetInitializer<DbContext>(new MigrateDatabaseToLatestVersion<DbContext,  Configuration>());
                    var initializer = new MigrateDatabaseToLatestVersion<Dbcontexto, vestsys.Migrations.Configuration>();
                    Database.SetInitializer(initializer);
                    try
                    {
                        context.Database.Initialize(true);
                    }
                    catch (Exception ex)
                    {
                        
                        //Handle Error in some way
                    }
                }
                Seed(context);
            }

            protected void Seed(Dbcontexto db)
            {
                // Inserções de dados iniciais
            }

        }

       
    }
}