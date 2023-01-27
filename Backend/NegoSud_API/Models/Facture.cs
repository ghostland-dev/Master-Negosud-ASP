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
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        // Foreign keys
        public int? UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        public IList<ElemFacture>? ElemFactures { get; set; }
        public IList<Produit>? Produits { get; set; }

    }
}