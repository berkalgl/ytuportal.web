using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ytuportal.web.Models
{
    public class Employees
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpTel { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPass { get; set; }
        public string EmpGender { get; set; }
        public string EmpBirthday { get; set; }
        public string EmpJob { get; set; }
        //foreing keys
        public int EmpComID { get; set; }
        public string EmpComName { get; set; }
        public Cities EmpComCity { get; set; }
    }
}