using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DecisionWebAPI.Models;
using DecisionWebAPI.Repository;


     
namespace DecisionWebAPI.Controllers
{
     //this class is used by angular client 
    [EnableCorsAttribute("http://localhost:62893", "*", "*")]
    public class ApplicantController : ApiController
    {
        IRepository _repo;

        public ApplicantController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Applicant
        public IHttpActionResult GetApplicants()
        {
            try
            {
                var applicants = _repo.GetAllApplicants();
                return Ok(applicants);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;
        }

        // GET: api/Applicant/5
        [ResponseType(typeof(Applicant))]
        public IHttpActionResult GetApplicant(int id)
        {
            Applicant applicant = _repo.GetApplicant(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }


        // POST: api/applicant
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(Applicant))]
        public IHttpActionResult PostApplicant([FromBody]Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _repo.CreateApplicant(applicant);
            }
            catch (DbUpdateException ex)
            {
                
                  throw ex;
                
            }

            return Ok(applicant);
        }
    }
}
