using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CannedFactoryDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        public int TimeWork { get; set; }

        [Required]
        public int TimeRest { get; set; }

        [ForeignKey("ImplementerId")]
        public virtual List<Order> Orders { get; set; }
    }
}
