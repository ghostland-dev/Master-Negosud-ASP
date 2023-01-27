using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSud_API.Models
{
    public class ElemCommande
    {
        public int Id { get; set; }
        public int? QuantiteCommande { get; set; }
        public int? SeuilAlerte { get; set; }
        public string? Alerte { get; set; }
        public float TotalCommande { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

    }
}