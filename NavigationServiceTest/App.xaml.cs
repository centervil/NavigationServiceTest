using System.Windows;

namespace NavigationServiceTest
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        [System.STAThreadAttribute()]
        static public void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Startup += App_Startup;
            app.Run();
        }

        private static void App_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var navigationServiceEx = new NavigationServiceEx(mainWindow);
            var viewModelFactory = new ViewModelFactory(navigationServiceEx);
            mainWindow.Show();
        }
    }
}