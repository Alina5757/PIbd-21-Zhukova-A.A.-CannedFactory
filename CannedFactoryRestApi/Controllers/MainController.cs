using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.BusinessLogicsContracts;
using CannedFactoryContracts.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CannedFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ICannedLogic _canned;
        public MainController(IOrderLogic order, ICannedLogic canned)
        {
            _order = order;
            _canned = canned;
        }

        [HttpGet]
        public List<CannedViewModel> GetCannedList() {
            return _canned.Read(null)?.ToList();
        }

        [HttpGet]
        public CannedViewModel GetCanned(int cannedId) => _canned.Read(new CannedBindingModel { Id = cannedId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
