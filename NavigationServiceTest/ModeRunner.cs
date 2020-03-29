using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NavigationServiceTest
{
    [MyAspect]
    internal class ModeRunner : ContextBoundObject
    {
        public static ModeRunner GetRunnner(MyMode mode)
        {
            return new ModeRunner(mode);            
        }

        internal Action<IEnumerable<MyArg>> Run { get; private set; }

        public ModeRunner(MyMode mode)
        {
            switch (mode)
            {
                case MyMode.Normal:
                    Run = RunNormalMode;
                    break;
                case MyMode.Test:
                    Run = RunTestMode;
                    break;
                default:
                    Run = (s) => App.Current.Shutdown();
                    break;
            }
        }

        private void RunTestMode(IEnumerable<MyArg> myArgs)
        {
            throw new NotImplementedException();
        }

        private void RunNormalMode(IEnumerable<MyArg> myArgs)
        {
            //SettingsHandler.GetSetting(myArgs);
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Debug.WriteLine("Start Normal Mode");
            return;
        }
    }
}