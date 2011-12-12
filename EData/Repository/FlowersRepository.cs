using System;
using System.Linq;
using Core.DomainObjects;
using EData;
using Core.Helpers;
using Core.Exceptions;
using Core.Repository;

namespace EData.Repository
{
    public class FlowersRepository : BaseRepository<IFlowers, Flowers>, IFlowersRepository
    {
        LogWriter writer = new LogWriter();

        public FlowersRepository( IRelationshipsDatabase database ) : base( database ) { }
        public FlowersRepository( IRelationshipsDatabaseFactory factory ) : base( factory ) { }

        private IQueryable<IFlowers> GetAll()
        {
            return Database.FlowersDataSource;
        }

        public IFlowers FindById( Guid id ) {
            return GetAll().SingleOrDefault( x => x.Id == id );
        }

        public override void Add(IFlowers entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            if (GetAll().Any(art => art.Id == entity.Id))
            {
                writer.WriteLine("Flowers with an id={0}".FormatWith(entity.Id));
                throw new AlreadyExistsException("Flowers with an id={0}".FormatWith(entity.Id));
            }
            else
            {
                base.Add(entity);
            }
        }

        public override void Remove(IFlowers entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            base.Remove(entity);
        }
    }
}
