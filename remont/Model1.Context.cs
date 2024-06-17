using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace remont
{
    public partial class remontEntities : DbContext
    {
        public remontEntities() : base("name=remontEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<Executor> Executor { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
