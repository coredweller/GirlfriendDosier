using System;
using System.Linq;
using Core.Helpers;
using Core.DomainObjects;
using Core.Exceptions;
using Data.DomainObjects;
using Core.Repository;

namespace Data.Repository
{
    public class RelationshipRepository : BaseRepository<IRelationship, Relationship>, IRelationshipRepository
    {
        LogWriter writer = new LogWriter();

        public RelationshipRepository( IRelationshipsDatabase database ) : base( database ) { }
        public RelationshipRepository( IRelationshipsDatabaseFactory factory ) : base( factory ) { }

        private IQueryable<IRelationship> GetAll()
        {
            return Database.RelationshipDataSource.Where(x => x.Deleted == false);
        }

        public IRelationship FindById( Guid id ) {
            return GetAll().SingleOrDefault( x => x.Id == id );
        }

        public override void Add(IRelationship entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            entity.CreatedDate = DateTime.Now;

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

        public override void Remove(IRelationship entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            base.Remove(entity);
        }
    }
}
