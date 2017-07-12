using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vestsys.infra;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Models.Concret
{
    public class EFUsuario : IUsuario
    {
        private Dbcontexto db;
        public EFUsuario(Dbcontexto _db)
        {
            db = _db;
        }
        public IQueryable<Usuario> Usuarios
        {
            get
            {
                return db.Usuario.AsQueryable();
            }
        }
        public Usuario BuscarUsuario(int? id)
        {

            try
            {
                //var db = new Dbcontexto();


                var result = (from u in Usuarios
                              where u.IdUsuario == id
                              select new
                              {

                                  email = u.email,
                                  idCandidato = u.idCandidato,
                                  IdUsuario = u.IdUsuario,
                                  login = u.login,
                                  senha = u.senha,
                                  nome = u.nome,
                                  TipoUser = u.TipoUser

                              }).AsEnumerable().Select(x => new Usuario
                              {
                                  email = x.email,
                                  idCandidato = x.idCandidato,
                                  IdUsuario = x.IdUsuario,
                                  login = x.login,
                                  senha = x.senha,
                                  nome = x.nome,
                                  TipoUser = x.TipoUser

                              }).FirstOrDefault();

                return result;




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int CadastradarUsuario(Usuario user)
        {
            try
            {
                var result = from u in Usuarios
                             where u.email == user.email && u.IdUsuario == user.IdUsuario
                             select u;
                if (result.Count() == 0)
                {
                    db.Usuario.Add(user);
                    db.SaveChanges();
                    return user.IdUsuario;
                }
                //var db = new Dbcontexto();
                //db.Usuario.Add(user);
                //db.SaveChanges();
                //return user.IdUsuario;
                return 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public string DeletarUsuario(Usuario user)
        {
            try
            {

                //var db = new Dbcontexto();
                db.Usuario.Remove(user);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public string EditarUsuario(Usuario user)
        {
            try
            {
                //var db = new Dbcontexto();
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "OK";

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                //var db = new Dbcontexto();
                return Usuarios.ToList();


            }
            catch (Exception ex)
            {
                var r = new List<Usuario>();
                return r;
            }
        }
    }
}