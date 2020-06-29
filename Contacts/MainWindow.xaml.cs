using Contacts.Classes;
using SQLite;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();

        }

        void ReadDatabase()
        {
            List<Contact> contacts;
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>().ToList();
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
    }
}
