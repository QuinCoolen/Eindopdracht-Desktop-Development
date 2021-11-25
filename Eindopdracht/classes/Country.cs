using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.classes
{
    public class Country
    {
        private int countryid;

        private string countryname;

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
