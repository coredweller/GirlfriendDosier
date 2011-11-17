using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainObjects
{
    public interface IFavorites
    {
        Guid Id { get; set; }

        string Color { get; set; }
        string Flower { get; set; }
        string Movie { get; set; }
        string Band { get; set; }

        Guid RelationshipId { get; set; }
    }
}
