using System;
using Core.DomainObjects;

namespace Core.Repository
{
    public interface IRelationshipRepository
    {
        IRelationship FindById( Guid id );
        void Add(IRelationship entity);
        void Remove( IRelationship entity );
    }
}