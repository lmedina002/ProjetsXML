using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetProgAvancee
{
    public class Eleve : Personne
    {
        public int Promotion { get; set; }

        //Constructeur
        public Eleve() : base()
        {
            Promotion = 0;
        }
        public Eleve(string nom, string prenom, int promo) : base(nom,prenom)
        {
            Promotion = promo;
        }
        public Eleve(string nom, string prenom, int promo, int id) : base(nom, prenom, id)
        {
            Promotion = promo;
        }
        //Methodes
        public void Redouble()
        {
            Promotion += 1; 
        }
        public override string ToString()
        {
            return base.ToString() + "\nPromotion: " + Promotion;
        }
    }
}
