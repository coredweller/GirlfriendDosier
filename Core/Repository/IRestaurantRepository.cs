using System;
using Core.DomainObjects;

namespace Core.Repository
{
    public interface IRestaurantRepository
    {
        IRestaurant FindById( Guid id );
        void Add(IRestaurant entity);
        void Remove( IRestaurant entity );
    }
}
