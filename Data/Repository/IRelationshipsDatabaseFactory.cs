using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public interface IRelationshipsDatabaseFactory
    {
        IRelationshipsDatabase Get();
    }
}
