using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoPedido : EntityTypeConfiguration<Pedido>
    {
        public ConfiguracaoPedido()
        {
            ToTable("Pedidos");

            #region Base
            HasKey(x => x.Id);

            Property(x => x.GlobalId)
                .IsRequired();

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataUltimaAlteracao)
                .IsOptional();

            Property(x => x.Ativo)
                .IsRequired();
            #endregion

            HasRequired(x => x.Mesa)
                .WithMany()
                .HasForeignKey(x => x.MesaId);

            HasMany(x => x.Itens);
        }
    }
}
