using Moq;
using Core.Repository;
using EData.Repository;
using Core.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EData.Tests
{
    [TestClass]
    public class ArtistRepositoryTests
    {
        [TestMethod]
        public void FindByIdTest() {
            var repoMock = new Mock<IRelationshipsDatabase>();
            var artistRepo = Ioc.GetInstance<IArtistRepository>();

            repoMock.Setup( x => x.ArtistDataSource ).Returns(TestCollections.GetArtists());

            var artist = artistRepo.FindById( TestCollections.ArtistOneGuid );

            //repoMock.VerifySet( y => y.ArtistDataSource.Where( z => z.Id == TestCollections.ArtistOneGuid ) );

            Assert.AreEqual( artist.Id, TestCollections.ArtistOneGuid );
        }
    }
}
