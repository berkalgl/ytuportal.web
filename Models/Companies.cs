using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ytuportal.web.Models
{
    public class Companies
    {
        public int ComID { get; set; }
        public string ComName { get; set; }
        public string ComSector { get; set;}
        public string ComNumberOfEmp { get; set; }
        public string ComAddress { get; set; }
        public string ComCountry { get; set; }
        public Cities ComCity { get; set; }
        public string ComWebSite { get; set; }
        public string ComDefinition { get; set; }
        public string ComTel { get; set; }
    }
}