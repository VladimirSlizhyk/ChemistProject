using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.BLInterfaces.Exceptions
{
    public class VisitListServiceException : Exception
    {
        public VisitListServiceException()
        {

        }

        public VisitListServiceException(string message)
            : base(message)
        {

        }

        public VisitListServiceException(Exception exception)
            : base("Some exception occured!", exception)
        {

        }
    }
}
