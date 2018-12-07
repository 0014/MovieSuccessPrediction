namespace DataCleaner.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImdbContext : DbContext
    {
        public ImdbContext()
            : base("name=ImdbContext")
        {
        }

        public virtual DbSet<CleanData> CleanData { get; set; }
        public virtual DbSet<name_basics_clean> name_basics_clean { get; set; }
        public virtual DbSet<title_basics_clean> title_basics_clean { get; set; }
        public virtual DbSet<title_principals_clean> title_principals_clean { get; set; }
        public virtual DbSet<title_ratings_clean> title_ratings_clean { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
