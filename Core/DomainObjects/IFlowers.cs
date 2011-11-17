using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainObjects
{
    public interface IFlowers
    {
        Guid Id { get; set; }

        string ArrangementName { get; set; }
        string Vendor { get; set; }
        string Notes { get; set; }

        decimal? Price { get; set; }

        bool Delivered { get; set; }

        DateTime? DateBought { get; set; }
        DateTime? DateReceived  { get; set; }

        Guid RelationshipId { get; set; }
    }
}
