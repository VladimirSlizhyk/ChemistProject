using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.Core.Entities
{
    public class Client : MainEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int LeftEye { get; set; }
        public int RightEye { get; set; }
        public virtual List<VisitList> VisitLists { get; set; }
    }
}
