using System.IO;

namespace Data.Repository
{
    public interface ILogWriter
    {
        TextWriter Get();
    }
}
