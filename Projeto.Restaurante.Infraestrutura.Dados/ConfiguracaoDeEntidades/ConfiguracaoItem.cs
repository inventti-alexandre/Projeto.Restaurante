using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoItem : EntityTypeConfiguration<Item>
    {
        public ConfiguracaoItem()
        {
            ToTable("Itens");

            HasKey(x => x.Id);

            Property(x => x.GlobalId)
                 .IsRequired();

            HasRequired(x => x.Pedido);

            HasRequired(x => x.Prato);

            HasMany(x => x.Opcoes);
        }
    }
}
