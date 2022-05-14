using CannedFactoryContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace CannedFactoryContracts.ViewModels
{
    //Заказ
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 75)]
        public int Id { get; set; }
        public int CannedId { get; set; }
        public int ClientId { get; set; }
        public int ImplementerId { get; set; }

        [Column(title: "Изделие", width: 125)]
        public string CannedName { get; set; }

        [Column(title: "Клиент", width: 150)]
        public string FIOClient { get; set; }

        [Column(title: "Исполнитель", width: 150)]
        [DataMember]
        public string FIOImplementer { get; set; }

        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 75)]
        public string Status { get; set; }

        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}
