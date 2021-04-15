using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetProgAvancee
{
    class Enseignant : Personne
    {
        public List<string> Enseignement { get; set; }

        //Constructeur
        public Enseignant() : base() { }
        public Enseignant(string nom, string prenom) : base(nom, prenom) 
        {
            Enseignement = new List<string>();
        }
        public Enseignant(string nom, string prenom, params string[] tabM) : base(nom, prenom)
        {
            Enseignement = new List<string>();
            foreach (string M in tabM)
            {
                Enseignement.Add(M);
            }
        }
        public Enseignant(string nom, string prenom,int id, params string[] tabM) : base(nom, prenom, id)
        {
            Enseignement = new List<string>();
            foreach (string M in tabM)
            {
                Enseignement.Add(M);
            }
        }
        //Méthodes
        public void AjoutMatiere(string M)
        {
            Enseignement.Add(M);
        }
        public void SupprMatiere(string M)
        {
            Enseignement.Remove(M);
        }
        public override string ToString()
        {
            string chRes = base.ToString();
            chRes += "\nMatières enseignées: ";
            foreach (string M in Enseignement)
            {
                chRes += "\n    " +  M;
            }
            return chRes;
        }
    }
}
