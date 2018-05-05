using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Insights.DAL
{
    class DBConnection
    {
        static string DbCnnStr = @"Data Source=|DataDirectory|\db_local1.sdf";
        public static SqlCeConnection GetConnection()
        {
            SqlCeConnection cnn = new SqlCeConnection(DbCnnStr);
            return cnn;
        }
        public static string Verifier_disponible_lien(string lien)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(lien);//OK 200
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return (response.StatusCode.ToString());
            }
            catch (Exception d)
            {
                String str1 = "INSERT INTO [erreur]  ([msg],[date])  VALUES ('" + d.ToString() + "'," + DateTime.Now + ")";
                DBConnection.Update(str1);
                return d.Message;
            }
        }
        public static void Update(String str)
        {
            try
            {
                SqlCeCommand cmd = new SqlCeCommand(str,GetConnection());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                String str1 = "INSERT INTO [erreur]  ([msg],[date])  VALUES ('" + e.ToString() + "'," + DateTime.Now + ")";
                DBConnection.Update(str1);
                GetConnection().Close();
            }
        }

        public static DataTable Select(String str)
        {
            try
            {
                SqlCeCommand cmd = new SqlCeCommand(str, GetConnection());
                SqlCeDataAdapter SelectAdapter = new SqlCeDataAdapter(cmd);
                DataTable Table = new DataTable();
                SelectAdapter.Fill(Table);
                return Table;
            }catch(Exception e)
            {
                String str1 = "INSERT INTO [erreur]  ([msg],[date])  VALUES ('" + e.ToString() + "'," + DateTime.Now + ")";
                DBConnection.Update(str1);
                return null;
            }
        }

        public static int count(String str)
        {
            try{
            SqlCeCommand cmd = new SqlCeCommand(str, DBConnection.GetConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return count;
             }catch(Exception e)
            {
                String str1 = "INSERT INTO [erreur]  ([msg],[date])  VALUES ('" + e.ToString() + "'," + DateTime.Now + ")";
                DBConnection.Update(str1);
                return 0;
            }
        }

      
    }
}
