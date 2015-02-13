using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core.Entities;
using ChemistProject.EFData.Mapping;

namespace ChemistProject.EFData
{
    public class ChemistContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<VisitList> VisitLists { get; set; }

        public ChemistContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new VisitListMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
