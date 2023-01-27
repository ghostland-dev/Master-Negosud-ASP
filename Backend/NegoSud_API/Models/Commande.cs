using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSud_API.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public string? Statut { get; set; }
        public DateTime? DateCommande { get; set; }
    }
}