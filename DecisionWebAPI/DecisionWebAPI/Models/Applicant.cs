using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DecisionWebAPI.Models
{
    public class Applicant
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public decimal GPA { get; set; }
    }
}