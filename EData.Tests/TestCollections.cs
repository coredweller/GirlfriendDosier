using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainObjects;

namespace EData.Tests
{
    public static class TestCollections
    {
        public static Guid ArtistOneGuid = new Guid( "4621BA2D-1A78-45DD-BCA6-298C8D00E7C3" );
        public static Guid ArtistTwoGuid = new Guid( "E6C5EB35-6DC7-49A5-B9BF-62DF1319DF2C" );
        public static IQueryable<IArtist> GetArtists() {
            return new List<IArtist> {
                new Artist { Id = ArtistOneGuid, Name = "Phish", AttendedCount = 46 },
                new Artist { Id = ArtistTwoGuid, Name = "Wu-Tang", AttendedCount = 5 }
            }.AsQueryable();
        }
    }
}
