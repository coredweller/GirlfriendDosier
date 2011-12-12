using System;
using System.Linq;
using Core.DomainObjects;
using EData;
using Core.Helpers;
using Core.Exceptions;
using Core.Repository;

namespace EData.Repository
{
    public class ArtistRepository : BaseRepository<IArtist, Artist>, IArtistRepository
    {
        LogWriter writer = new LogWriter();

        public ArtistRepository( IRelationshipsDatabase database ) : base( database ) { }
        public ArtistRepository( IRelationshipsDatabaseFactory factory ) : base( factory ) { }

        private IQueryable<IArtist> GetAll()
        {
            return Database.ArtistDataSource;
        }

        public IArtist FindById( Guid id ) {
            return GetAll().SingleOrDefault( x => x.Id == id );
        }

        public override void Add(IArtist entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            if (GetAll().Any(art => art.Id == entity.Id))
            {
                writer.WriteLine("Artist with an id={0}".FormatWith(entity.Id));
                throw new AlreadyExistsException("Artist with an id={0}".FormatWith(entity.Id));
            }
            else
            {
                base.Add(entity);
            }
        }

        public override void Remove(IArtist entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");

            base.Remove(entity);
        }
    }
}
