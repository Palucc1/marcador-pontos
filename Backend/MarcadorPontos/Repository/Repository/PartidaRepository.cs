using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;

namespace Repository.Repository
{
    public class PartidaRepository : IPartidaRepository
    {
        private readonly DbContextOptions<DataContext> _options;
        public PartidaRepository(DbContextOptions<DataContext> options) => _options = options;

        public void Add(Partida partida)
        {
            using (var ctx = new DataContext(_options))
            {
                ctx.Set<Partida>().Add(partida);
                ctx.SaveChanges();
            }
        }

        public virtual IList<Partida> GetAll()
        {
            using (var ctx = new DataContext(_options))
            {
                return ctx.Set<Partida>().ToList();
            }
        }

        public Partida GetLastRecord()
        {
            using (var ctx = new DataContext(_options))
            {
                var partidas = ctx.Set<Partida>().OrderByDescending(x => x.DataPartida);
                
                return partidas.First(x => x.RecordeQuebrado);
            }
        }
    }
}
