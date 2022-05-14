using CannedFactoryContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryContracts.ViewModels
{
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int? Id { get; set; }

        [Column(title: "Логин", width: 100)]
        public string Login { get; set; }

        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }

        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}
