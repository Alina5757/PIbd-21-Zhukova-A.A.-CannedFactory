using CannedFactoryContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryContracts.ViewModels
{
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 75)]
        public int? Id { get; set; }

        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }

        [Column(title: "Время работы", width: 75)]
        public int WorkingTime { get; set; }

        [Column(title: "Время отдыха", width: 75)]
        public int PauseTime { get; set; }
    }
}
