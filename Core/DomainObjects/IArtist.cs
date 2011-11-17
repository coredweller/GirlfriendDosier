using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainObjects
{
    public interface IArtist
    {
        Guid Id { get; set; }

        string Name { get; set; }
        string Notes { get; set; }

        int AttendedCount { get; set; }

        Guid RelationshipId { get; set; }
    }
}
