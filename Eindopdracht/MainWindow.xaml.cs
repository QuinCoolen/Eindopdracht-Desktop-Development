using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Eindopdracht.classes;

namespace Eindopdracht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DBConnection dbConnection = new DBConnection();
            People = dbConnection.GetAllPeople();
            Countries = dbConnection.GetAllCountries();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string Property = "")
        {
            DBConnection dbConnection = new DBConnection();
            FavCountry = dbConnection.GetFavouriteCountries(OnePerson);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private ObservableCollection<Person> people;
        private ObservableCollection<Country> countries;

        public ObservableCollection<Person> People
        {
            get { return people; }
            set { people = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Country> Countries
        {
            get { return countries; }
            set { countries = value; }
        }

        private Person oneperson;

        public Person OnePerson
        {
            get { return oneperson; }
            set { oneperson = value;
                NotifyPropertyChanged();
            }
        }

        private Country onecountry;

        public Country OneCountry
        {
            get { return onecountry; }
            set { onecountry = value; }
        }

        private ObservableCollection<FavCountry> favcountry;

        public ObservableCollection<FavCountry> FavCountry
        {
            get { return favcountry; }
            set { favcountry = value;
            }
        }

        private FavCountry onefavcountry;

        public FavCountry OneFavCountry
        {
            get { return onefavcountry; }
            set { onefavcountry = value; }
        }

        private void btAddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddPerson addpersonwin = new AddPerson();
            addpersonwin.Show();
            this.Close();
        }

        private void btDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (OnePerson == null)
            {
                MessageBox.Show("Je hebt geen persoon geselecteerd om te verwijderen");
            } else
            {
                DBConnection dbConnection = new DBConnection();
                dbConnection.DeletePerson(oneperson.ID);
                People = dbConnection.GetAllPeople();
                NotifyPropertyChanged();
            }
        }

        private void btAddFavCountry_Click(object sender, RoutedEventArgs e)
        {
            if (OneCountry == null || OnePerson == null)
            {
                MessageBox.Show("Je hebt geen persoon of land geselecteerd om toe te voegen.");
            } else
            {
                DBConnection dbConnection = new DBConnection();
                dbConnection.InsertFavCountry(oneperson.ID, onecountry.CountryID, onecountry.CountryName);
                NotifyPropertyChanged();
            }

        }

        private void btDeleteFavCountry_Click(object sender, RoutedEventArgs e)
        {

            if (OneFavCountry == null || OnePerson == null)
            {
                MessageBox.Show("Je hebt geen land geselecteerd om te verwijderen");
            } else
            {
                DBConnection dbConnection = new DBConnection();
                dbConnection.DeleteFavCountry(onefavcountry.CountryName, oneperson.ID);
                NotifyPropertyChanged();
            }
        }
    }
}
