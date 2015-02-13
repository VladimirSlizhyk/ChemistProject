using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.DALInterfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void PreSave();
        void Rollback();
    }
}
