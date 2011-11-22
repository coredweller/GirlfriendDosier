using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Data.Linq;
using Core.DomainObjects;
using Data.DomainObjects;

namespace Data.Repository
{
    public partial class RelationshipsDatabase : IRelationshipsDatabase
    {
        public RelationshipsDatabase( IConnectionString connectionString ) : this( connectionString.Value ) { }

        public IQueryable<IRelationship> RelationshipDataSource {
            get { return GetQueryable<Relationship>().Cast<IRelationship>(); }
        }

        public IQueryable<IArtist> ArtistDataSource {
            get { return GetQueryable<Artist>().Cast<IArtist>(); }
        }

        public IQueryable<IFavorites> FavoritesDataSource {
            get { return GetQueryable<Favorites>().Cast<IFavorites>(); }
        }

        public IQueryable<IFlowers> FlowersDataSource {
            get { return GetQueryable<Flowers>().Cast<IFlowers>(); }
        }

        public IQueryable<IGenericFavorite> GenericFavoriteDataSource {
            get { return GetQueryable<GenericFavorite>().Cast<IGenericFavorite>(); }
        }

        public IQueryable<IGift> GiftDataSource {
            get { return GetQueryable<Gift>().Cast<IGift>(); }
        }

        public IQueryable<IRestaurant> RestaurantDataSource {
            get { return GetQueryable<Restaurant>().Cast<IRestaurant>(); }
        }


        public virtual IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
        { 
            return GetTable<TEntity>();
        }

        [DebuggerStepThrough]
        public virtual ITable GetEditable<TEntity>() where TEntity : class {
            return GetTable<TEntity>();
        }
        
        [DebuggerStepThrough]
        public virtual IList<TEntity> InsertChangeSet<TEntity>() where TEntity : class {
            var items = GetChangeSet().Inserts.Where( x => x.GetType() == typeof(TEntity) );
            return items.Cast<TEntity>().ToList();
        }
        
        [DebuggerStepThrough]
        public virtual IList<TEntity> UpdateChangeSet<TEntity>() where TEntity : class {
            var items = GetChangeSet().Updates.Where( x => x.GetType() == typeof(TEntity) );
            return items.Cast<TEntity>().ToList();
        }
        
        [DebuggerStepThrough]
        public virtual IList<TEntity> DeleteChangeSet<TEntity>() where TEntity : class {
            var items = GetChangeSet().Deletes.Where( x => x.GetType() == typeof(TEntity) );
            return items.Cast<TEntity>().ToList();
        }

        [DebuggerStepThrough]
        public void Insert<TEntity>( TEntity instance ) where TEntity : class {
            GetEditable<TEntity>().InsertOnSubmit( instance );
        }

        [DebuggerStepThrough]
        public void InsertAll<TEntity>( IEnumerable<TEntity> instances ) where TEntity : class {
            GetEditable<TEntity>().InsertAllOnSubmit( instances );
        }

        [DebuggerStepThrough]
        public void Delete<TEntity>( TEntity instance ) where TEntity : class {
            GetEditable<TEntity>().DeleteOnSubmit( instance );
        }

        [DebuggerStepThrough]
        public void DeleteAll<TEntity>( IEnumerable<TEntity> instances ) where TEntity : class {
            GetEditable<TEntity>().DeleteAllOnSubmit( instances );
        }

        protected new void Dispose( bool disposing ) {

            if (base.Connection != null)
                if (base.Connection.State != System.Data.ConnectionState.Closed)
                {
                    base.Connection.Close();
                    base.Connection.Dispose();
                }

            base.Dispose();            

        }
    }
}
