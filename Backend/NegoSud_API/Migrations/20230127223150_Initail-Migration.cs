using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitailMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Catalogues",
                columns: table => new
                {
                    CatalogueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Reference = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.CatalogueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameCategorie = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ElemCommandes",
                columns: table => new
                {
                    ElemCommandeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantiteCommande = table.Column<int>(type: "int", nullable: true),
                    SeuilAlerte = table.Column<int>(type: "int", nullable: true),
                    Alerte = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalCommande = table.Column<float>(type: "float", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElemCommandes", x => x.ElemCommandeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventaires",
                columns: table => new
                {
                    InventaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Appelation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Couleur = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Classement = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Millesime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    position = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantiteStock = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaires", x => x.InventaireId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    PaysId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NamePays = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.PaysId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameRegion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomUtilisateur = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotDePasse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: true),
                    IsBusiness = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    SIREN = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateInscription = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.UtilisateurId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    VilleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameVille = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.VilleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Reference = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Statut = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCommande = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateAnnullation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateLivrison = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ElemCommandeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.CommandeId);
                    table.ForeignKey(
                        name: "FK_Commandes_ElemCommandes_ElemCommandeId",
                        column: x => x.ElemCommandeId,
                        principalTable: "ElemCommandes",
                        principalColumn: "ElemCommandeId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomFournisseur = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fix = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pays = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reputation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaysId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurId);
                    table.ForeignKey(
                        name: "FK_Fournisseurs_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "PaysId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Producteurs",
                columns: table => new
                {
                    ProducteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaisonSocial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaysId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producteurs", x => x.ProducteurId);
                    table.ForeignKey(
                        name: "FK_Producteurs_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "PaysId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdressePrincipal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdresseComplet = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodePostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pays = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    typeAdresse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                    table.ForeignKey(
                        name: "FK_Adresses_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    FactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Reference = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FactureTotal = table.Column<float>(type: "float", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.FactureId);
                    table.ForeignKey(
                        name: "FK_Factures_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Magasins",
                columns: table => new
                {
                    MagasinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomMagasin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fix = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodePostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pays = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaysId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    VilleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magasins", x => x.MagasinId);
                    table.ForeignKey(
                        name: "FK_Magasins_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "PaysId");
                    table.ForeignKey(
                        name: "FK_Magasins_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId");
                    table.ForeignKey(
                        name: "FK_Magasins_Villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "VilleId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ElemFactures",
                columns: table => new
                {
                    ElemFactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FactureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElemFactures", x => x.ElemFactureId);
                    table.ForeignKey(
                        name: "FK_ElemFactures_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "FactureId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomProduit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resumee = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prixunitaire = table.Column<float>(name: "Prix_unitaire", type: "float", nullable: true),
                    Taxes = table.Column<float>(type: "float", nullable: true),
                    ImagePrincipal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ancien = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Couleur = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Raisins = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alcool = table.Column<float>(type: "float", nullable: true),
                    Aliments = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Conservation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expiration = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Volume = table.Column<float>(type: "float", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProducteurId = table.Column<int>(type: "int", nullable: true),
                    FournisseurId = table.Column<int>(type: "int", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: true),
                    CatalogueId = table.Column<int>(type: "int", nullable: true),
                    FactureId = table.Column<int>(type: "int", nullable: true),
                    InventaireId = table.Column<int>(type: "int", nullable: true),
                    MagasinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitId);
                    table.ForeignKey(
                        name: "FK_Produits_Catalogues_CatalogueId",
                        column: x => x.CatalogueId,
                        principalTable: "Catalogues",
                        principalColumn: "CatalogueId");
                    table.ForeignKey(
                        name: "FK_Produits_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId");
                    table.ForeignKey(
                        name: "FK_Produits_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "FactureId");
                    table.ForeignKey(
                        name: "FK_Produits_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "FournisseurId");
                    table.ForeignKey(
                        name: "FK_Produits_Inventaires_InventaireId",
                        column: x => x.InventaireId,
                        principalTable: "Inventaires",
                        principalColumn: "InventaireId");
                    table.ForeignKey(
                        name: "FK_Produits_Magasins_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "Magasins",
                        principalColumn: "MagasinId");
                    table.ForeignKey(
                        name: "FK_Produits_Producteurs_ProducteurId",
                        column: x => x.ProducteurId,
                        principalTable: "Producteurs",
                        principalColumn: "ProducteurId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UtilisateurId",
                table: "Adresses",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ElemCommandeId",
                table: "Commandes",
                column: "ElemCommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElemFactures_FactureId",
                table: "ElemFactures",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_UtilisateurId",
                table: "Factures",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_PaysId",
                table: "Fournisseurs",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Magasins_PaysId",
                table: "Magasins",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Magasins_RegionId",
                table: "Magasins",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Magasins_VilleId",
                table: "Magasins",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Producteurs_PaysId",
                table: "Producteurs",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CatalogueId",
                table: "Produits",
                column: "CatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieId",
                table: "Produits",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_FactureId",
                table: "Produits",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_FournisseurId",
                table: "Produits",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_InventaireId",
                table: "Produits",
                column: "InventaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_MagasinId",
                table: "Produits",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_ProducteurId",
                table: "Produits",
                column: "ProducteurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "ElemFactures");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "ElemCommandes");

            migrationBuilder.DropTable(
                name: "Catalogues");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Inventaires");

            migrationBuilder.DropTable(
                name: "Magasins");

            migrationBuilder.DropTable(
                name: "Producteurs");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Villes");

            migrationBuilder.DropTable(
                name: "Pays");
        }
    }
}
