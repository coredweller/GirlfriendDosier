using System;
using Core.DomainObjects;

namespace Core.Repository
{
    public interface IFlowersRepository
    {
        IFlowers FindById( Guid id );
        void Add(IFlowers entity);
        void Remove( IFlowers entity );
    }
}
