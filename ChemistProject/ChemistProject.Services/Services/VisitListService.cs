using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.BLInterfaces.BLInterfaces;
using ChemistProject.BLInterfaces.Exceptions;
using ChemistProject.Core.Entities;
using ChemistProject.DALInterfaces;

namespace ChemistProject.Services.Services
{
    public class VisitListService : MainService, IVisitListService
    {
        public VisitListService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public VisitList CreateVisitList(string visitDate, int orderAmount, string orderStatus, Client client)
        {
            var visitListRepository = RepositoryFactory.GetVisitListRepository();
            var visitList = new VisitList { VisitDate = visitDate, OrderAmount = orderAmount, OrderStatus = orderStatus};
            
            visitListRepository.Create(visitList);
            SetClientToVisitList(client, visitList);


            try
            {
                UnitOfWork.PreSave();
            }
            catch (VisitListServiceException exception)
            {

                throw new VisitListServiceException(exception);
            }

            return visitList;
        }

        public void UpdateVisitList(VisitList visitList)
        {
            var visitListRepository = RepositoryFactory.GetVisitListRepository();

            try
            {
                visitListRepository.Update(visitList);
            }
            catch (VisitListServiceException exception)
            {
                throw new VisitListServiceException(exception);
            }
        }

        public void RemoveVisitList(VisitList visitList)
        {
            var visitListRepository = RepositoryFactory.GetVisitListRepository();

            try
            {
                visitListRepository.Remove(visitList);
            }
            catch (VisitListServiceException exception)
            {
                throw new VisitListServiceException(exception);
            }
        }

        public VisitList GetVisitListById(int visitListId)
        {
            var visitListRepository = RepositoryFactory.GetVisitListRepository();

            try
            {
                var visitList = visitListRepository.GetEntityById(visitListId);
                return visitList;
            }
            catch (VisitListServiceException exception)
            {
                throw new VisitListServiceException(exception);
            }
        }

        public void SetClientToVisitList(Client client, VisitList visitList)
        {
            visitList.Client = client;
            visitList.ClientId = client.Id;
        }
    }
}
