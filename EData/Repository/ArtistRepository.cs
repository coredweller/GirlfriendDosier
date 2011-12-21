using System;
using System.Linq;
using Core.DomainObjects;
using EData;
using Core.Helpers;
using Core.Exceptions;
using Core.Repository;
using System.Collections.Generic;

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
            return GetAll().OfType<Artist>().SingleOrDefault( x => x.Id == id );
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

    //internal static class ArtistFilter
    //{
    //    public static IList<IArtist> Cast( this IQueryable<Artist> query ) {
    //        return query
    //            .Cast<IArtist>()
    //            .ToList();
    //    }

    //    public static IQueryable<Artist> FilterById( this IQueryable<Artist> query, Guid id ) {
    //        return query.Where( x => x.Id == id );
    //    }
    //}
}
