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
    class DAL_proprieteComposant
    {
        public static Boolean inserpropocomposant(String idcomposant, String  ProprieteComposant, String valeurProprieteComposant, String ipProprieteComposant)
        {
            try
            {
              Donnee.Json p;
              string urlAddress = Program.Server + "/pfe/api/proprietecomposant/addpcomposant.php";
                using (WebClient client = new WebClient())
                {
                    NameValueCollection postData = new NameValueCollection();
                    {
                        postData.Add("IDSociete", Program.id);
                        postData.Add("mdp_crypt", Program.code);
                        postData.Add("IDCompsant", idcomposant);
                        postData.Add("ProprieteComposant", ProprieteComposant);
                        postData.Add("valeurProprieteComposant", valeurProprieteComposant);
                        postData.Add("ipProprieteComposant", ipProprieteComposant);

                    };
                    string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    p = serializer.Deserialize<Donnee.Json>(pagesource);
                 }
                if (p.erreur == "0") {
                    return true;
                }
                else {
                    Program.cout++;
                    System.Threading.Thread.Sleep(Program.cout * 1000);
                    String str = "INSERT INTO [propretecomposant] ([IDCompsant],[ProprieteComposant],[valeurProprieteComposant],[ipProprieteComposant]) VALUES ('" + idcomposant + "','" + ProprieteComposant + "','" + valeurProprieteComposant + "','" + ipProprieteComposant + "')";
                    DBConnection.Update(str);
                    return false;
                }
            }
            catch (Exception eee)
            {
                Program.cout++;
                System.Threading.Thread.Sleep(Program.cout * 1000); 
                String str1 = "INSERT INTO [erreur]  ([msg],[date])  VALUES ('" + eee.ToString() + "'," + DateTime.Now + ")";
                DBConnection.Update(str1);
                String str = "INSERT INTO [propretecomposant] ([IDCompsant],[ProprieteComposant],[valeurProprieteComposant],[ipProprieteComposant]) VALUES ('" + idcomposant + "','" + ProprieteComposant + "','" + valeurProprieteComposant + "','" + ipProprieteComposant + "')";
                DBConnection.Update(str);
                return false;
            }
        }

        public static void local_internat()
        {
            List<Donnee.ProprieteComposant> list = new List<Donnee.ProprieteComposant>();
            list = pSelectAll();
            foreach (Donnee.ProprieteComposant prime in list) // Loop through List with foreach
            {
                if (inserpropocomposant(prime._idcomposant,prime._ProprieteComposant, prime._valeurProprieteComposant, prime._ipProprieteComposant))
                { }

            }
            String str = "DELETE FROM [propretecomposant] ";
            DBConnection.Update(str);
        }

        public static List<Donnee.ProprieteComposant> pSelectAll()
        {
            List<Donnee.ProprieteComposant> L = new List<Donnee.ProprieteComposant>();
            String StrSQL = "Select * from [propretecomposant]";
            DataTable Table = DBConnection.Select(StrSQL);
            if (Table != null)
            {
                foreach (DataRow prime in Table.Rows)
                {
                    L.Add(new Donnee.ProprieteComposant(prime));
                }
            }
            else
                return null;
            return L;
        }

        public static int count()
        {
            String str = "SELECT COUNT (Id)  FROM [propretecomposant] ";
            return DBConnection.count(str);
        }
   
    
    }
}
