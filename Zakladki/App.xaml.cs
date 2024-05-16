using System.Configuration;
using System.Data;
using System.IO;
using System.Text.Json.Nodes;
using System.Windows;
using Zakladki.Class;

namespace Zakladki
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DatabaseFunctions? Database;
        public static DatabaseFunctions DataAccess
        {
            get
            {
                if (Database == null)
                {
                    Database = new DatabaseFunctions(Path.Combine(Directory.GetCurrentDirectory(), "AdvertisementSystem_WPF.db3"));
                }
                return Database;
            }
        }
        public App()
        {
            //FileFunctions.createPath();
            JsonFunctions.createPath();
        }
    }

}
