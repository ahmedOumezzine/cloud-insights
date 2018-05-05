using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_Insights.DAL
{
    class DAL_login
    {
        public  Boolean connectionTech(String user, String pwd)
        {
            Donnee.Json p;
            string urlAddress =Program.Server+ "/pfe/API/connexion/connection_tech.php";
            using (WebClient client = new WebClient())
            {
                NameValueCollection postData = new NameValueCollection();
                {
                    postData.Add("username", user);
                    postData.Add("password", pwd);
                };
                string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                p = serializer.Deserialize<Donnee.Json>(pagesource);
            }
            if (p.erreur == "0")
                return true;
            else if (p.erreur == "1")
            {
                MessageBox.Show("Désolé, ce nom d'utilisateur / mot de passe est invalide");
                return false;
            }
            else if (p.erreur == "2")
            {
                MessageBox.Show("Désolé que le nom d'utilisateur n'existe pas.");
                return false;
            }
            else if (p.erreur == "3")
            {
                MessageBox.Show("Désolé, mais nous avons besoin de votre nom d'utilisateur et mot de passe.");
                return false;
            }
            return false;
        }

        public Boolean connection(String idsociete, String pwd, String IDmachine)
        {
             try
            {
                Donnee.Json p;
                string urlAddress = Program.Server+ "/pfe/API/connexion/connection_machine.php";
                using (WebClient client = new WebClient())
                {
                    NameValueCollection postData = new NameValueCollection();
                    {
                        postData.Add("IDSociete", idsociete);
                        postData.Add("password", pwd);
                        postData.Add("UUIDMachine", IDmachine);
                    };
                    string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    p = serializer.Deserialize<Donnee.Json>(pagesource);
                }
                MessageBox.Show(p.message);
                if (p.erreur == "0")
                {
                    Program.id = idsociete;
                    Program.code = p.message;

                    return true;
                }
            }
            catch (Exception eee)
            {
                String str1 = "INSERT INTO [erreur]  ([msg],[date])  VALUES ('" + eee.ToString() + "'," + DateTime.Now + ")";
                DBConnection.Update(str1);
            }
            return false;
        }
    }


}
