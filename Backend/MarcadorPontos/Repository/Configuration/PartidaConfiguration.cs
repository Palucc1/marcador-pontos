using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PartidaConfiguration : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.ToTable("Partidas");

            builder.HasKey("Id");

            builder.Property(p => p.DataPartida)
                   .IsRequired();

            builder.Property(p => p.Pontuacao)
                   .IsRequired();
        }
    }
}
