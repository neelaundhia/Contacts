using Contacts.Classes;
using SQLite;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save Contact
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email=emailTextBox.Text,
                Phone=phoneTextBox.Text
            };

            //Opening a connection with SQLite
            //Not a good way to opem a connection
            //SQLiteConnection connection = new SQLiteConnection(databasePath);

            //Creating a table if it does not already exist(Type-safe Generic Method)
            //connection.CreateTable<Contact>();

            //Inserting a Contact(Type-safe Generic Method)
            //connection.Insert(contact);

            //Closing the connection with SQLite
            //Not a good way to close a connection
            //connection.Close();

            //One-time transaction with SQLite using the "Using" statement
            using(SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                //Creating a table if it does not already exist(Type-safe Generic Method)
                connection.CreateTable<Contact>();

                //Inserting a contact(Type-safe Generic Method)
                connection.Insert(contact);
            }

            this.Close();
        }
    }
}
