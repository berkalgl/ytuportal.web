using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ytuportal.web.Models
{
    public class Advertisements
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Sector { get; set; }
        public string Place { get; set; }
        public string Firstdate { get; set; }
        public string Lastdate { get; set; }
        public string Attribute { get; set; }
        public Companies Company { get; set; }
        public string Definition { get; set; }
        public Adv_Level Level { get; set; }
        public Adv_Style Style { get; set; }
        public int NumberOfCandidate { get; set; }
        public string Status { get; set; }

    }
}