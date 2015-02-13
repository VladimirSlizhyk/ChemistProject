using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core.Entities;

namespace ChemistProject.BLInterfaces.BLInterfaces
{
    public interface IClientService : IService
    {
        Client CreateClient(string firstName, string lastName, string dateOfBirth, string address, string phone,
            string email, int leftEye, int rightEye);
        Client GetClientByName(string firstName, string lastName);
        Client GetClientById(int clientId);
        void AddVisitListToClient(VisitList visitList, int clientId);
    }
}
