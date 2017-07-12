namespace vestsys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dasfsasf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cadidato",
                c => new
                    {
                        idCandidato = c.Int(nullable: false, identity: true),
                        nomeCandidato = c.String(),
                        tel = c.String(),
                        email = c.String(),
                        dataNasc = c.DateTime(nullable: false),
                        sexo = c.String(),
                        cpf = c.String(),
                        status = c.Boolean(nullable: false),
                        idVestibular = c.Int(nullable: false),
                        Curso_idCurso = c.Int(),
                    })
                .PrimaryKey(t => t.idCandidato)
                .ForeignKey("dbo.curso", t => t.Curso_idCurso)
                .ForeignKey("dbo.vestibular", t => t.idVestibular)
                .Index(t => t.idVestibular)
                .Index(t => t.Curso_idCurso);
            
            CreateTable(
                "dbo.curso",
                c => new
                    {
                        idCurso = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        numeroVaga = c.Int(nullable: false),
                        idCandidato = c.Int(nullable: false),
                        idVestibular = c.Int(nullable: false),
                        teste = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCurso)
                .ForeignKey("dbo.vestibular", t => t.idVestibular)
                .Index(t => t.idVestibular);
            
            CreateTable(
                "dbo.vestibular",
                c => new
                    {
                        idVestibular = c.Int(nullable: false, identity: true),
                        descVest = c.String(),
                        dataIni = c.DateTime(nullable: false),
                        dataFim = c.DateTime(nullable: false),
                        dataProva = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idVestibular);
            
            CreateTable(
                "dbo.usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        senha = c.String(maxLength: 20),
                        nome = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        TipoUser = c.Boolean(nullable: false),
                        idCandidato_idCandidato = c.Int(),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.cadidato", t => t.idCandidato_idCandidato)
                .Index(t => t.idCandidato_idCandidato);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario", "idCandidato_idCandidato", "dbo.cadidato");
            DropForeignKey("dbo.cadidato", "idVestibular", "dbo.vestibular");
            DropForeignKey("dbo.curso", "idVestibular", "dbo.vestibular");
            DropForeignKey("dbo.cadidato", "Curso_idCurso", "dbo.curso");
            DropIndex("dbo.usuario", new[] { "idCandidato_idCandidato" });
            DropIndex("dbo.curso", new[] { "idVestibular" });
            DropIndex("dbo.cadidato", new[] { "Curso_idCurso" });
            DropIndex("dbo.cadidato", new[] { "idVestibular" });
            DropTable("dbo.usuario");
            DropTable("dbo.vestibular");
            DropTable("dbo.curso");
            DropTable("dbo.cadidato");
        }
    }
}
