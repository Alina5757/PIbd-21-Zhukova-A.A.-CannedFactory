﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CannedFactoryContracts.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int CannedId { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
