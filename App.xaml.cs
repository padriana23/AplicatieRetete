using System;
using AplicatieRetete.Data;
using System.IO;

namespace AplicatieRetete;

public partial class App : Application
{
    static ReteteDatabase database;
    public static ReteteDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               ReteteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Retete.db3"));
            }
            return database;
        }
    }

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}