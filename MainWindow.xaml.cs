using DesktopContacts.Classes;
using System;
using System.Collections.Generic;
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

namespace DesktopContacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
           
            InitializeComponent();
            contacts = new List<Contact>();
            readDatabase();
        }

        private void readDatabase()
        {
           
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasepath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();                
            }

            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewConctactWindow newConctactWindow = new NewConctactWindow();
            newConctactWindow.ShowDialog();
            readDatabase();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.Contains(searchTextBox.Text)).ToList();

            contactsListView.ItemsSource = filteredList;
        }
    }
}
