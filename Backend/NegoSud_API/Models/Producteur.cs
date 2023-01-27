using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSud_API.Models
{
    public class Producteur
    {
        public int Id { get; set; }
        public string? NomProducteur { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
    }
}