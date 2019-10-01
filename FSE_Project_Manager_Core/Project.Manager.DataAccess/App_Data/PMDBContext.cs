using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.DataAccess.App_Data
{
    public class PMDBContext : DbContext
    {
        public PMDBContext() : base("name=PMConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PMDBContext, Project.Manager.DataAccess.Migrations.Configuration>("PMConnectionString"));
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectsTask> ProjectsTask { get; set; }
    }
}
