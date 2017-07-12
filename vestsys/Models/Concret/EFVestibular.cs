using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vestsys.infra;
using vestsys.Models.Abstract;
using vestsys.Models.Entities;

namespace vestsys.Models.Concret
{
    public class EFVestibular : IVestibular
    {
        private Dbcontexto db;
        public EFVestibular(Dbcontexto dbContexto)
        {
            db = dbContexto;
        }
        public IQueryable<Vestibular> Vestibulares
        {
            get
            {
                return db.Vestibular.AsQueryable();
            }
        }
        public Vestibular BuscarVestibular(int id)
        {
            try
            {
                var result = (from v in Vestibulares
                              where v.idVestibular == id
                              select new Vestibular
                              {
                                  dataFim = v.dataFim,
                                  dataIni = v.dataIni,
                                  dataProva = v.dataProva,
                                  descVest = v.descVest,
                                  idVestibular = v.idVestibular

                              }).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CadastraVestibular(Vestibular param)
        {
            try
            {
                var db = new Dbcontexto();
                db.Vestibular.Add(param);
                db.SaveChanges();
                return param.idVestibular;

            }
            catch (Exception)
            {

                return 0;
            }
        }

        public string DeletarVestibular(Vestibular param)
        {
            try
            {
                var db = new Dbcontexto();
                db.Vestibular.Remove(param);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public string EditarVestibular(Vestibular param)
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

        public List<Vestibular> ListarVestibulares()
        {


            //var db = new Dbcontexto();
            //return db.Vestibular.ToList();

            return Vestibulares.ToList();


        }
    }
}