using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GameNews.Logic
{
    class Platform
    {
        public int id { get; set; }
        public string platformname { get; set; }

        public Platform(int id, string name)
        {
            this.id = id;
            this.platformname = name;
        }
    }
    class PlatformList
    {
        public static List<Platform> getAllPlatform()
        {
            List<Platform> platforms = new List<Platform>();
            DataTable dt = GameNews.DataAccess.PlatformDAO.getAllPlatform();
            platforms.Add(new Platform(0, "All Platform"));
            foreach(DataRow dr in dt.Rows)
            {
                Platform platform = new Platform(Convert.ToInt32(dr["platformid"]), dr["platformname"].ToString());
                platforms.Add(platform);
            }
            return platforms;
        }
    }
}
