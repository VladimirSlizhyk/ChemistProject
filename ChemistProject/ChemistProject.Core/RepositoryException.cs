using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.Core
{
    public class RepositoryException : Exception
    {
        public RepositoryException()
        {

        }

        public RepositoryException(string message)
            : base(message)
        {

        }

        public RepositoryException(Exception exception)
            : base("Some exception occured!", exception)
        {

        }
    }
}
