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
        string databaseName = "Contacts.db";
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string databasePath = Path.Combine(folderPath, databaseName);
    }
}
