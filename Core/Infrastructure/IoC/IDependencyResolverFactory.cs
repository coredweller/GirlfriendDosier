
namespace Core.Infrastructure
{
    using System;

    public interface IDependencyResolverFactory
    {
        IDependencyResolver CreateInstance();
    }
}