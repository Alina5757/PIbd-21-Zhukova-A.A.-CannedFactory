using CannedFactoryBusinessLogic.MailWorker;
using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.BusinessLogicsContracts;
using CannedFactoryContracts.Enums;
using CannedFactoryContracts.StoragesContracts;
using CannedFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CannedFactoryBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IClientStorage _clientStorage;
        private readonly AbstractMailWorker _mailWorker;

        public OrderLogic(IOrderStorage orderStorage, AbstractMailWorker mailWorker, IClientStorage clientStorage)
        {
            _orderStorage = orderStorage;
            _clientStorage = clientStorage;
            _mailWorker = mailWorker;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                CannedId = model.CannedId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят,
                DateCreate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            });
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким ID");
            }
            _orderStorage.Insert(new OrderBindingModel {
                CannedId = model.CannedId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят,
                DateCreate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            });

            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = model.ClientId
                })?.Login,
                Subject = "Создан заказ",
                Text = $"Заказ от {DateTime.Now} количеством {model.Count} на сумму {model.Sum} создан"
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId               
            });
            if (element == null)
            {
                throw new Exception("Консервы не найдены");
            }
            if (element.Status != OrderStatus.Принят.ToString()) {
                throw new Exception("Заказ не в статусе 'Принят'");
            }
            if (element.Status == OrderStatus.Принят.ToString()) {
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = model.OrderId,
                    CannedId = element.CannedId,
                    ClientId = element.ClientId,
                    ImplementerId = model.ImplementerId,
                    Count = element.Count,
                    Sum = element.Sum,
                    Status = OrderStatus.Выполняется,
                    DateCreate = element.DateCreate
                });
            }

            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = element.ClientId
                })?.Login,
                Subject = $"Заказ №{element.Id} передан в работу",
                Text = $"Заказ №{element.Id} от {DateTime.Now} количеством {element.Count} на сумму {element.Sum} передан в работу"
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (element == null)
            {
                throw new Exception("Консервы не найдены");
            }
            if (element.Status != OrderStatus.Выполняется.ToString())
            {
                throw new Exception("Заказ не в статусе 'Выполняется'");
            }
            if (element.Status == OrderStatus.Выполняется.ToString())
            {
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = model.OrderId,
                    CannedId = element.CannedId,
                    ClientId = element.ClientId,
                    Count = element.Count,
                    Sum = element.Sum,
                    Status = OrderStatus.Готов,
                    DateCreate = element.DateCreate
                });
            }

            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = element.ClientId
                })?.Login,
                Subject = $"Заказ №{element.Id} готов",
                Text = $"Заказ №{element.Id} от {DateTime.Now} количеством {element.Count} на сумму {element.Sum} готов"
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (element == null)
            {
                throw new Exception("Консервы не найдены");
            }
            if (element.Status != OrderStatus.Готов.ToString())
            {
                throw new Exception("Заказ не в статусе 'Готов'");
            }
            if (element.Status == OrderStatus.Готов.ToString())
            {
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = model.OrderId,
                    CannedId = element.CannedId,
                    ClientId = element.ClientId,
                    Count = element.Count,
                    Sum = element.Sum,
                    Status = OrderStatus.Выдан,
                    DateCreate = element.DateCreate,
                    DateImplement = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                });
            }

            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = element.ClientId
                })?.Login,
                Subject = $"Заказ №{element.Id} выдан",
                Text = $"Заказ №{element.Id} от {DateTime.Now} количеством {element.Count} на сумму {element.Sum} выдан"
            });
        }
    }
}
