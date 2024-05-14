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
        public App()
        {
            FileFunctions.createPath();
            //JsonFunctions.createPath();
        }
    }

}
