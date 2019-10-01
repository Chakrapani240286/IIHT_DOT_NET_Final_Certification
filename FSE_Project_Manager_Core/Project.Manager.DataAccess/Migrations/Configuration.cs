namespace Project.Manager.DataAccess.Migrations
{
    using Project.Manager.DataAccess.Helper;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project.Manager.DataAccess.App_Data.PMDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Project.Manager.DataAccess.App_Data.PMDBContext context)
        {
            context.User.AddOrUpdate(m => m.EmailId,
                new Entities.User()
                {
                    FirstName = "fse",
                    LastName = "admin",
                    EmailId = "admin@fse.com",
                    Password = PasswordProtect.Encrypt("admin"),
                    DateCreated = DateTime.Now,
                    Status = "Active"
                });

            context.Projects.AddOrUpdate(m => m.Title,
                new Entities.Projects()
                {
                    Title = "Test Project FSE",
                    Description = "Test Project FSE Description are goes here",
                    Priority = "1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1000),
                    UserId = 1,
                    ManagerId = 1,
                    DateCreated=DateTime.Now
                });
        }
    }
}
