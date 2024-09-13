using System.IO;

namespace Concale
{
    public partial class App : Application
    {
        public static string FolderPath { get; set; }
        public App()
        {
            InitializeComponent();

            App.FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            //MainPage = new NavigationPage(new Views.NotePage());

            MainPage = new MainPage();
        }
    }
}
