using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core.Entities;

namespace ChemistProject.DALInterfaces
{
    public interface IRepositoryFactory
    {
        IRepositoryGeneric<Client, int> GetClientRepository();
        IRepositoryGeneric<VisitList, int> GetVisitListRepository();
    }
}
