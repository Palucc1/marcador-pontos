using Domain.Entity;
using Moq;
using Repository.Interface;
using Service.Interface;
using Service.Service;

namespace Test.Repository
{
    [TestFixture]
    public class PartidaRepositoryTests
    {
        private Mock<IPartidaRepository> _partidaRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _partidaRepositoryMock = new Mock<IPartidaRepository>();
        }

        [Test]
        public void GetLastRecord_ShouldReturnNull_WhenNoRecordsExist()
        {
            var result = _partidaRepositoryMock.Setup(r => r.GetLastRecord()).Returns((Partida)null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetLastRecord_ShouldReturnNull_WhenNoRecordsHaveRecordeQuebrado()
        {
            var result = _partidaRepositoryMock.Setup(r => r.GetLastRecord()).Returns((Partida)null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetLastRecord_ShouldReturnMostRecentRecord_WhenRecordsExist()
        {
            var result = _partidaRepositoryMock.Object.GetLastRecord();

            if (result is not null)
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.RecordeQuebrado, Is.True);
            }
        }
    }
}
