using CannedFactoryContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryContracts.ViewModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    public class MessageInfoViewModel
    {
        [Column(title: "Id", width: 50)]
        public string MessageId { get; set; }

        [Column(title: "Отправитель", width: 150)]
        public string SenderName { get; set; }

        [Column(title: "Дата письма", width: 125)]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 125)]
        public string Subject { get; set; }

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Body { get; set; }
    }
}
