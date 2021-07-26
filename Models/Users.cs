using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ytuportal.web.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public byte[] Photo { get; set; }
        public string Gender { get; set; }
        public Cities City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Info { get; set; }
        public byte[] CV { get; set; }
        public string Phone { get; set; }
        public string Departman { get; set; }
        public string University { get; set; }
    }
}