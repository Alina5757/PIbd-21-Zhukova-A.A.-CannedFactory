using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.StoragesContracts;
using CannedFactoryContracts.ViewModels;
using CannedFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton source;

        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            var result = new List<MessageInfoViewModel>();
            foreach (var messageInfo in source.MessagesInfo)
            {
                result.Add(CreateModel(messageInfo));
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<MessageInfoViewModel>();

            if (model.ClientId.HasValue)
            {
                foreach (var messageInfo in source.MessagesInfo)
                {
                    if (messageInfo.ClientId == model.ClientId)
                    {
                        result.Add(CreateModel(messageInfo));
                    }
                }
            }

            else if (!model.ClientId.HasValue)
            {
                foreach (var messageInfo in source.MessagesInfo)
                {
                    if (messageInfo.DateDelivery.Date == model.DateDelivery.Date)
                    {
                        result.Add(CreateModel(messageInfo));
                    }
                    else if (messageInfo.SenderName != null && messageInfo.SenderName != "" &&
                        messageInfo.SenderName == model.FromMailAddress)
                    {
                        result.Add(CreateModel(messageInfo));
                    }
                }
            }

            return result;
        }

        public void Insert(MessageInfoBindingModel model)
        {
            MessageInfo element = null;
            foreach (var messageInfo in source.MessagesInfo)
            {
                if(messageInfo.MessageId == model.MessageId)
                {
                    element = messageInfo;
                    break;
                }
            }
     
            if (element != null)
            {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }

            var tempMessage = new MessageInfo { MessageId = model.MessageId };
            foreach (var client in source.Clients)
            {
                if (client.Login == model.FromMailAddress)
                {
                    tempMessage.ClientId = client.Id;
                    break;
                }
            }
            source.MessagesInfo.Add(CreateModel(model, tempMessage));                
        }

        private static MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo messageInfo)
        {
            messageInfo.MessageId = model.MessageId;
            messageInfo.SenderName = model.FromMailAddress;
            messageInfo.DateDelivery = model.DateDelivery;
            messageInfo.Subject = model.Subject;
            messageInfo.Body = model.Body;            
            return messageInfo;
        }

        private static MessageInfoViewModel CreateModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                SenderName = messageInfo.SenderName,
                DateDelivery = messageInfo.DateDelivery,
                Subject = messageInfo.Subject,
                Body = messageInfo.Body
            };
        }
    }
}
