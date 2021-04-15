using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetProgAvancee
{
    class Livrable
    {
        public DateTime DateRendu { get; set; }
        public int Note { get; set; }
        public string Type { get; set; }

        //Constructeur
        public Livrable()
        {
            DateRendu = DateTime.MinValue;
            Type = "Inconnu";
            Note = -1;
        }
        public Livrable(DateTime date, string type)
        {
            DateRendu = date;
            Type = type;
            Note = -1;
        }
        public Livrable(DateTime date, string type, int note) : this(date,type)
        {
            Note = note;
        }
        //Méthodes
        public override string ToString()
        {
            string chRes = "";
            chRes += "   Date de rendu: " + DateRendu;
            chRes += "\n   Type de livrable: " + Type;
            if (Note != -1)
                chRes += "\n   Note: " + Note + "/20";
            else
                chRes += "\n   Non noté";
            
            return chRes;
        }
    }
}
