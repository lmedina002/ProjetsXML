using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetProgAvancee
{
    public abstract class Personne
    {
        private static int _nbPersonne = 0;
        public int Id { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        //Constructeur
        public Personne(string nom, string prenom)
        {
            Id = _nbPersonne;
            Nom = nom;
            Prenom = prenom;
            _nbPersonne += 1;
        }
        public Personne(string nom, string prenom, int id) : this(nom, prenom)
        {
            Id = id;
            _nbPersonne -= 1;
        }
        public Personne()
        {
            Nom = "John";
            Prenom = "Doe";
        }
        //Méthodes
        public static void MajId(int id)
        {
            _nbPersonne = id;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += "Nom: " + Nom;
            chRes += "\nPrénom: " + Prenom;
            return chRes;
        }
    }
}
