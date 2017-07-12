using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DecisionWebAPI.Models
{
    public class DecisionWebAPIInitializer : DropCreateDatabaseAlways<DecisionWebAPIContext>
    {
        protected override void Seed(DecisionWebAPIContext context)
        {
            var applicants = new List<Applicant>
            {
                new Applicant(){FirstName="John",LastName="Papa",DOB = DateTime.Parse("1960/01/01"), GPA=3.89m},
                new Applicant(){FirstName="Ward",LastName="Bell",DOB = DateTime.Parse("1960/01/01"), GPA=3.89m}
            };

            applicants.ForEach(b => context.Applicants.Add(b));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}