using System;
using System.Linq;
using Core.DomainObjects;
using Data.DomainObjects;
using Core.Helpers;
using Core.Exceptions;
using Core.Repository;

namespace Data.Repository
{
    public class RestaurantRepository : BaseRepository<IRestaurant, Restaurant>, IRestaurantRepository
    {
        LogWriter writer = new LogWriter();

        public RestaurantRepository( IRelationshipsDatabase database ) : base( database ) { }
        public RestaurantRepository( IRelationshipsDatabaseFactory factory ) : base( factory ) { }

        private IQueryable<IRestaurant> GetAll()
        {
            return Database.RestaurantDataSource;
        }

        public IRestaurant FindById( Guid id ) {
            return GetAll().SingleOrDefault( x => x.Id == id );
        }

        public override void Add(IRestaurant entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            if (GetAll().Any(art => art.Id == entity.Id))
            {
                writer.WriteLine("Relationship with an id={0}".FormatWith(entity.Id));
                throw new AlreadyExistsException("Relationship with an id={0}".FormatWith(entity.Id));
            }
            else
            {
                base.Add(entity);
            }
        }

        public override void Remove(IRestaurant entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            base.Remove(entity);
        }
    }
}
