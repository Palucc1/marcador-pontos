using Domain.DTO;
using Domain.Entity;

namespace Application.Interface
{
    public interface IPartidaApplication
    {
        void Add(Partida partida);
        ResultadosDto GetResults();
    }
}
