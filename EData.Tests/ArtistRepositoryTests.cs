using Moq;
using Core.Repository;
using EData.Repository;
using Core.Infrastructure;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EData.Tests
{
    [TestClass]
    public class ArtistRepositoryTests
    {
        public ArtistRepositoryTests() {
            Bootstrapper.Bootstrap();
            Bootstrapper.CheckConfiguration();
        }

        [TestMethod]
        public void FindByIdTest() {
            var repoMock = new Mock<IRelationshipsDatabase>();
            var artistRepo = Ioc.GetInstance<IArtistRepository>();
            var relationshipRepo = Ioc.GetInstance<IRelationshipRepository>();

            using ( IUnitOfWork uow = Core.Infrastructure.UnitOfWork.Begin() ) {
                relationshipRepo.Add( TestCollections.GetRelationship() );
                artistRepo.Add( TestCollections.GetArtists().First() );

                uow.Commit();
            }

            //repoMock.Setup( x => x.ArtistDataSource ).Returns(TestCollections.GetArtists());

            //var artist = artistRepo.FindById( TestCollections.ArtistOneGuid );

            ////repoMock.VerifySet( y => y.ArtistDataSource.Where( z => z.Id == TestCollections.ArtistOneGuid ) );
            //Assert.IsNotNull( artist );
            //Assert.AreEqual( artist.Id, TestCollections.ArtistOneGuid );
        }
    }
}
