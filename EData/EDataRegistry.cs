using StructureMap.Configuration.DSL;
using EData.Repository;
using Core.Repository;

namespace EData
{
    public class EDataRegistry : Registry
    {
        public EDataRegistry() {
            For<IConnectionString>()
                   .Singleton()
                   .Use<ConnectionString>()
                   .WithCtorArg( "connectionStringKey" ).EqualTo( "RelationshipsEntities" );

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









            //Repositories
            For<IArtistRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<ArtistRepository>()
                .Ctor<IRelationshipsDatabaseFactory>("factory").IsTheDefault();

            SelectConstructor<ArtistRepository>(() => new ArtistRepository((IRelationshipsDatabaseFactory)null));

            For<IFavoritesRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<FavoritesRepository>()
                .Ctor<IRelationshipsDatabaseFactory>("factory").IsTheDefault();

            SelectConstructor<FavoritesRepository>(() => new FavoritesRepository((IRelationshipsDatabaseFactory)null));

            For<IFlowersRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<FlowersRepository>()
                .Ctor<IRelationshipsDatabaseFactory>("factory").IsTheDefault();

            SelectConstructor<FlowersRepository>(() => new FlowersRepository((IRelationshipsDatabaseFactory)null));

            For<IGenericFavoriteRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<GenericFavoriteRepository>()
                .Ctor<IRelationshipsDatabaseFactory>("factory").IsTheDefault();

            SelectConstructor<GenericFavoriteRepository>(() => new GenericFavoriteRepository((IRelationshipsDatabaseFactory)null));

            For<IGiftRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<GiftRepository>()
                .Ctor<IRelationshipsDatabaseFactory>("factory").IsTheDefault();

            SelectConstructor<GiftRepository>(() => new GiftRepository((IRelationshipsDatabaseFactory)null));

            For<IRelationshipRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<RelationshipRepository>()
                .Ctor<IRelationshipsDatabaseFactory>("factory").IsTheDefault();

            SelectConstructor<RelationshipRepository>(() => new RelationshipRepository((IRelationshipsDatabaseFactory)null));

            For<IRestaurantRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<RestaurantRepository>()
                .Ctor<IRelationshipsDatabaseFactory>("factory").IsTheDefault();

            SelectConstructor<RestaurantRepository>(() => new RestaurantRepository((IRelationshipsDatabaseFactory)null));
        }
    }
}