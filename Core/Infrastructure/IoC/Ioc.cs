
namespace Core.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    //using log4net;
    using Core.Helpers;
    using Core.Exceptions;

    public static class Ioc
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(Ioc));
        private static IDependencyResolver _resolver;


        [DebuggerStepThrough]
        public static void InitializeWith(IDependencyResolverFactory factory)
        {
            Checks.Argument.IsNotNull(factory, "factory");

            _resolver = factory.CreateInstance();
        }

        [DebuggerStepThrough]
        public static void BuildUp(object target)
        {
            var typeName = target.GetType().ToString();
            try
            {
                _resolver.BuildUp(target);
            }
            catch (Exception ex)
            {
                //log.Fatal("Ioc could not build an instance of {0} type.".FormatWith(typeName));
                throw new ObjectCreationException();
            }
        }


        [DebuggerStepThrough]
        public static TType GetInstance<TType>()
        {
            var obj = _resolver.GetInstance<TType>();
            if (obj == null)
            {
                //log.Fatal("Ioc could not create an instance of {0} type.".FormatWith(typeof(TType)));
                throw new ObjectCreationException();
            }
            return obj;
        }


        [DebuggerStepThrough]
        public static object GetInstance(Type type)
        {
            var obj = _resolver.GetInstance(type);
            if (obj == null)
            {
                //log.Fatal("Ioc could not create an instance of {0} type.".FormatWith(type.ToString()));
                throw new ObjectCreationException();
            }
            return obj;
        }


        [DebuggerStepThrough]
        public static IEnumerable<TType> GetAllInstances<TType>()
        {
            var obj = _resolver.GetAllInstances<TType>();
            if (obj == null)
            {
                //log.Fatal("Ioc could not create all instances of {0} type.".FormatWith(typeof(TType)));
                throw new ObjectCreationException();
            }
            return obj;
        }


        [DebuggerStepThrough]
        public static IEnumerable<object> GetAllInstances(Type type)
        {
            var obj = _resolver.GetAllInstances(type);
            if (obj == null)
            {
                //log.Fatal("Ioc could not create all instances of {0} type.".FormatWith(type.ToString()));
                throw new ObjectCreationException();
            }
            return obj;
        }
    }
}
