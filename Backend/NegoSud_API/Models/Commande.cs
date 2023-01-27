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
        public float Remise { get; set; }
        public DateTime? DateCommande { get; set; }
        public DateTime DateModification { get; set; }

        public IList<ElemCommande> ElemCommandes { get; } = new List<ElemCommande>();
    }
}