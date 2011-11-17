
namespace Core.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using StructureMap;

    public class DependencyResolver : IDependencyResolver
    {
        #region IDependencyResolver Members

        [DebuggerStepThrough]
        public TType GetInstance<TType>()
        {
            return (TType)GetInstance(typeof(TType));
        }

        [DebuggerStepThrough]
        public object GetInstance(Type type)
        {
            try
            {
                return ObjectFactory.GetInstance(type);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [DebuggerStepThrough]
        public void BuildUp(object target)
        {
            try
            {
                ObjectFactory.BuildUp(target);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [DebuggerStepThrough]
        public IEnumerable<object> GetAllInstances(Type type)
        {
            foreach (object obj in ObjectFactory.GetAllInstances(type))
            {
                yield return obj;
            }
        }

        [DebuggerStepThrough]
        public IEnumerable<TType> GetAllInstances<TType>()
        {
            foreach (TType obj in GetAllInstances(typeof(TType)))
            {
                yield return (TType)obj;
            }
        }

        [DebuggerStepThrough]
        public void DisposeInstance(object instance)
        {
        }

        [DebuggerStepThrough]
        public TType GetNamedInstance<TType>(string key)
        {
            return (TType)GetNamedInstance(typeof(TType), key);
        }

        [DebuggerStepThrough]
        public object GetNamedInstance(Type type, string key)
        {
            return ObjectFactory.GetNamedInstance(type, key);
        }

        #endregion
    }
}
