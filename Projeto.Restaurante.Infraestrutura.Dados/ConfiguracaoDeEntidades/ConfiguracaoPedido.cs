using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoPedido : EntityTypeConfiguration<Pedido>
    {
        public ConfiguracaoPedido()
        {
            ToTable("Pedidos");

            HasKey(x => x.Id);

            Property(x => x.GlobalId)
                 .IsRequired();

            HasRequired(x => x.Mesa);

            HasMany(x => x.Itens);
        }
    }
}
