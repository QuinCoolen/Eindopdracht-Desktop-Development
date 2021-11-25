using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        DBConnection cnn = new DBConnection();
        public AddPerson()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.InsertPerson(tbFirstName.Text, tbLastName.Text);
            MainWindow kaka = new MainWindow();
            kaka.Show();
            this.Close();
        }
    }
}
