using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace CannedFactoryContracts.BusinessLogicsContracts
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void CreateOrUpdate(MessageInfoBindingModel model);
    }
}
