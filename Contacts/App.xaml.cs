﻿using System;
using System.IO;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Contacts.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string databasePath = Path.Combine(folderPath, databaseName);
    }
}
