using DesktopContacts.Classes;
using SQLite;
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
using System.Windows.Shapes;

namespace DesktopContacts
{
    /// <summary>
    /// Interaction logic for NewConctactWindow.xaml
    /// </summary>
    public partial class NewConctactWindow : Window
    {
        public NewConctactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text
            };


            using (SQLiteConnection connection = new SQLiteConnection(App.databasepath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
            this.Close();
        }
    }
}
