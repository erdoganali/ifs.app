using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spy.Recruiter.Mvc.Models
{
    public class Candidates
    {
        public string candidateId { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int gender { get; set; }
        public string profilePicture { get; set; }
        public string email { get; set; }
        public string favoriteMusicGenre { get; set; }
        public string dad { get; set; }
        public string mom { get; set; }
        public bool canSwim { get; set; }
        public string barcode { get; set; }
        public List<Experience> experience { get; set; }
        public bool isShown { get; set; } = false;
        public bool isAccepted { get; set; } = false;

        public class Experience
        {
            public string technologyId { get; set; }
            public int yearsOfExperience { get; set; }
        }
    }
}
