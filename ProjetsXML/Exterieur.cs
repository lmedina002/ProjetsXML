using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetProgAvancee
{
    class Exterieur : Personne
    {
        public string Entreprise { get; set; }

        //Constructeur
        public Exterieur(string nom, string prenom) : base(nom,prenom) { }
        public Exterieur(string nom, string prenom, string entreprise) : base(nom, prenom)
        {
            Entreprise = entreprise;
        }
        public Exterieur(string nom, string prenom, string entreprise, int id) : base(nom, prenom, id)
        {
            Entreprise = entreprise;
        }

        public Exterieur() : base()
        {
            Entreprise = "Doe Company";
        }
        //Méthodes
        public override string ToString()
        {
            return base.ToString() + "\nEntreprise: " + Entreprise;
        }
    }
}
