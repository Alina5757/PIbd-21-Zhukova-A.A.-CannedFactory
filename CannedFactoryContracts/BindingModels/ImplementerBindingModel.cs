using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryContracts.BindingModels
{
    public class ImplementerBindingModel
    {
        public int? Id { get; set; }
        public string FIO { get; set; }
        public int TimeWork { get; set; }
        public int TimeRest { get; set; }
    }
}
