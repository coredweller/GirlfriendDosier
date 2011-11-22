using System;
using Core.DomainObjects;

namespace Core.Repository
{
    public interface IFavoritesRepository
    {
        IFavorites FindById( Guid id );
        void Add(IFavorites entity);
        void Remove( IFavorites entity );
    }
}
