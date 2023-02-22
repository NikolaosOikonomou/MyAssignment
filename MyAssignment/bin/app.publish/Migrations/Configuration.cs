namespace MyAssignment.Migrations
{
    using MyAssignment.Models;
    using MyAssignment.Models.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyAssignment.MyContext.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyAssignment.MyContext.ApplicationContext context)
        {
            
        }
    }
}
