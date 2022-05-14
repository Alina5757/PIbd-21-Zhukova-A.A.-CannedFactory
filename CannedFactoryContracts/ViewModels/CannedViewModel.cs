using CannedFactoryContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CannedFactoryContracts.ViewModels
{
    //Изготовляемое изделие
    public class CannedViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string CannedName { get; set; }

        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> CannedComponents { get; set; }
    }
}
