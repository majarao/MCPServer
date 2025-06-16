using MCPServer.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCPServer.API.Configurations;

public class PessoConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder
            .ToTable("Pessoas");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Resumo)
            .HasMaxLength(300)
            .IsRequired();

        builder
            .Property(x => x.Biografia)
            .HasMaxLength(1000)
            .IsRequired();

        builder
            .Property(x => x.DataNascimento)
            .IsRequired();
    }
}
