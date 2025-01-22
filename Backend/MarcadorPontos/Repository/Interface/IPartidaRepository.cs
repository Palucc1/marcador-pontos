using Domain.Entity;

namespace Repository.Interface
{
    public interface IPartidaRepository
    {
        void Add(Partida obj);
        IList<Partida> GetAll();
        Partida GetLastRecord();
    }
}
