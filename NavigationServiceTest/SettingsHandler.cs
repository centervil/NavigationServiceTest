using NavigationServiceTest.Properties;
using System.Collections.Generic;
using System.Configuration;

namespace NavigationServiceTest
{
    internal class SettingsHandler
    {
        private static readonly Dictionary<string, MyArgName> settingsDictionary
            = new Dictionary<string, MyArgName>
            {
                { nameof(Settings.Default.testSetBool), MyArgName.Test },
                { nameof(Settings.Default.testSetInt), MyArgName.DebugLevel },
            };

        internal static void SetConfiguration(IEnumerable<MyArg> myArgs)
        {
            Settings settings = Settings.Default;
            foreach (SettingsProperty property in settings.Properties)
            {
                var name = property.Name;
                var value = settings[name];
            }
        }

        internal static bool TryGetConfiguration<T>(out T value, MyArgName argName)
        {
            Settings settings = Settings.Default;
            foreach (SettingsProperty property in settings.Properties)
            {
                if (settingsDictionary[property.Name] != argName)
                {
                    continue;
                }

                var propertyValue = settings[property.Name];
                if (property is T)
                {
                    value = (T)propertyValue;
                    return true;
                }
                else
                {
                    break;
                }
            }

            value = default(T);
            return false;
        }
    }
}
