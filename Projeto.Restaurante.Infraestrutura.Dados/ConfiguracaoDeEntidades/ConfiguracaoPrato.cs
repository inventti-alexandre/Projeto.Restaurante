using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoPrato : EntityTypeConfiguration<Prato>
    {
        public ConfiguracaoPrato()
        {
            ToTable("Pratos");

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

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Preco)
                .IsRequired()
                .HasPrecision(6, 2);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(256);

            Property(x => x.Disponivel)
                .IsRequired();

            HasRequired(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CategoriaId);

        }
    }
}
