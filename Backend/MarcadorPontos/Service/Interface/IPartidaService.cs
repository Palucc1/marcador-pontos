using Domain.Entity;

namespace Service.Interface
{
    public interface IPartidaService
    {
        void Add(Partida partida);
        IList<Partida> GetAll();
    }
}
