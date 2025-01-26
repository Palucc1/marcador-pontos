using Application.Interface;
using Domain.DTO;
using Domain.Entity;
using Service.Interface;

namespace Application.Application
{
    public class PartidaApplication : IPartidaApplication
    {
        private readonly IPartidaService _service;
        public PartidaApplication(IPartidaService service) => _service = service;

        public void Add(Partida partida) => _service.Add(partida);

        public ResultadosDto GetResults()
        {
            var resultado = new ResultadosDto();

            var partidas = _service.GetAll();

            if (partidas is not null && partidas.Count > 0)
            {
                resultado = new ResultadosDto
                {
                    DataPrimeiroJogo = partidas.OrderBy(x => x.DataPartidaConvertida).First().DataPartidaConvertida,
                    DataUltimoJogo = partidas.OrderByDescending(x => x.DataPartidaConvertida).First().DataPartidaConvertida,
                    MenorPontuacao = partidas.OrderBy(x => x.Pontuacao).First().Pontuacao,
                    MaiorPontuacao = partidas.OrderByDescending(x => x.Pontuacao).First().Pontuacao,
                    TotalPontos = partidas.Sum(p => p.Pontuacao),
                    MediaPontos = partidas.Average(p => p.Pontuacao),
                    QuantidadePartidas = partidas.Count(),
                    QuantidadeRecordesBatidos = partidas.Where(x => x.RecordeQuebrado == true).Count()
                };
            }
            else
                resultado = null;

            return resultado;
        }
    }
}
