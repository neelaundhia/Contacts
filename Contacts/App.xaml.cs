using System;
using System.IO;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string databaseName = "Contacts.db";
        public string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string databasePath = Path.Combine(folderPath, databaseName);
    }
}
