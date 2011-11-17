namespace Core.Configuration
{
    using System.Collections.Specialized;

    public interface IAppConfigManager
    {
        NameValueCollection AppSettings
        {
            get;
        }
        string ConnectionStrings(string name);
        T GetSection<T>(string sectionName);
    }
}
