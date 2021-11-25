using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.classes
{
    public class Person
    {
        private int id;
        private string firstname;
        private string lastname;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Fullname
        {
            get { return firstname + " " + lastname; }
        }
    }
}
