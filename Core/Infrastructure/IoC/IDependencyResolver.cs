
namespace Core.Infrastructure
{
    using System;
    using System.Collections.Generic;

    public interface IDependencyResolver
    {
        TType GetInstance<TType>();
        void BuildUp(object target);
        object GetInstance(Type type);
        Interface GetNamedInstance<Interface>(string key);
        object GetNamedInstance(Type type, string key);
        IEnumerable<object> GetAllInstances(Type type);
        IEnumerable<TType> GetAllInstances<TType>();
        void DisposeInstance(object instance);
    }
}
