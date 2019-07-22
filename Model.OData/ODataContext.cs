using System;
using Microsoft.EntityFrameworkCore;
using Model.OData.Configurations;

namespace Model.OData
{
    public class ODataContext : DbContext
    {
        public ODataContext(DbContextOptions<ODataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherStudentsConfiguration());
        }

        public void MigrateDatabase(int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!Database.IsInMemory())
                {
                    Database.Migrate();
                }
            }
            catch
            {
                if (retryForAvailability < 3)
                {
                    MigrateDatabase(++retryForAvailability);
                }
                else { throw; }
            }
        }
    }
}
