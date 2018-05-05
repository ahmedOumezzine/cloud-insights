using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_Insights.BLL
{
    class BLL_Connection
    {
        DAL.DAL_login a = new DAL.DAL_login();

        internal Boolean verifier_lien(string lien)
        {
            WebResponse response;
            try
            {
                Uri uri = new Uri(lien);
                WebRequest request = WebRequest.Create(uri);
                request.Timeout = 3000;
                response = request.GetResponse();
                if (response.ToString() == "System.Net.HttpWebResponse")
                    return true;
            }
            catch (Exception loi) { }
            //  System.Net.HttpWebResponse

            return false;
        }

        internal bool verifier_usertechicien(string login, string motpasse)
        {
            if (a.connectionTech(login, motpasse))
            {

                return true;
            }
            return false;
        }



        internal bool verifier_usermachine(string idsociete, string motpasse, string UUIDmachine)
        {
            if (a.connection(idsociete, motpasse, UUIDmachine))
            {
                return true;
            }
            return false;
        }
    }
}

