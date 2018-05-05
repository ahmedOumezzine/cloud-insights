using Cloud_Insights.Donnee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Insights.Donnee
{
    class Composant
    {
        public int _IDComposant
        {
            get //get method for returning value
            {
                return _IDComposant;
            }
            set // set method for storing value in name field.
            {
                _IDComposant = value;
            }
        }
        public string _libelleComposant
        {
            get //get method for returning value
            {
                return _libelleComposant;
            }
            set // set method for storing value in name field.
            {
                _libelleComposant = value;
            }
        }

        public Composant()
        {
        }


        public Composant(DataRow dr)
        {
            // Id
            _IDComposant = (int)dr["Id"];

            //libelleComposant
            _libelleComposant = dr["libelleComposant"] == System.DBNull.Value ? "" : (string)dr["libelleComposant"];
        }

  
    }
}

    
