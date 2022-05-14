using CannedFactoryContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CannedFactoryContracts.ViewModels
{
    //компонент, необходимый для изготовления изделия
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 75)]
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
