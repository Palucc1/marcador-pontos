using Domain.DTO;
using Domain.Entity;
using Repository.Interface;
using Service.Interface;

namespace Service.Service
{
    public class PartidaService : IPartidaService
    {
        private readonly IPartidaRepository _repository;
        public PartidaService(IPartidaRepository repository)  => _repository = repository;

        public void Add(Partida partida)
        {
            var ultimoRecorde = _repository.GetLastRecord();

            if (ultimoRecorde is not null && ultimoRecorde.Pontuacao < partida.Pontuacao)
                partida.RecordeQuebrado = true;

            _repository.Add(partida);
        }

        public IList<Partida> GetAll() => _repository.GetAll();
    }
}
