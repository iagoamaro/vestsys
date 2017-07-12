using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using vestsys.Models.Concret;
using vestsys.infra;
using vestsys.Models.Entities;

namespace TestVestsys
{
    [TestClass]
    public class UnitCursoTest
    {

        public Dbcontexto db;
        public EFCurso _Curso;
        public Curso curso;
        [TestInitialize]
        public void TesteInitialize()
        {
            db = new Dbcontexto();
            _Curso = new EFCurso(db);
            new Dbcontexto.ContextoInicializar().InitializeDatabase(db);
            curso = new Curso
            {
                descricao = "Teste",
                numeroVaga = 22,
                vestibular = new Vestibular
                {
                    descVest = "Teste",
                    dataFim = DateTime.Now,
                    dataIni = DateTime.Now,
                    dataProva = DateTime.Now
                },
                
                



            };

            //LimparCenario();



        }
        [TestMethod]
        public void pode_inserir_curso()
        {
            int codcurso = 0;
            Curso retorno = new Curso();
            codcurso = _Curso.CadastrarCurso(curso);
            retorno = _Curso.BuscarCurso(codcurso);

            Assert.AreEqual(retorno, curso);
        }

    }
}
