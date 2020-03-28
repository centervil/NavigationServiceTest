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
            var mode = ArgsHandler.GetMode(e.Args);
            var myArgs = ArgsHandler.GetMyArgs(e.Args);

            var modeRunner = new ModeRunner(mode, myArgs);
            modeRunner.Run();
        }
    }
}