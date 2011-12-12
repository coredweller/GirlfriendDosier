using System.IO;

namespace EData.Repository
{
    public interface ILogWriter
    {
        TextWriter Get();
    }
}
