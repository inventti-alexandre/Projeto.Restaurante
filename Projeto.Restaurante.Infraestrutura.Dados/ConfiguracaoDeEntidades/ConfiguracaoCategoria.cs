using System.Data.Entity.ModelConfiguration;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoCategoria : EntityTypeConfiguration<Categoria>
    {
        public ConfiguracaoCategoria()
        {
            ToTable("Categorias");

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

            HasMany(x => x.Pratos);
        }
    }
}
