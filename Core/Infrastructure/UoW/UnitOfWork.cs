
namespace Core.Infrastructure
{
    using System.Diagnostics;

    public static class UnitOfWork
    {
        public static IUnitOfWork Begin()
        {
            return Ioc.GetInstance<IUnitOfWork>();
        }
    }
}
