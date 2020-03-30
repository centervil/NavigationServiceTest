using System;
using System.Collections.Generic;

namespace NavigationServiceTest
{
    internal static class ArgsHandler
    {
        internal static MyMode GetMode(string[] args)
        {
            if ((args is null) || (args?.Length == 0))
            {
                return MyMode.NoArgs;
            }

            if (string.IsNullOrWhiteSpace(args[0]))
            {
                return MyMode.Empty;
            }

            switch (args[0])
            {
                case "/L":
                    return MyMode.Normal;
                case "/TEST":
                    return MyMode.Test;
                default:
                    return MyMode.Unknown;
            }
        }

        internal static IEnumerable<MyArg> GetMyArgs(string[] args)
        {
            if ((args is null) || (args?.Length == 0))
            {
                return null;
            }
            var myArgsList = new List<MyArg>();
            var argsList = new List<string>();
            argsList.AddRange(args);
            argsList?.RemoveAt(0);

            foreach (var arg in argsList)
            {
                var splitArg = arg.Split(':');
                if (splitArg.Length < 3)
                {
                    var key = splitArg[0];
                    var value = splitArg[1];
                    try
                    {
                        myArgsList.Add(new MyArg(key, value));
                    }
                    catch(ArgumentException)
                    {
                        continue;
                    }
                }
            }

            return myArgsList;

        }
    }

    internal class MyArg
    {
        private Dictionary<string, IEnumerable<string>> argsDictionary
            = new Dictionary<string, IEnumerable<string>>
            {
                {"/DEBUGLEVEL", new List<string>(){"1", "2"}},
                {"/DEBUGPATH", null },
                {"/DEBUGOUT", new List<string>(){"CMD", "VSCMD", "FILE"} }
            };
        private string key;
        private string value;

        public MyArg(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string Key
        {
            get { return this.key; }
            private set
            {
                if (!this.argsDictionary.ContainsKey(this.key))
                {
                    throw new ArgumentException();
                }
                this.key = value;
            }
        }

        public string Value
        {
            get { return this.value; }
            private set
            {
                foreach (var expectedValue in this.argsDictionary[this.Key])
                {
                    if ((expectedValue is null) || (value == expectedValue))
                    {
                        this.value = value;
                        break;
                    }
                }
            }
        }
    }

    internal enum MyMode
    {
        NoArgs,
        Empty,
        Normal,
        Test,
        Unknown
    }

    internal enum MyArgName
    {
        DebugOut,
        DebugLevel,
        Test,
    }
}