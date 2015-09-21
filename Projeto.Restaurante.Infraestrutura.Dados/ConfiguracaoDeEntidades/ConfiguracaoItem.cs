using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoItem : EntityTypeConfiguration<Item>
    {
        public ConfiguracaoItem()
        {
            ToTable("Itens");

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

            HasRequired(x => x.Pedido)
                .WithMany()
                .HasForeignKey(x => x.PedidoId);

            HasRequired(x => x.Prato)
                .WithMany()
                .HasForeignKey(x => x.PratoId);

            HasMany(x => x.Opcoes);
        }
    }
}
