using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core.Entities;

namespace ChemistProject.EFData.Mapping
{
    public class VisitListMap:EntityTypeConfiguration<VisitList>
    {
        public VisitListMap()
        {
            HasKey(h => h.Id);
            Property(h => h.VisitDate).IsRequired().HasMaxLength(10);
            Property(h => h.OrderAmount).IsRequired();
            Property(h => h.OrderStatus).IsRequired();
        }
    }
}
