using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ytuportal.web.Models
{
    public class CV
    {
        public int CvId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public Users UserId { get; set; }
    }
}