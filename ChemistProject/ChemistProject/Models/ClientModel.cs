using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChemistProject.Core.Entities;

namespace ChemistProject.Models
{
    public class ClientModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int LeftEye { get; set; }
        public int RightEye { get; set; }
        public  List<VisitList> VisitLists { get; set; }
        public int Id { get; set; }
    }
}