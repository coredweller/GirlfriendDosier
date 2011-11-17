
namespace Core.Infrastructure
{
    using Core.Helpers;

    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly IDependencyResolver _resolver;

        public DependencyResolverFactory(IDependencyResolver resolver)
        {
            Checks.Argument.IsNotNull(resolver, "resolver");
            _resolver = resolver;
        }


        public IDependencyResolver CreateInstance()
        {
            return _resolver as IDependencyResolver;
        }
    }
}
