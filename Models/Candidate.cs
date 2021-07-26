using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ytuportal.web.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public Users User { get; set; }
        public Advertisements Adv { get; set; }
        public string CStatus { get; set; }
    }
}