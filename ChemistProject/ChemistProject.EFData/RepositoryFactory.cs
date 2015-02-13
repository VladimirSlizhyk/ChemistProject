using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core.Entities;
using ChemistProject.DALInterfaces;
using ChemistProject.EFData.Mapping;

namespace ChemistProject.EFData
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ChemistContext _context;
        private IRepositoryGeneric<Client, int> _clientRepository;
        private IRepositoryGeneric<VisitList, int> _visitListRepository;

        public RepositoryFactory(ChemistContext context)
        {
            _context = context;
        }

        public IRepositoryGeneric<Client, int> GetClientRepository()
        {
            return _clientRepository ?? (_clientRepository = new RepositoryGeneric<Client, int>(_context));
        }

        public IRepositoryGeneric<VisitList, int> GetVisitListRepository()
        {
            return _visitListRepository ?? (_visitListRepository = new RepositoryGeneric<VisitList, int>(_context));
        }
    }
}
