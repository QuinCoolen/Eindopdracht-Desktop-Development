using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.classes
{
    public class FavCountry
    {

        private int id;
        private int personid;
        private int countryid;
        private string countryname;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int PersonID
        {
            get { return personid; }
            set { personid = value; }
        }
        public int CountryID
        {
            get { return countryid; }
            set { countryid = value; }
        }

        public string CountryName
        {
            get { return countryname; }
            set { countryname = value; }
        }
    }
}
