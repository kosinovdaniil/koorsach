namespace Epam.Wunderlist.DataAccess.MssqlProvider.Migrations
{
    using DomainModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using CryptSharp;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
           
        }
    }
}
