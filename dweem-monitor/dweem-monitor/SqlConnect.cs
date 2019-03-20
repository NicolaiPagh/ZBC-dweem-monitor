using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace dweem_monitor
{
    public static class Database
    {
        public static string SqlConnect()
        {
            string connString = "server=192.168.1.33;user id=jof;password=Dromedar44!;persistsecurityinfo=True;database=videos;allowuservariables=True";
            MySqlConnection conn = null;
            
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                return conn.ServerVersion;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}