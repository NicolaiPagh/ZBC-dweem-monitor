using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Collections.Generic;

namespace dweem_monitor
{
    public class Database
    {
        public static string[,] SqlTestSite(string query)
        {
            string connString = "server=192.168.1.33;user id=jof;password=Dromedar44!;persistsecurityinfo=True;database=videos;allowuservariables=True";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;


            int rows = 0;
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rows++;
                }
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

            conn = null;
            rdr = null;
            string[,] arrayOutput = new string[rows,3];
            
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

        public static List<string> SqlGetComputers(string query)
        {
            string connString = "server=192.168.1.33;user id=jof;password=Dromedar44!;persistsecurityinfo=True;database=dweem;allowuservariables=True";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            List<string> computersList = new List<string>();

            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    computersList.Add(rdr.GetString(0));   
                }
                return computersList;
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
        public static void SqlAddComputer(string computer)
        {
            string connString = "server=192.168.1.33;user id=jof;password=Dromedar44!;persistsecurityinfo=True;database=dweem;allowuservariables=True";
            MySqlConnection conn = null;
            string query = "INSERT INTO computers (name) VALUES ('" + computer + "')";

            conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}