using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.classes
{
    public class DBConnection
    {
        string connString = ConfigurationManager.ConnectionStrings["ConnEindDB"].ConnectionString;

        public ObservableCollection<Person> GetAllPeople()
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>();
            DataTable result = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from People";
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            foreach (DataRow row in result.Rows)
            {
                Person somePerson = new Person();
                somePerson.ID = Convert.ToInt32(row["ID"].ToString());
                somePerson.Firstname = row["Firstname"].ToString();
                somePerson.Lastname = row["Lastname"].ToString();
                people.Add(somePerson);
            }
            return people;
        }

        public DataTable InsertPerson(string FirstName, string LastName)
        {
            DataTable result = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO People VALUES(@FirstName, @LastName); ";
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            return result;
        }

        public DataTable DeletePerson(int ID)
        {
            DataTable result = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM People WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            return result;
        }





        public ObservableCollection<Country> GetAllCountries()
        {
            ObservableCollection<Country> countries = new ObservableCollection<Country>();
            DataTable result = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from Countries";
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            foreach (DataRow row in result.Rows)
            {
                Country someCountry = new Country();
                someCountry.CountryID = Convert.ToInt32(row["CountryID"]);
                someCountry.CountryName = row["CountryName"].ToString();
                countries.Add(someCountry);
            }
            return countries;
        }

        public ObservableCollection<FavCountry> GetFavouriteCountries(Person oneperson)
        {
            ObservableCollection<FavCountry> favcountries = new ObservableCollection<FavCountry>();
            DataTable result = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                if (oneperson == null) return null;

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT People.ID, FavouriteCountries.CountryName FROM People INNER JOIN FavouriteCountries ON People.ID = FavouriteCountries.PersonID WHERE People.ID = @id; ";
                cmd.Parameters.AddWithValue("@id", oneperson.ID.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            foreach (DataRow row in result.Rows)
            {
                FavCountry someFavCountry = new FavCountry();
                someFavCountry.CountryName = row["CountryName"].ToString();
                favcountries.Add(someFavCountry);
            }
            return favcountries;
        }

        public DataTable InsertFavCountry(int PersonID, int CountryID, string CountryName)
        {
            DataTable result = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO FavouriteCountries VALUES(@PersonID, @CountryID, @CountryName); ";
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@CountryID", CountryID);
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            return result;
        }

        public bool DeleteFavCountry(string CountryName, int PersonID)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                bool succes = false;
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM FavouriteCountries WHERE CountryName = @CountryName AND PersonID = @PersonID";
                    cmd.Parameters.AddWithValue("@CountryName", CountryName);
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    int rowsaffected = cmd.ExecuteNonQuery();
                    succes = (rowsaffected != 0);
                }
                catch (Exception e)
                {

                }
                finally
                {
                    con.Close();
                }
                return succes;
            }
        }
    }
}
