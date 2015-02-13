using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core.Entities;

namespace ChemistProject.BLInterfaces.BLInterfaces
{
    public interface IVisitListService : IService
    {
        VisitList CreateVisitList(string visitDate, int orderAmount, string orderStatus, Client client);
        void UpdateVisitList(VisitList visitList);
        void RemoveVisitList(VisitList visitList);
        VisitList GetVisitListById(int visitListId);
        void SetClientToVisitList(Client client, VisitList visitList);
    }
}
