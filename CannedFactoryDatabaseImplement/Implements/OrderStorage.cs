using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.StoragesContracts;
using CannedFactoryContracts.ViewModels;
using CannedFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new CannedFactoryDatabase();
            return context.Orders
            .Select(CreateModel)
            .ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CannedFactoryDatabase();
            return context.Orders
            .Include(rec => rec.Canned)
            .Include(rec => rec.Client)
            .Include(rec => rec.Implementer)
            .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
            (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >=
            model.DateFrom.Value.Date && rec.DateCreate.Date <=
            model.DateTo.Value.Date) ||
            (model.ClientId != 0 && rec.ClientId == model.ClientId) ||
            (model.SearchStatus.HasValue && model.SearchStatus.Value == rec.Status) ||
            (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && model.Status == rec.Status))
            .Select(CreateModel)
            .ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CannedFactoryDatabase();
            var order = context.Orders
            .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new CannedFactoryDatabase();
            context.Orders.Add(CreateModel(model, new Order(), context));
            context.SaveChanges();
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new CannedFactoryDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element, context);
            context.SaveChanges();
        }

        public void Delete(OrderBindingModel model)
        {
            using var context = new CannedFactoryDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Order CreateModel(OrderBindingModel model, Order order, CannedFactoryDatabase context)
        {
            order.CannedId = model.CannedId;
            order.ClientId = model.ClientId;
            if (model.ImplementerId != null)
            {
                order.ImplementerId = (int)model.ImplementerId;
            }
            order.CannedName = context.Canneds.FirstOrDefault(rec => rec.Id == model.CannedId).CannedName;
            order.ClientName = context.Clients.FirstOrDefault(rec => rec.Id == model.ClientId).FIO;
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            if (model.DateImplement.HasValue) {
                order.DateImplement = (DateTime)model.DateImplement;
            }
            order.Sum = model.Sum;
            order.Status = model.Status;
            return order;
        }

        private static OrderViewModel CreateModel(Order order)
        {
            string FIOImp = "";
            if (order.ImplementerId != null) {
                using var context = new CannedFactoryDatabase();
                FIOImp = context.Implementers.FirstOrDefault(rec => rec.Id == order.ImplementerId).FIO;
            }
            return new OrderViewModel
            {
                Id = order.Id,
                CannedName = order.CannedName,
                CannedId = order.CannedId,
                FIOClient = order.ClientName,
                ClientId = order.ClientId,
                ImplementerId = (int)(order.ImplementerId == null? 0 : order.ImplementerId),
                FIOImplementer = FIOImp,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
