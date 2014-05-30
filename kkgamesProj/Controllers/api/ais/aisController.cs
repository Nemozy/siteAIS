using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using kkgamesProj.Models;

using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace kkgamesProj.Controllers.api.ais
{
    public class aisController : ApiController
    {

        [System.Web.Http.HttpGet]
        [System.Web.Http.HttpPost]
        public IEnumerable<userInfo> getUser(string userid)
        {
            gamesdbDataContext db = new gamesdbDataContext();
            var outI = new List<userInfo>();
            var nnOut = new userInfo();
            var nn = new userdb();

            foreach (userdb t in db.userdb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn.Id = t.Id;
                    nn.Nickname = t.Nickname;
                    nn.Idsbase = t.Idsbase;
                    nn.Timecreate = t.Timecreate;
                }
            }
            nnOut.userdb = nn;

            var nn1 = new authkeydb();
            foreach (authkeydb t in db.authkeydb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn1.Id = t.Id;
                    nn1.authkey = t.authkey;
                    nn1.datetime = t.datetime;
                }
            }
            nnOut.authkeydb = nn1;

            var nn2 = new energydb();
            foreach (energydb t in db.energydb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn2.Id = t.Id;
                    nn2.energylimit = t.energylimit;
                    nn2.energycount = t.energycount;
                    nn2.datetime = t.datetime;
                }
            }
            nnOut.energydb = nn2;

            var nn3 = new expdb();
            foreach (expdb t in db.expdb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn3.Id = t.Id;
                    nn3.expcount = t.expcount;
                }
            }
            nnOut.expdb = nn3;

            var nn4 = new inventorydb();
            foreach (inventorydb t in db.inventorydb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn4.Id = t.Id;
                    nn4.idmassyacheek = t.idmassyacheek;
                }
            }
            nnOut.inventorydb = nn4;

            var nn5 = new moneydb();
            foreach (moneydb t in db.moneydb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn5.Id = t.Id;
                    nn5.gold = t.gold;
                    nn5.oensh = t.oensh;
                }
            }
            nnOut.moneydb = nn5;

            var nn6 = new settingsdb();
            foreach (settingsdb t in db.settingsdb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn6.Id = t.Id;
                    nn6.music = t.music;
                    nn6.sound = t.sound;
                    nn6.volume = t.volume;
                }
            }
            nnOut.settingsdb = nn6;

            var nn7 = new racedb();
            foreach (racedb t in db.racedb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn7.Id = t.Id;
                    nn7.type = t.type;
                }
            }
            nnOut.racedb = nn7;

            var nn8 = new shipdb();
            foreach (shipdb t in db.shipdb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn8.Id = t.Id;
                    nn8.shiptype = t.shiptype;
                }
            }
            nnOut.shipdb = nn8;

            var nn9 = new stagedb();
            foreach (stagedb t in db.stagedb)
            {
                if (t.Id.ToString() == userid)
                {
                    nn9.Id = t.Id;
                    nn9.lastplanetwin = t.lastplanetwin;
                }
            }
            nnOut.stagedb = nn9;

            outI.Add(nnOut);
            return outI;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.HttpPost]
        public bool createUser(string userid, string nick, string race)
        {
            gamesdbDataContext db = new gamesdbDataContext();

            //сортировать по id и взять максимальное
            var res = db.ExecuteQuery<userdb>("Select * from userdb");
            int maxId = 0;

                //создаем пользователя
                foreach (userdb t in res)
                {
                    if (Convert.ToInt32(t.Idsbase) > maxId)
                        maxId = Convert.ToInt32(t.Idsbase);
                    if (Convert.ToInt32(t.Idsbase) == Convert.ToInt32(userid))
                        return false;
                }

                maxId += 1;
                DateTime nowD = DateTime.Now;
                db.ExecuteCommand("insert into userdb (Id, Nickname, Idsbase, Timecreate) VALUES ({0}, {1}, {2}, {3})",
                Convert.ToInt32(userid), nick, maxId, nowD);

                //создаём для пользователя расу
                int raceNum = 3;
                if(race == "Orc")
                    raceNum = 2;
                else if (race == "Elf")
                    raceNum = 1;
                db.ExecuteCommand("insert into racedb (Id, type) VALUES ({0}, {1})",
                    Convert.ToInt32(userid), raceNum);

                //аус кей (доделать потом)
                db.ExecuteCommand("insert into authkeydb (Id, authkey, datetime) VALUES ({0}, {1}, {2})",
                        Convert.ToInt32(userid), "1234567890", nowD);

                //энергия 
                db.ExecuteCommand("insert into energydb (Id, energylimit, energycount, datetime) VALUES ({0}, {1}, {2}, {3})",
                        Convert.ToInt32(userid), 100, 100, nowD);

                //опыт/лвл 
                db.ExecuteCommand("insert into expdb (Id, expcount) VALUES ({0}, {1})",
                        Convert.ToInt32(userid), 0);

                //инвентарь
                string inventory = "";
                for (int i = 0; i < 40; i++)
                {
                    inventory += userid.ToString() + "_"+i.ToString()+";";
                }
                db.ExecuteCommand("insert into inventorydb (Id, idmassyacheek) VALUES ({0}, {1})",
                        Convert.ToInt32(userid), inventory);

                for (int i = 0; i < 12; i++)
                {
                    string idYach = userid.ToString() + "_" + i.ToString();
                    db.ExecuteCommand("insert into yacheykadb (Id, type, item_id) VALUES ({0}, {1}, {2})",
                            idYach, 1, 0);
                }

                for (int i = 12; i < 40; i++)
                {
                    string idYach = userid.ToString() + "_" + i.ToString();
                    db.ExecuteCommand("insert into yacheykadb (Id, type, item_id) VALUES ({0}, {1}, {2})",
                            idYach, 2, 0);
                }

                //деньги
                db.ExecuteCommand("insert into moneydb (Id, gold, oensh) VALUES ({0}, {1}, {2})",
                        Convert.ToInt32(userid), 25, 100);

                //настройки
                db.ExecuteCommand("insert into settingsdb (Id, music, sound, volume) VALUES ({0}, {1}, {2}, {3})",
                        Convert.ToInt32(userid), 1, 1, 100);

                //корабль (создать БД с кораблями)
                db.ExecuteCommand("insert into shipdb (Id, shiptype) VALUES ({0}, {1})",
                        Convert.ToInt32(userid), 1);

                //уровень
                db.ExecuteCommand("insert into stagedb (Id, lastplanetwin) VALUES ({0}, {1})",
                        Convert.ToInt32(userid), 0);

            return true;
        }
    }
}