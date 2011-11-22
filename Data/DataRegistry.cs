using StructureMap.Configuration.DSL;
using Data.Repository;

namespace Data
{
    public class DataRegistry : Registry
    {
        public DataRegistry() {
            For<IConnectionString>()
                   .Singleton()
                   .Use<ConnectionString>()
                   .WithCtorArg( "connectionStringKey" ).EqualTo( "RelationshipsConnectionString" );

            For<Core.Infrastructure.IUnitOfWork>()
                    .HybridHttpOrThreadLocalScoped()
                    .Use<Data.Repository.UnitOfWork>();
            SelectConstructor<Data.Repository.UnitOfWork>( () => new Data.Repository.UnitOfWork( (IRelationshipsDatabaseFactory)null ) );

            For<ILogWriter>()
                .HybridHttpOrThreadLocalScoped()
                .Use<DebuggerWriter>();
            SelectConstructor<DebuggerWriter>( () => new DebuggerWriter() );

            For<IRelationshipsDatabase>()
                .HybridHttpOrThreadLocalScoped()
                .Use<RelationshipsDatabase>()
                .Ctor<IConnectionString>( "connectionString" ).IsTheDefault();
            SelectConstructor<RelationshipsDatabase>( () => new RelationshipsDatabase( (IConnectionString)null ) );

            For<IRelationshipsDatabaseFactory>()
                .HybridHttpOrThreadLocalScoped()
                .Use<RelationshipsDatabaseFactory>();
        }
    }
}
