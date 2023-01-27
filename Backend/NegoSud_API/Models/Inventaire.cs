using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSud_API.Models
{
    public class Inventaire
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Appelation { get; set; }
        public  string? Couleur { get; set; }
        public  string? Classement { get; set; }
        public string? Millesime { get; set; }
        public string? position { get; set;}
        public int QuantiteStock { get; set; }

    }
}