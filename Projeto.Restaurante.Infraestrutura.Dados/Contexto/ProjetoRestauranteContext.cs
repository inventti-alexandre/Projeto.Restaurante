using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Infraestrutura.Dados.ConfiguracaoDeEntidades;

namespace Projeto.Restaurante.Infraestrutura.Dados.Contexto
{
    public class ProjetoRestauranteContext : DbContext
    {
        public ProjetoRestauranteContext()
            : base("ProjetoRestaurante")
        {
            //Database.SetInitializer<ProjetoRestauranteContext>(new DropCreateDatabaseAlways<ProjetoRestauranteContext>());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Opcao> Opcoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties<DateTime>()
                .Configure(p => p.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new ConfiguracaoCategoria());
            modelBuilder.Configurations.Add(new ConfiguracaoItem());
            modelBuilder.Configurations.Add(new ConfiguracaoMesa());
            modelBuilder.Configurations.Add(new ConfiguracaoOpcao());
            modelBuilder.Configurations.Add(new ConfiguracaoPedido());
            modelBuilder.Configurations.Add(new ConfiguracaoPrato());

            base.OnModelCreating(modelBuilder);
        }

        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        ///             </exception>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("GlobalId") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("GlobalId").CurrentValue = Guid.NewGuid();
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("GlobalId").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataUltimaAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataUltimaAlteracao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataUltimaAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }

}

