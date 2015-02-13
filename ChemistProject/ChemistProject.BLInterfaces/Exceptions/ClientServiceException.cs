using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.BLInterfaces.Exceptions
{
    public class ClientServiceException : Exception
    {
        public ClientServiceException()
        {

        }

        public ClientServiceException(string message)
            : base(message)
        {

        }

        public ClientServiceException(Exception exception)
            : base("Some exception occured!", exception)
        {

        }
    }
}
