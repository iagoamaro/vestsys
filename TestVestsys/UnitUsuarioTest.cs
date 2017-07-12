using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using vestsys.infra;
using vestsys.Models.Concret;
using vestsys.Models.Entities;
using System.Linq;

namespace TestVestsys
{
    [TestClass]
    public class UnitUsuarioTest
    {
        public Dbcontexto db;
        public EFUsuario _Usuario;
        public Usuario usuario;
        [TestInitialize]
        public void TesteInitialize()
        {
            db = new Dbcontexto();
            _Usuario = new EFUsuario(db);
            new Dbcontexto.ContextoInicializar().InitializeDatabase(db);            
            usuario = new Usuario
            {
                email = "teste@test.com",
                login = "teste",
                nome = "teste teste",
                senha = "teste123",
                TipoUser = true,
                

            };

            //LimparCenario();



        }
        [TestMethod]
        public void pode_inserir_Usuario_test()
        {
            //Ambiente

            int codusuario = 0;
            Usuario retorno = new Usuario();
            //Ação
            codusuario = _Usuario.CadastradarUsuario(usuario);

            retorno =  _Usuario.BuscarUsuario(codusuario);
            


            //usuario.IdUsuario = retorno.IdUsuario;
            //Assertivas            
            Assert.AreEqual(retorno, usuario);
        }


        [TestCleanup]
        public void LimparCenario()
        {
            var Usuarios = from u in db.Candidato
                           select u;

            foreach (var usuario in Usuarios)
            {
                db.Candidato.Remove(usuario);

            }
            db.SaveChanges();
        }
    }
}
