using System;
using System.Linq;
using Core.DomainObjects;
using EData;
using Core.Helpers;
using Core.Exceptions;
using Core.Repository;

namespace EData.Repository
{
    public class GenericFavoriteRepository : BaseRepository<IGenericFavorite, GenericFavorite>, IGenericFavoriteRepository
    {
        LogWriter writer = new LogWriter();

        public GenericFavoriteRepository( IRelationshipsDatabase database ) : base( database ) { }
        public GenericFavoriteRepository( IRelationshipsDatabaseFactory factory ) : base( factory ) { }

        private IQueryable<IGenericFavorite> GetAll()
        {
            return Database.GenericFavoriteDataSource;
        }

        public IGenericFavorite FindById( Guid id ) {
            return GetAll().SingleOrDefault( x => x.Id == id );
        }

        public override void Add(IGenericFavorite entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            if (GetAll().Any(art => art.Id == entity.Id))
            {
                writer.WriteLine("Generic Favorite with an id={0}".FormatWith(entity.Id));
                throw new AlreadyExistsException("Generic Favorite with an id={0}".FormatWith(entity.Id));
            }
            else
            {
                base.Add(entity);
            }
        }

        public override void Remove(IGenericFavorite entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            base.Remove(entity);
        }
    }
}
