using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Core.Configuration;
using Core.Helpers;
using Core.DomainObjects;
using Data.DomainObjects;

namespace Data.Repository
{
    public class DomainObjectFactory
    {
         private static readonly ILog log = LogManager.GetLogger( typeof( DomainObjectFactory ) );

        private readonly IConfigurationSettings _settings;

        public DomainObjectFactory( IConfigurationSettings settings ) {
            Checks.Argument.IsNotNull( settings, "settings" );
            _settings = settings;
        }

        public IArtist CreateArtist(string name, string notes, Guid relationshipId, int attendedCount = 0) {
            return new Artist {
                Id = Guid.NewGuid(),
                Name = name,
                AttendedCount = attendedCount,
                Notes = notes,
                RelationshipId = relationshipId
            };
        }
    }
}
