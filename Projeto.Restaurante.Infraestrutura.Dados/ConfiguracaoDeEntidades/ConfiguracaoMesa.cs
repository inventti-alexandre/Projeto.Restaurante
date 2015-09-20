using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoMesa : EntityTypeConfiguration<Mesa>
    {
        public ConfiguracaoMesa()
        {
            ToTable("Mesas");

            HasKey(x => x.Id);

            Property(x => x.GlobalId)
                .IsRequired();

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
