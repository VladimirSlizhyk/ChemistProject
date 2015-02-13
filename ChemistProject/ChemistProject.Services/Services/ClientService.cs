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
    public class ClientService : MainService, IClientService
    {
        public ClientService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Client CreateClient(string firstName, string lastName, string dateOfBirth, string address, string phone, string email,
            int leftEye, int rightEye)
        {
            var clientRepository = RepositoryFactory.GetClientRepository();
            var client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Address = address,
                Phone = phone,
                Email = email,
                LeftEye = leftEye,
                RightEye = rightEye
            };
            clientRepository.Create(client);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (ClientServiceException exception)
            {
                throw new ClientServiceException(exception);
            }

            return client;
        }

        public Client GetClientByName(string firstName, string lastName)
        {
            var clientRepository = RepositoryFactory.GetClientRepository();

            try
            {
                var client = clientRepository.FindEntity(h => h.FirstName == firstName && h.LastName == lastName);
                return client;
            }
            catch (ClientServiceException exception)
            {
                throw new ClientServiceException(exception);
            }
        }

        public Client GetClientById(int clientId)
        {
            var clientRepository = RepositoryFactory.GetClientRepository();

            try
            {
                var client = clientRepository.GetEntityById(clientId);
                return client;
            }
            catch (ClientServiceException exception)
            {
                throw new ClientServiceException(exception);
            }
        }

        public void AddVisitListToClient(VisitList visitList, int clientId)
        {
            var client = GetClientById(clientId);
            client.VisitLists.Add(visitList);
        }
    }
}
