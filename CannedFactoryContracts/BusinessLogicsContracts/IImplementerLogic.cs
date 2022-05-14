using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryContracts.BusinessLogicsContracts
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);

        void CreateOrUpdate(ImplementerBindingModel model);

        void Delete(ImplementerBindingModel model);
    }
}
