using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core.Entities;

namespace ChemistProject.EFData.Mapping
{
    public class ClientMap:EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            HasKey(h => h.Id);
            Property(h => h.FirstName).IsRequired().HasMaxLength(100);
            Property(h => h.LastName).IsRequired().HasMaxLength(100);
            Property(h => h.DateOfBirth).IsRequired().HasMaxLength(10);
            Property(h => h.Address).IsRequired().HasMaxLength(100);
            Property(h => h.Phone).IsRequired().HasMaxLength(15);
            Property(h => h.Email).IsRequired().HasMaxLength(100);
            Property(h => h.LeftEye).IsRequired();
            Property(h => h.RightEye).IsRequired();
            HasMany(h => h.VisitLists).WithRequired(h => h.Client).HasForeignKey(h => h.ClientId);
        }
    }
}
