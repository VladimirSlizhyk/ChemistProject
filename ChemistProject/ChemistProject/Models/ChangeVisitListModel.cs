using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemistProject.Models
{
    public class ChangeVisitListModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string VisitDate { get; set; }
        public int OrderAmount { get; set; }
        public string OrderStatus { get; set; }
    }
}