using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kkgamesProj.Models
{
    public class userInfo
    {
        public kkgamesProj.authkeydb authkeydb { get; set; }
        public kkgamesProj.energydb energydb { get; set; }
        public kkgamesProj.expdb expdb { get; set; }
        public kkgamesProj.inventorydb inventorydb { get; set; }
        public kkgamesProj.moneydb moneydb { get; set; }
        public kkgamesProj.racedb racedb { get; set; }
        public kkgamesProj.settingsdb settingsdb { get; set; }
        public kkgamesProj.shipdb shipdb { get; set; }
        public kkgamesProj.stagedb stagedb { get; set; }
        public kkgamesProj.userdb userdb { get; set; }
    }
}