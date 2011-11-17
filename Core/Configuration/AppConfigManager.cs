namespace Core.Configuration
{
    using System;
    using System.Diagnostics;
    using System.Collections.Specialized;
    using System.Configuration;
    using Core.Helpers;

    public class AppConfigManager : IAppConfigManager
    {

        public NameValueCollection AppSettings
        {
            [DebuggerStepThrough]
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        //[DebuggerStepThrough]
        public string ConnectionStrings(string name)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings == null)
            {
                throw new ConfigurationErrorsException("A connection string named '{0}' could not be found in the application configuration file.".FormatWith(name));
            }
            return settings.ConnectionString;
        }

        public TType GetAppSetting<TType>(string key, TType defaultValue, Func<string, TType> converter)
        {
            Checks.Argument.IsNotEmpty(key, "key");
            TType retVal;
            string val = AppSettings[key];

            retVal = !string.IsNullOrEmpty(val) ? converter(AppSettings[key]) : defaultValue;

            return retVal;
        }

        [DebuggerStepThrough]
        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }
    }
}
