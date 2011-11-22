using System;
using Core.DomainObjects;

namespace Core.Repository
{
    public interface IGiftRepository
    {
        IGift FindById( Guid id );
        void Add(IGift entity);
        void Remove( IGift entity );
    }
}
