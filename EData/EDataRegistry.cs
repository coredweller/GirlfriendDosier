using StructureMap.Configuration.DSL;
using EData.Repository;

namespace EData
{
    public class EDataRegistry : Registry
    {
        public EDataRegistry() {
            For<IConnectionString>()
                   .Singleton()
                   .Use<ConnectionString>()
                   .WithCtorArg( "connectionStringKey" ).EqualTo( "RelationshipsConnectionString" );

            For<Core.Infrastructure.IUnitOfWork>()
                    .HybridHttpOrThreadLocalScoped()
                    .Use<EData.Repository.UnitOfWork>();
            SelectConstructor<EData.Repository.UnitOfWork>( () => new EData.Repository.UnitOfWork( (IRelationshipsDatabaseFactory)null ) );

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