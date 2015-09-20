using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoPrato : EntityTypeConfiguration<Prato>
    {
        public ConfiguracaoPrato()
        {
            ToTable("Pratos");

            HasKey(x => x.Id);

            Property(x => x.GlobalId)
                .IsRequired();

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Preco)
                .IsRequired()
                .HasPrecision(6, 2);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(256);

            HasMany(x => x.Categorias)
                .WithMany(x => x.Pratos)
                .Map(x => x.ToTable("PratosCategorias"));
        }
    }
}
