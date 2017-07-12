using System;
namespace DecisionWebAPI.Repository
{
    public interface IRepository
    {
        void CreateApplicant(DecisionWebAPI.Models.Applicant applicant);
        System.Linq.IQueryable<DecisionWebAPI.Models.Applicant> GetAllApplicants();
        DecisionWebAPI.Models.Applicant GetApplicant(int id);
        bool ApplicantExists(int id);
    }
}
