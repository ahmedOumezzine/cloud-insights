using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_Insights.DAL
{
    class DAL_Composant
    {
        public static Boolean composant(String UUIDMachine, String libelleComposant)
        {
 
            try
            {
                Donnee.Json p;
                string urlAddress =Program.Server+ "/pfe/API/composant/add_composant.php";
                using (WebClient client = new WebClient())
                {
                    NameValueCollection postData = new NameValueCollection();
                    {
                        postData.Add("IDSociete", Program.id);
                        postData.Add("mdp_crypt", Program.code);
                        postData.Add("UUIDMachine", UUIDMachine);
                        postData.Add("libelleComposant", libelleComposant);
                    };
                    string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    p = serializer.Deserialize<Donnee.Json>(pagesource);
                 }
              
                  if (p.erreur == "0" || p.erreur == "1"){
                    Program.IDComposant = p.message;
                    return true;
                }
                else{
                    Program.cout++;
                    System.Threading.Thread.Sleep(Program.cout * 1000); 
                    String str = "INSERT INTO [composant]  ([libelleComposant])  VALUES ('" + libelleComposant + "')";
                    DBConnection.Update(str);
                    return false;
                }
            }
            catch (Exception eee)
            {
                Program.cout++;
                System.Threading.Thread.Sleep(Program.cout*1000); 
                String str1 = "INSERT INTO [erreur]  ([msg],[date])  VALUES ('" + eee.ToString() + "'," + DateTime.Now + ")";
                DBConnection.Update(str1);
                String str = "INSERT INTO [composant]  ([libelleComposant])  VALUES ('" + libelleComposant + "')";
                DBConnection.Update(str);
                return false;
            }
        }

        public static List<string> SelectAll()
        {
            List<string> L = new List<string>();
            string StrSQL = "Select * from composant";
            DataTable Table = DBConnection.Select(StrSQL);
            if (Table != null)
            {
                foreach (DataRow prime in Table.Rows) // Loop through List with foreach
                {
                    L.Add((String)prime["libelleComposant"]);
                }
            }
            else
                return null;
            return L;
        }

        public static void local_internat()
        {
            List<string> list = new List<string>();
            list = SelectAll();
            foreach (String libelleComposant in list) 
            {
                if (composant( Program.UUIDMachine,libelleComposant))
                { }
            }
            String str = "DELETE FROM [composant] ";
            DBConnection.Update(str);
        }

        public static int count()
        {
            String str = "SELECT COUNT (Id)  FROM [composant] ";
            return DBConnection.count(str);
        }
   
    
    }


}
