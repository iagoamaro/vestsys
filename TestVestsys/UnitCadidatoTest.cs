using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using vestsys.infra;
using vestsys.Models.Concret;
using vestsys.Models.Entities;

namespace TestVestsys
{
    [TestClass]
    public class UnitCadidatoTest
    {
        public Dbcontexto db;
        public EFCandidato _Candidato;
        public Candidato candidato;
        [TestInitialize]
        public void TesteInitialize()
        {
            db = new Dbcontexto();
            _Candidato = new EFCandidato(db);
            new Dbcontexto.ContextoInicializar().InitializeDatabase(db);
            candidato = new Candidato
            {
                cpf = "000000000",
                sexo = "M",
                tel = "33333333",
                status = true,
                dataNasc = DateTime.Now,
                nomeCandidato = "Teste",
                email = "Teste@teste"
                //vestibular = new Vestibular
                //{
                //    descVest = "Teste",
                //    dataFim = DateTime.Now,
                //    dataIni = DateTime.Now,
                //    dataProva = DateTime.Now
                //},
                //Curso = new Curso
                //{
                //    descricao = "Teste",
                //    numeroVaga = 22
                //}

                
                

            };

            //LimparCenario();



        }

        [TestMethod]
        public void pode_inserir_Candidato()
        {
            int codcandidato = 0;
            Candidato retorno = new Candidato();
            codcandidato = _Candidato.CadastrarCandidato(candidato);
            retorno = _Candidato.BuscarCandidato(codcandidato);

            Assert.AreEqual(retorno, candidato);

        }

        //[TestCleanup]
        //public void LimparCenario()
        //{
        //    var Candidatos = from u in db.Candidato
        //                   select u;

        //    foreach (var usuario in Candidatos)
        //    {
        //        db.Candidato.Remove(usuario);

        //    }
        //    db.SaveChanges();
        //}
    }
}
