using System;
using System.Linq;
using Core.DomainObjects;
using Data.DomainObjects;
using Core.Helpers;
using Core.Exceptions;
using Core.Repository;

namespace Data.Repository
{
    public class FavoritesRepository : BaseRepository<IFavorites, Favorites>, IFavoritesRepository
    {
        LogWriter writer = new LogWriter();

        public FavoritesRepository( IRelationshipsDatabase database ) : base( database ) { }
        public FavoritesRepository( IRelationshipsDatabaseFactory factory ) : base( factory ) { }

        private IQueryable<IFavorites> GetAll()
        {
            return Database.FavoritesDataSource;
        }

        public IFavorites FindById( Guid id ) {
            return GetAll().SingleOrDefault( x => x.Id == id );
        }

        public override void Add(IFavorites entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            if (GetAll().Any(art => art.Id == entity.Id))
            {
                writer.WriteLine("Favorites with an id={0}".FormatWith(entity.Id));
                throw new AlreadyExistsException("Favorites with an id={0}".FormatWith(entity.Id));
            }
            else
            {
                base.Add(entity);
            }
        }

        public override void Remove(IFavorites entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            base.Remove(entity);
        }
    }
}
