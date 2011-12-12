using System;
using System.Linq;
using Core.DomainObjects;
using EData;
using Core.Exceptions;
using Core.Helpers;
using Core.Repository;

namespace EData.Repository
{
    public class GiftRepository : BaseRepository<IGift, Gift>, IGiftRepository
    {
        LogWriter writer = new LogWriter();

        public GiftRepository( IRelationshipsDatabase database ) : base( database ) { }
        public GiftRepository( IRelationshipsDatabaseFactory factory ) : base( factory ) { }

        private IQueryable<IGift> GetAll()
        {
            return Database.GiftDataSource;
        }

        public IGift FindById( Guid id ) {
            return GetAll().SingleOrDefault( x => x.Id == id );
        }

        public override void Add(IGift entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            if (GetAll().Any(art => art.Id == entity.Id))
            {
                writer.WriteLine("Gift with an id={0}".FormatWith(entity.Id));
                throw new AlreadyExistsException("Gift with an id={0}".FormatWith(entity.Id));
            }
            else
            {
                base.Add(entity);
            }
        }

        public override void Remove(IGift entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            base.Remove(entity);
        }
    }
}
