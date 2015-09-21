using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ConfiguracaoCategoria());
            modelBuilder.Configurations.Add(new ConfiguracaoItem());
            modelBuilder.Configurations.Add(new ConfiguracaoMesa());
            modelBuilder.Configurations.Add(new ConfiguracaoOpcao());
            modelBuilder.Configurations.Add(new ConfiguracaoPedido());
            modelBuilder.Configurations.Add(new ConfiguracaoPrato());

            base.OnModelCreating(modelBuilder);
        }

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

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Ativo") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Ativo").CurrentValue = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Ativo").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

    }

}

