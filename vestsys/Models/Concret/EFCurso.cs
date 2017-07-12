using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vestsys.infra;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Models.Concret
{
    public class EFCurso : ICurso
    {
        private Dbcontexto db;
        public EFCurso(Dbcontexto dbContexto)
        {
            db = dbContexto;
        }
        public IQueryable<Curso> Cursos
        {
            get
            {
                return db.Curso.AsQueryable();
            }
        }
        public Curso BuscarCurso(int id)
        {
            try
            {
                var result = (from c in Cursos
                              where c.idCurso == id
                              select new
                              {

                                  descricao = c.descricao,
                                  idCandidato = c.idCandidato,
                                  idCurso = c.idCurso,
                                  idVestibular = c.idVestibular,
                                  numeroVaga = c.numeroVaga,
                                  teste = c.teste,

                              }).AsEnumerable().Select(x => new Curso
                              {
                                  descricao = x.descricao,
                                  idCandidato = x.idCandidato,
                                  idCurso = x.idCurso,
                                  idVestibular = x.idVestibular,
                                  numeroVaga = x.numeroVaga,
                                  teste = x.teste,

                              }).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CadastrarCurso(Curso param)
        {
            try
            {
                var db = new Dbcontexto();
                db.Curso.Add(param);
                db.SaveChanges();
                return param.idCurso;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public string DeletarCurso(Curso param)
        {
            try
            {
                var db = new Dbcontexto();
                db.Curso.Remove(param);
                db.SaveChanges();
                return "OK";

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public string EditarCurso(Curso param)
        {
            try
            {
                var db = new Dbcontexto();
                db.Entry(param).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public List<Curso> ListarCursos()
        {


            var db = new Dbcontexto();
            return db.Curso.ToList();


        }
    }
}