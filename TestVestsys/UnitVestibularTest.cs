using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using vestsys.infra;
using vestsys.Models.Concret;
using vestsys.Models.Entities;

namespace TestVestsys
{
    [TestClass]
    public class UnitVestibularTest
    {

        public Dbcontexto db;
        public EFVestibular _Vestibular;
        public Vestibular vestibular;
        [TestInitialize]
        public void TesteInitialize()
        {
            db = new Dbcontexto();
            _Vestibular = new EFVestibular(db);
            new Dbcontexto.ContextoInicializar().InitializeDatabase(db);
            vestibular = new Vestibular
            {
                descVest = "Teste",
                dataFim = DateTime.Now,
                dataIni = DateTime.Now,
                dataProva = DateTime.Now,
                  
                            



            };

            //LimparCenario();



        }
        [TestMethod]
        public void pode_inserir_vestibular()
        {
            int codvestibular = 0;
            Vestibular retorno = new Vestibular();
            codvestibular = _Vestibular.CadastraVestibular(vestibular);
            retorno = _Vestibular.BuscarVestibular(codvestibular);

            Assert.AreEqual(retorno, vestibular);
        }
    }
}
