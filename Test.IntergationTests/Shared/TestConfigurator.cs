using System;
using System.Collections.Generic;
using System.Text;

namespace Test.IntergationTests.Shared
{
    public static class TestConfigurator
    {
        private static string _environmentConfiguration;

        public static string EnvironmentConfiguration
        {
            get
            {
                if (_environmentConfiguration == null)
                    _environmentConfiguration = GetEnvironmentConfiguration();
                return _environmentConfiguration;
            }

        }

        private static string GetEnvironmentConfiguration()
        {
            return EnvironmentSetting.Development.ToString(); ;
        }

    }

    public enum EnvironmentSetting
    {
        Development,
        Production
    }
}
