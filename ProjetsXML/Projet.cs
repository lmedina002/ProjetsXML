using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetProgAvancee
{
    class Projet
    {
        private static int _nbProjet = 0;
        public int Id { get; }
        public string Nom { get; set; }
        public List<Tuple<Personne,string>> ListeParticipants { get; set; }
        public string Sujet { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public List<Livrable> ListeLivrables { get; set; } //Le nom à été changé pour être cohérent avec les autres noms untilisés
        public string TypeProjet { get; set; }
        public int RenouvellementDe { get; set; } //On stocke seulement l'identifiant du projet
        public List<string> Domaine { get; set; }

        //Constructeurs
        public Projet(string nom, string sujet, DateTime dateStart, DateTime dateFin, string type)
        {
            Id = _nbProjet;
            Nom = nom;
            Sujet = sujet;
            DateDebut = dateStart;
            DateFin = dateFin;
            TypeProjet = type;
            ListeParticipants = new List<Tuple<Personne, string>>();
            ListeLivrables = new List<Livrable>();
            Domaine = new List<string>();
            RenouvellementDe = -1;
            _nbProjet += 1;
        }
        public Projet(string nom, string sujet, DateTime dateStart, DateTime dateFin, string type, int id) : this(nom,sujet,dateStart,dateFin,type)
        {
            Id = id;
            _nbProjet -= 1;
        }

        //Méthodes
        public void AjoutParticipant(Personne P, string role)
        {
            ListeParticipants.Add(Tuple.Create(P, role));
        }
        public void RetraitParticipant(Personne P)
        {
            bool existe = false;
            foreach (var tuple in ListeParticipants)
            {
                if (tuple.Item1 == P)
                {
                    ListeParticipants.Remove(tuple);
                    existe = true;
                }
            }

            if (existe == false)
                Console.WriteLine("Cette personne ne fait pas partie du projet");
        }
        public void AjoutMatiere(string M)
        {
            Domaine.Add(M);
        }
        public void RetraitMatiere(string M)
        {
            if(Domaine.Contains(M))
            {
                Domaine.Remove(M);
            }
            else
                Console.WriteLine("Cette matière ne rentre pas dans le domaine du projet");
        }
        public void AjoutLivrable(Livrable L)
        {
            ListeLivrables.Add(L);
        }
        public void RetraitLivrable(Livrable L)
        {
            if (ListeLivrables.Contains(L))
            {
                ListeLivrables.Remove(L);
            }
            else
                Console.WriteLine("Ce livrable n'existe pas dans ce projet");
        }
        public void SuiteDe(int id)
        {
            RenouvellementDe = id;
        }
        public TimeSpan Duree() //Erreur dans diagramme classe: le retour est sous forme TimeSpan et non DateTime
        {
            return DateFin - DateDebut;
        }
        public int NbPersonne()
        {
            return ListeParticipants.Count;
        }
        public static void MajId(int id)
        {
            _nbProjet = id;
        }
        public override string ToString()
        {
            string fichierProjet = "Projets.xml";
            string chRes = "";
            chRes += "Nom: " + Nom;
            chRes += "\nSujet: " + Sujet;
            chRes += "\nType de projet: " + TypeProjet;
            chRes += "\nParticipants: ";
            foreach (var tuple in ListeParticipants)
            {
                chRes += "\n     " + tuple.Item1.Nom + " " + tuple.Item1.Prenom + "   Rôle: " + tuple.Item2; 
            }
            chRes += "\nDate de début: " + DateDebut;
            chRes += "\nDate de fin: " + DateFin;
            chRes += "\nDurée: " + Duree();
            chRes += "\nLivrables: ";
            foreach (var item in ListeLivrables)
            {
                chRes += "\n" + item;
            }
            if (RenouvellementDe != -1)
                chRes += "\nCe projet est le renouvellement du projet " + Recherche.NomProjetId(RenouvellementDe, fichierProjet);
            else
                chRes += "\nCe projet n'est le renouvellement d'aucun projet";
            chRes += "\nMatières concernées: ";
            foreach (var item in Domaine)
            {
                chRes += "\n     " + item;
            }
            return chRes;
        }

    }
}
