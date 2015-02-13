using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.BLInterfaces.BLInterfaces;
using ChemistProject.DALInterfaces;

namespace ChemistProject.Services.Services
{
    public abstract class MainService : IService
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected IRepositoryFactory RepositoryFactory { get; set; }

        protected MainService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
        {
            UnitOfWork = unitOfWork;
            RepositoryFactory = repositoryFactory;
        }
    }
}
