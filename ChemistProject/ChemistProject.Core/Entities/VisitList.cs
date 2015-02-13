using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.Core.Entities
{
    public class VisitList:MainEntity<int>
    {
        public string VisitDate { get; set; }
        public int OrderAmount { get; set; }
        public string OrderStatus { get; set; }
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
