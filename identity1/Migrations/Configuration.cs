namespace identity1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<identity1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "identity1.Models.ApplicationDbContext";
        }

        protected override void Seed(identity1.Models.ApplicationDbContext context)
        {
            
        }
    }
}
