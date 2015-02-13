using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ChemistProject.EFData;
using ChemistProject.Models;
using ChemistProject.Services.Services;

namespace ChemistProject.Controllers
{
    public class ChemistController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchModel searchModel)
        {
            var context = new ChemistContext(Resources.ConnectionString);
            var unit = new UnitOfWorks(context);
            var repositoryFactory = new RepositoryFactory(context);
            var clientService = new ClientService(unit, repositoryFactory);
            var client = clientService.GetClientByName(searchModel.FirstName, searchModel.LastName);
            if (client != null)
            {
                return RedirectToAction("ClientView", "Chemist", new { clientId = client.Id });
            }
            else
            {
                return RedirectToAction("AddClient", "Chemist");
            }
        }

        [HttpGet]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClient(SearchModel searchModel)
        {
            return RedirectToAction("CreateClient", "Chemist");
        }

        [HttpGet]
        public ActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClient(ClientModel clientModel)
        {
            var context = new ChemistContext(Resources.ConnectionString);
            var unitOfWork = new UnitOfWorks(context);
            var repositoryFactory = new RepositoryFactory(context);
            var clientService = new ClientService(unitOfWork, repositoryFactory);
            var client = clientService.CreateClient(clientModel.FirstName, clientModel.LastName, clientModel.DateOfBirth,
                clientModel.Address, clientModel.Phone, clientModel.Email, clientModel.LeftEye, clientModel.RightEye);
            unitOfWork.Commit();
            context.Dispose();
            return RedirectToAction("ClientView", "Chemist", new { clientId = client.Id });
        }

        [HttpGet]
        public ActionResult ClientView(int clientId)
        {
            var context = new ChemistContext(Resources.ConnectionString);
            var unitOfWork = new UnitOfWorks(context);
            var repositoryFactory = new RepositoryFactory(context);
            var clientService = new ClientService(unitOfWork, repositoryFactory);
            var client = clientService.GetClientById(clientId);
            var clientModel = new ClientModel
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                DateOfBirth = client.DateOfBirth,
                Address = client.Address,
                Phone = client.Phone,
                Email = client.Email,
                LeftEye = client.LeftEye,
                RightEye = client.RightEye,
                VisitLists = client.VisitLists,
                Id = client.Id
            };
            return View(clientModel);
        }

        [HttpGet]
        public ActionResult AddVisitList(int clientId)
        {
            var changeVisitListModel = new ChangeVisitListModel { ClientId = clientId };
            return View(changeVisitListModel);
        }

        [HttpPost]
        public ActionResult AddVisitList(ChangeVisitListModel changeVisitListModel)
        {
            var context = new ChemistContext(Resources.ConnectionString);
            var unitOfWork = new UnitOfWorks(context);
            var repositoryFactory = new RepositoryFactory(context);
            var clientService = new ClientService(unitOfWork, repositoryFactory);
            var client = clientService.GetClientById(changeVisitListModel.ClientId);
            var visitListService = new VisitListService(unitOfWork, repositoryFactory);
            var visitList = visitListService.CreateVisitList(changeVisitListModel.VisitDate,
                changeVisitListModel.OrderAmount, changeVisitListModel.OrderStatus, client);
            clientService.AddVisitListToClient(visitList, client.Id);
            unitOfWork.Commit();
            context.Dispose();
            return RedirectToAction("ClientView", "Chemist", new { clientId = client.Id });
        }

        [HttpGet]
        public ActionResult DeleteVisitList(int visitListId)
        {
            var context = new ChemistContext(Resources.ConnectionString);
            var unitOfWork = new UnitOfWorks(context);
            var repositoryFactory = new RepositoryFactory(context);
            var visitListService = new VisitListService(unitOfWork, repositoryFactory);
            var visitList = visitListService.GetVisitListById(visitListId);
            var Id = visitList.ClientId;
            visitListService.RemoveVisitList(visitList);
            unitOfWork.Commit();
            context.Dispose();
            return RedirectToAction("ClientView", "Chemist", new { clientId = Id });
        }

        [HttpGet]
        public ActionResult EditVisitList(int visitListId)
        {
            var context = new ChemistContext(Resources.ConnectionString);
            var unitOfWork = new UnitOfWorks(context);
            var repositoryFactory = new RepositoryFactory(context);
            var visitListService = new VisitListService(unitOfWork, repositoryFactory);
            var visitList = visitListService.GetVisitListById(visitListId);
            var visitListModel = new ChangeVisitListModel { Id = visitListId, ClientId = visitList.ClientId, OrderAmount = visitList.OrderAmount, OrderStatus = visitList.OrderStatus, VisitDate = visitList.VisitDate };
            return View(visitListModel);
        }

        [HttpPost]
        public ActionResult EditVisitList(ChangeVisitListModel changeVisitListModel)
        {
            var context = new ChemistContext(Resources.ConnectionString);
            var unitOfWork = new UnitOfWorks(context);
            var repositoryFactory = new RepositoryFactory(context);
            var visitListService = new VisitListService(unitOfWork, repositoryFactory);
            var visitList = visitListService.GetVisitListById(changeVisitListModel.Id);
            visitList.OrderAmount = changeVisitListModel.OrderAmount;
            visitList.OrderStatus = changeVisitListModel.OrderStatus;
            visitList.VisitDate = changeVisitListModel.VisitDate;
            visitListService.UpdateVisitList(visitList);
            unitOfWork.Commit();
            context.Dispose();
            return RedirectToAction("ClientView", "Chemist", new { clientId = visitList.ClientId });
        }
    }
}
