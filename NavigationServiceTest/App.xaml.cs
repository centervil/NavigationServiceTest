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
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            var mode = ArgsHandler.GetMode(e.Args);
            var myArgs = ArgsHandler.GetMyArgs(e.Args);

            ModeRunner.GetRunnner(mode).Run?.Invoke(myArgs);
            new ModeRunner(mode).Run?.Invoke(myArgs);
        }
    }
}