namespace VSTDA_Backend.API.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VSTDA_Backend.API.Infrastructure.TodoDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VSTDA_Backend.API.Infrastructure.TodoDataContext context)
        {
            context.Todos.AddOrUpdate(t => t.Name,
                new Todo { TodoId = 1, Name = "High Priority", Priority = "3" },
                new Todo { TodoId = 2, Name = "Mid Priority", Priority = "2" },
                new Todo { TodoId = 3, Name = "Low Priority", Priority = "1" }
                );
            
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
