using Contacts.Classes;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Contacts
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

            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();

                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
                
                /*
                Alternative(SQL like syntax for Linq)
                contacts = conn.Table<Contact>().ToList();
                contacts = (from c in contacts
                                orderby c.Name
                                select c).ToList();
                */

            }

            if(contacts != null)
            {
                /*
                Will produce spurious repeated entries when a new element is added
                foreach(var c in contacts)
                {

                    contactsListView.Items.Add(new ListViewItem()
                    {
                        Content=c
                    });
                */
                contactsListView.ItemsSource = contacts;

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            /*
            Alternative(SQL like syntax for Linq)
            var filteredList = (from c in contacts
                                where c.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                orderby c.Name
                                select c).ToList();
            */

            contactsListView.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                DetailedContactWindow detailedContactWindow = new DetailedContactWindow(selectedContact);
                detailedContactWindow.ShowDialog();

                ReadDatabase();
            }
        }
    }
}
