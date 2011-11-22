using System;

namespace Core.DomainObjects
{
    public interface IGenericFavorite
    {
        Guid Id { get; set; }

        string Name { get; set; }
        string Value { get; set; }

        Guid RelationshipId { get; set; }
    }
}
