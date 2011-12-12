using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System;
using Core.DomainObjects;

namespace EData.Repository
{
    public interface IRelationshipsDatabase : IDisposable
    {
        void Delete<TEntity>(TEntity instance) where TEntity : class;
        //void DeleteAll<TEntity>(IEnumerable<TEntity> instances) where TEntity : class;
        //IList<TEntity> DeleteChangeSet<TEntity>() where TEntity : class;
        //ITable GetEditable<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
        void Insert<TEntity>(TEntity instance) where TEntity : class;
        //void InsertAll<TEntity>(IEnumerable<TEntity> instances) where TEntity : class;
        //IList<TEntity> InsertChangeSet<TEntity>() where TEntity : class;
        //IList<TEntity> UpdateChangeSet<TEntity>() where TEntity : class;
        int SaveChanges();
        int SaveChanges( bool acceptAllChanges );

        IQueryable<IRelationship> RelationshipDataSource { get; }
        IQueryable<IArtist> ArtistDataSource { get; }
        IQueryable<IFavorites> FavoritesDataSource { get; }
        IQueryable<IFlowers> FlowersDataSource { get; }
        IQueryable<IGenericFavorite> GenericFavoriteDataSource { get; }
        IQueryable<IGift> GiftDataSource { get; }
        IQueryable<IRestaurant> RestaurantDataSource { get; }
    }
}