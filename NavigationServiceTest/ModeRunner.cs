using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NavigationServiceTest
{
    [MyAspect]
    internal class ModeRunner : ContextBoundObject
    {
        private readonly MyMode mode;
        private readonly IEnumerable<MyArg> myArgs;

        public ModeRunner(MyMode mode, IEnumerable<MyArg> myArgs)
        {
            this.mode = mode;
            this.myArgs = myArgs;
        }

        internal void Run()
        {
            switch (mode)
            {
                case MyMode.NoArgs:
                    RunNormalMode();
                    break;
                case MyMode.Empty:
                case MyMode.Unknown:
                    break;
                case MyMode.Normal:
                    RunNormalMode();
                    break;
                case MyMode.Test:
                    RunTestMode();
                    break;
            }
        }

        private void RunTestMode()
        {
            throw new NotImplementedException();
        }

        private void RunNormalMode()
        {
            Debug.WriteLine("Start Normal Mode");
            return;
        }
    }
}