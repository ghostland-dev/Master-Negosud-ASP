using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSud_API.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string? NameCategorie { get; set;}

        public IList<Produit>? Produit { get; set;}
    }
}