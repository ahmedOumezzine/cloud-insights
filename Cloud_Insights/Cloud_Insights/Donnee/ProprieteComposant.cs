using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Insights.Donnee
{
    class ProprieteComposant
    {
          public ProprieteComposant()
        { }
          public ProprieteComposant(DataRow dr)
        {
             _idcomposant = dr["IDCompsant"] == System.DBNull.Value ? "" : (string)dr["IDCompsant"];
             _ProprieteComposant = dr["ProprieteComposant"] == System.DBNull.Value ? "" : (string)dr["ProprieteComposant"];
             _valeurProprieteComposant = dr["valeurProprieteComposant"] == System.DBNull.Value ? "" : (string)dr["valeurProprieteComposant"];
             _ipProprieteComposant = dr["ipProprieteComposant"] == System.DBNull.Value ? "" : (string)dr["ipProprieteComposant"];
 
        }

          public string _idcomposant;

          public string _ProprieteComposant;

          public string _valeurProprieteComposant;

          public string _ipProprieteComposant;
    }
}
