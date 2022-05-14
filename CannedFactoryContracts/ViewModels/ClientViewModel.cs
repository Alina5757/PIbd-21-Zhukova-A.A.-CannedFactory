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
        public int? Id { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("ФИО")]
        public string FIO { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
