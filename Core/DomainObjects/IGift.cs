using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainObjects
{
    public interface IGift
    {
        Guid Id { get; set; }

        string Name { get; set; }
        string Description { get; set; }
        string Occasion { get; set; }
        string OccasionOther { get; set; }

        DateTime? DateBought { get; set; }
        DateTime? DateGiven { get; set; }

        decimal? Price { get; set; }
    }
}
