using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoCategoria : EntityTypeConfiguration<Categoria>
    {
        public ConfiguracaoCategoria()
        {
            ToTable("Categorias");

            HasKey(x => x.Id);

            Property(x => x.GlobalId)
                .IsRequired();

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(x => x.Pratos);
        }
    }
}
