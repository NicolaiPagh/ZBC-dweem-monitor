using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace dweem_monitor
{
    public class Database
    {
        public static string[,] SqlConnect()
        {
            string connString = "server=192.168.1.33;user id=jof;password=Dromedar44!;persistsecurityinfo=True;database=videos;allowuservariables=True";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            int rows = 9;
            string[,] arrayOutput = new string[rows,3];


            string query = "SELECT * FROM user_video";
            
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
                int x = 0;
                while (rdr.Read())
                {
                    arrayOutput[x, 0] = rdr.GetString(1);
                    arrayOutput[x, 1] = Convert.ToString(rdr.GetValue(2));
                    arrayOutput[x, 2] = rdr.GetString(3);
                    x++;
                }
                return arrayOutput;
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}