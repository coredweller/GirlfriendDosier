using System;
using Core.DomainObjects;

namespace Core.Repository
{
    public interface IArtistRepository
    {
        IArtist FindById( Guid id );
        void Add(IArtist entity);
        void Remove( IArtist entity );
    }
}
