using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using NegoSud_API.Models;
 
 

namespace NegoSud_API.Models
{
    public class NegosudDbContext : DbContext
    {

        public NegosudDbContext( DbContextOptions<NegosudDbContext> options ) : base(options){

        }
      

        public DbSet<Utilisateur> Utilisateurs {get; set; }= null!;
        public DbSet<Commande> Commandes {get; set; }= null!;
        public DbSet<ElemCommande> ElemCommandes {get; set; }= null!;
        public DbSet<Facture> Factures {get; set; }= null!;
        public DbSet<ElemFacture> ElemFactures {get; set; }= null!;
        public DbSet<Pays> Pays {get; set; }= null!;
        public DbSet<Region> Regions {get; set; }= null!;
        public DbSet<Ville> Villes {get; set; }= null!;
        public DbSet<Adresse> Adresses {get; set; }= null!;
        public DbSet<Catalogue> Catalogues {get; set; }= null!;
        public DbSet<Produit> Produits {get; set; }= null!;
        public DbSet<Producteur> Producteurs {get; set; }= null!;
        public DbSet<Fournisseur> Fournisseurs {get; set; }= null!;
        public DbSet<Magazin> Magazins {get; set; }= null!;
        public DbSet<Inventaire> Inventaires {get; set; }= null!;
        public DbSet<Categorie> Categories {get; set; }= null!;
     

    }
}