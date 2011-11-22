using System;
using Core.DomainObjects;

namespace Core.Repository
{
    public interface IGenericFavoriteRepository
    {
        IGenericFavorite FindById( Guid id );
        void Add(IGenericFavorite entity);
        void Remove( IGenericFavorite entity );
    }
}
