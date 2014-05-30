using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kkgamesProj.Models
{
    public class userdb
    {
        public int Id { get; set; }
        public string nickname { get; set; }
        public int idsbase { get; set; }
        public DateTime timecreate { get; set; }
    }
}