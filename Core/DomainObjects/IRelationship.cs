using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainObjects
{
    public interface IRelationship
    {
        Guid Id { get; set; }

        string Name { get; set; }
        string NickName { get; set; }
        
        bool Married { get; set; }
        bool MarriedToYou { get; set; }

        DateTime? WeddingAnniversary { get; set; }
        DateTime? Birthday { get; set; }
        DateTime? Anniversary { get; set; } 
        DateTime? FirstDate { get; set; }
        DateTime? FirstKiss { get; set; }
        DateTime? MeetingDate { get; set; }
        
        DateTime CreatedDate { get; set; }

        bool Deleted { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
