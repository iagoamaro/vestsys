using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using vestsys.infra;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Models.Concret
{
    public class EFCandidato : ICandidato
    {
        private Dbcontexto db;
        public EFCandidato(Dbcontexto dbContexto)
        {
            db = dbContexto;
        }
        public IQueryable<Candidato> Candidatos
        {
            get
            {
                return db.Candidato.AsQueryable();
            }
        }
        public Candidato BuscarCandidato(int id)
        {
            try
            {
                var result = (from c in Candidatos
                              where c.idCandidato == id
                              select new Candidato
                              {
                                  cpf = c.cpf,
                                  dataNasc = c.dataNasc,
                                  email = c.email,
                                  idCandidato = c.idCandidato,
                                  idVestibular = c.idVestibular,
                                  nomeCandidato = c.nomeCandidato,
                                  sexo = c.sexo,
                                  status = c.status,
                                  tel = c.tel,

                              }).FirstOrDefault();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public int CadastrarCandidato(Candidato param)
        {
            try
            {
                var db = new Dbcontexto();
                db.Candidato.Add(param);
                db.SaveChanges();
                return param.idCandidato;

            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public string DeletarCandidato(Candidato param)
        {
            try
            {
                var db = new Dbcontexto();
                db.Candidato.Remove(param);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string EditarCandidato(Candidato param)
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

                return ex.Message;
            }
        }

        public List<Candidato> ListarCandidato()
        {


            //var db = new Dbcontexto();


            //return db.Candidato.ToList();
            return Candidatos.ToList();


        }
    }
}