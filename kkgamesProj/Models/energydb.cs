using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kkgamesProj.Models
{
    public class energydb
    {
        public int Id { get; set; }
        public int energylimit { get; set; }
        public int energycount { get; set; }
        public DateTime datetime { get; set; }
    }
}