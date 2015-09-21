using System.Data.Entity.Migrations;
using Projeto.Restaurante.Infraestrutura.Dados.Contexto;

namespace Projeto.Restaurante.Infraestrutura.Dados.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoRestauranteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjetoRestauranteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
