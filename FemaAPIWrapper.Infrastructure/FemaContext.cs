using FemaAPIWrapper.FemaInfo;
using FemaAPIWrapper.Infrastructure.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemaAPIWrapper.Infrastructure
{
    public class FemaContext : DbContext
    {
        public FemaContext() : base("name=FemaDB")
        {
            Database.SetInitializer<FemaContext>(null);
            FemaContextMap contextMap = new FemaContextMap();
        }

        public virtual DbSet<DisasterDeclarationsSummaries> DisasterDeclarationSummaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Fema");
            modelBuilder.Configurations.Add(new FemaContextMap());
        }
    }
}
