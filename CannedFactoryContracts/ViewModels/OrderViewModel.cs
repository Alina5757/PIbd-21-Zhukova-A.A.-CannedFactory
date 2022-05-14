using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CannedFactoryContracts.ViewModels
{
    //Заказ
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CannedId { get; set; }
        public int ClientId { get; set; }
        public int ImplementerId { get; set; }

        [DisplayName("Изделие")]
        public string CannedName { get; set; }

        [DisplayName("ФИО клиента")]
        public string FIOClient { get; set; }

        [DisplayName("ФИО исполнителя")]
        public string FIOImplementer { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public string Status { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
