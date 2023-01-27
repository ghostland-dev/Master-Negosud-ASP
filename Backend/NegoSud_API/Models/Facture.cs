using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSud_API.Models
{
    public class Facture
    {
        public int Id { get; set; }
         public string? Reference { get; set; }
        public float FactureTotal { get; set; }
        
    }
}