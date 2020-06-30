using Contacts.Classes;
using SQLite;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for DetailedContactWindow.xaml
    /// </summary>
    public partial class DetailedContactWindow : Window
    {
        Contact contact;
        public DetailedContactWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;

            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;

            //One-time transaction with SQLite using the "Using" statement
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Creating a table if it does not already exist(Type-safe Generic Method)
                connection.CreateTable<Contact>();

                //Inserting a contact(Type-safe Generic Method)
                connection.Update(contact);
            }

            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //One-time transaction with SQLite using the "Using" statement
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Creating a table if it does not already exist(Type-safe Generic Method)
                connection.CreateTable<Contact>();

                //Inserting a contact(Type-safe Generic Method)
                connection.Delete(contact);
            }

            this.Close();
        }
    }
}
