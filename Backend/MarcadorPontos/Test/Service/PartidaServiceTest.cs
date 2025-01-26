using Domain.Entity;
using Moq;
using Repository.Interface;
using Service.Service;

namespace Test.Service
{
    [TestFixture]
    public class PartidaServiceTest
    {
        private Mock<IPartidaRepository> _partidaRepositoryMock;
        private PartidaService _service;

        [SetUp]
        public void Setup()
        {
            _partidaRepositoryMock = new Mock<IPartidaRepository>();
            _service = new PartidaService(_partidaRepositoryMock.Object);
        }

        [Test]
        public void Add_ShouldSetRecordeQuebrado_WhenPontuacaoIsHigherThanLastRecord()
        {
            var partida = new Partida
            {
                Pontuacao = 100,
                DataPartida = "25/01/2025"
            };

            var ultimoRecorde = new Partida { Pontuacao = 90 };
            _partidaRepositoryMock.Setup(r => r.GetLastRecord()).Returns(ultimoRecorde);

            _service.Add(partida);

            Assert.That(partida.RecordeQuebrado, Is.True, "O campo RecordeQuebrado deve ser true quando a pontuação for maior que o último recorde.");

            _partidaRepositoryMock.Verify(r => r.Add(partida), Times.Once, "O método Add do repositório deve ser chamado.");
        }

        [Test]
        public void Add_ShouldNotSetRecordeQuebrado_WhenPontuacaoIsNotHigherThanLastRecord()
        {
            var partida = new Partida
            {
                Pontuacao = 80,
                DataPartida = "25/01/2025"
            };

            var ultimoRecorde = new Partida { Pontuacao = 90 };
            _partidaRepositoryMock.Setup(r => r.GetLastRecord()).Returns(ultimoRecorde);

            _service.Add(partida);

            Assert.That(partida.RecordeQuebrado, Is.False, "O campo RecordeQuebrado deve ser false quando a pontuação não for maior que o último recorde.");

            _partidaRepositoryMock.Verify(r => r.Add(partida), Times.Once, "O método Add do repositório deve ser chamado.");
        }

        [Test]
        public void Add_ShouldConvertDataPartida()
        {
            var partida = new Partida
            {
                Pontuacao = 100,
                DataPartida = "25/01/2025"
            };

            _partidaRepositoryMock.Setup(r => r.GetLastRecord()).Returns((Partida)null);

            _service.Add(partida);

            Assert.That(DateOnly.Parse("25/01/2025"), Is.EqualTo(partida.DataPartidaConvertida), "O campo DataPartidaConvertida deve ser corretamente convertido.");

            _partidaRepositoryMock.Verify(r => r.Add(partida), Times.Once, "O método Add do repositório deve ser chamado.");
        }
    }
}
