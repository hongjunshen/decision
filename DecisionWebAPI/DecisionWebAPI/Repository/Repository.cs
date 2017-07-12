using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DecisionWebAPI.Models;
using DecisionWebAPI.Repository;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DecisionWebAPI.Repository
{
    public class Repository:IRepository
    {
        private DecisionWebAPIContext db;

        public Repository(DecisionWebAPIContext db)
        {
            this.db = db;
        }

        //get all records from table
        public IQueryable<Applicant> GetAllApplicants()
        {
            return db.Applicants;
        }

        //get one record by Id
        public Applicant GetApplicant(int id)
        {
            return db.Applicants.FirstOrDefault(a => a.Id == id);
        }

        //create a new record
        public void CreateApplicant(Applicant applicant)
        {
            db.Applicants.Add(applicant);
            
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        //check if record already exists
        public bool ApplicantExists(int id)
        {
            return db.Applicants.Count(e => e.Id == id) > 0;
        }
    }
}