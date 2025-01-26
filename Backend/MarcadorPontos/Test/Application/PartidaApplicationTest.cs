using Application.Application;
using Domain.Entity;
using Moq;
using Service.Interface;

namespace Test.Application
{
    [TestFixture]
    public class PartidaApplicationTests
    {
        private Mock<IPartidaService> _serviceMock;
        private PartidaApplication _partidaApplication;

        [SetUp]
        public void SetUp()
        {
            _serviceMock = new Mock<IPartidaService>();
            _partidaApplication = new PartidaApplication(_serviceMock.Object);
        }

        [Test]
        public void GetResults_ShouldReturnNull_WhenNoPartidas()
        {
            _serviceMock.Setup(s => s.GetAll()).Returns((List<Partida>)null);

            var resultado = _partidaApplication.GetResults();

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void GetResults_ShouldReturnNull_WhenEmptyList()
        {
            _serviceMock.Setup(s => s.GetAll()).Returns(new List<Partida>());

            var resultado = _partidaApplication.GetResults();

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void GetResults_ShouldReturnValidResultadosDto_WhenPartidasExist()
        {
            var partidas = new List<Partida>
            {
                new Partida { DataPartidaConvertida = DateOnly.Parse("01/01/2025"), Pontuacao = 100, RecordeQuebrado = true },
                new Partida { DataPartidaConvertida = DateOnly.Parse("02/01/2025"), Pontuacao = 200, RecordeQuebrado = false },
                new Partida { DataPartidaConvertida = DateOnly.Parse("03/01/2025"), Pontuacao = 150, RecordeQuebrado = true }
            };

            _serviceMock.Setup(s => s.GetAll()).Returns(partidas);

            var resultado = _partidaApplication.GetResults();

            Assert.That(resultado, Is.Not.Null);
            Assert.That(DateOnly.Parse("01/01/2025"), Is.EqualTo(resultado.DataPrimeiroJogo));
            Assert.That(DateOnly.Parse("03/01/2025"), Is.EqualTo(resultado.DataUltimoJogo));
            Assert.That(100, Is.EqualTo(resultado.MenorPontuacao));
            Assert.That(200, Is.EqualTo(resultado.MaiorPontuacao));
            Assert.That(450, Is.EqualTo(resultado.TotalPontos));
            Assert.That(150, Is.EqualTo(resultado.MediaPontos));
            Assert.That(3, Is.EqualTo(resultado.QuantidadePartidas));
            Assert.That(2, Is.EqualTo(resultado.QuantidadeRecordesBatidos));
        }
    }
}
