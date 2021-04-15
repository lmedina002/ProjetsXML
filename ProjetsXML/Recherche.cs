using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace ProjetProgAvancee
{
    class Recherche
    {
        public static List<Projet> RechercheProjetNom(string nom, string fichierCible)
        {
            List<Projet> listRes = new List<Projet>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode nameNode = singleNode.SelectSingleNode("Nom");
                if(nameNode.InnerText.Contains(nom))
                {
                    listRes.Add(GestionXml.ReconstructionProjet(xmlDoc, singleNode));
                }
            }

            return listRes;
        }

        public static List<Projet> RechercheProjetParticipant(string nom, string prenom, string fichierCible)
        {
            List<Projet> listRes = new List<Projet>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode partisNode = singleNode.SelectSingleNode("Participants");
                XmlNodeList partiNodes = partisNode.SelectNodes("Participant");
                foreach (XmlNode partiNode in partiNodes)
                {
                    XmlNode nameNode = partiNode.SelectSingleNode("Nom");
                    XmlNode surnameNode = partiNode.SelectSingleNode("Prenom");
                    if (nameNode.InnerText.Equals(nom) && surnameNode.InnerText.Equals(prenom))
                    {
                        listRes.Add(GestionXml.ReconstructionProjet(xmlDoc, singleNode));
                    }
                }
                
            }

            return listRes;
        }

        public static List<Projet> RechercheProjetMatiere(string mat, string fichierCible)
        {
            List<Projet> listRes = new List<Projet>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode matsNode = singleNode.SelectSingleNode("Matieres");
                XmlNodeList matNodes = matsNode.SelectNodes("Matiere");
                foreach (XmlNode matNode in matNodes)
                {
                    if (matNode.InnerText.Contains(mat))
                    {
                        listRes.Add(GestionXml.ReconstructionProjet(xmlDoc, singleNode));
                    }
                }                
            }

            return listRes;
        }

        public static List<Projet> AllProjet(string fichierCible)
        {
            List<Projet> listRes = new List<Projet>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                listRes.Add(GestionXml.ReconstructionProjet(xmlDoc, singleNode));
            }

            return listRes;
        }

        public static List<Eleve> AllEleve(string fichierCible)
        {
            List<Eleve> listRes = new List<Eleve>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Personnes/Eleve");
            foreach (XmlNode singleNode in baseNodes)
            {
                listRes.Add(GestionXml.ReconstructionEleve(xmlDoc, singleNode));
            }

            return listRes;
        }

        public static List<Exterieur> AllExterieur(string fichierCible)
        {
            List<Exterieur> listRes = new List<Exterieur>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Personnes/Exterieur");
            foreach (XmlNode singleNode in baseNodes)
            {
                listRes.Add(GestionXml.ReconstructionExterieur(xmlDoc, singleNode));
            }

            return listRes;
        }

        public static List<Enseignant> AllEnseignant(string fichierCible)
        {
            List<Enseignant> listRes = new List<Enseignant>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Personnes/Enseignant");
            foreach (XmlNode singleNode in baseNodes)
            {
                listRes.Add(GestionXml.ReconstructionEnseignant(xmlDoc, singleNode));
            }

            return listRes;
        }

        public static List<string> AllMatiere(string fichierCible)
        {
            List<string> listRes = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Matieres/Matiere");
            foreach (XmlNode singleNode in baseNodes)
            {
                listRes.Add(singleNode.InnerText);
            }

            return listRes;
        }
        public static XmlNode RechercheNodeId(int id, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode idNode = singleNode.SelectSingleNode("Id");
                if (idNode.InnerText == id.ToString())
                {
                    return singleNode;
                }
            }

            XmlNode inconnu = xmlDoc.SelectSingleNode("Projet");
            return inconnu;

        }
        public static string NomProjetId(int id, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNode baseNode = RechercheNodeId(id, fichierCible);
            XmlNode nameNode = baseNode.SelectSingleNode("Nom");
            return nameNode.InnerText;
        }
        public static int RechercheMaxIdProjet(string fichierCible)
        {
            int res = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode idNode = singleNode.SelectSingleNode("Id");                
                if (int.Parse(idNode.InnerText) > res)
                {
                    res = int.Parse(idNode.InnerText);
                }
            }
                        
            return res;

        }

        public static int RechercheMaxIdPersonne(string fichierCible)
        {
            int res = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNodeList baseNodes = xmlDoc.DocumentElement.ChildNodes;
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode idNode = singleNode.SelectSingleNode("Id");
                if (int.Parse(idNode.InnerText) > res)
                {
                    res = int.Parse(idNode.InnerText);
                }
            }

            return res;
        }

        public static bool VerifExistenceEleve(string fichierCible, Eleve E)
        {
            List<Eleve> all = AllEleve(fichierCible);
            foreach (Eleve El in all)
            {
                if (El.Nom == E.Nom && E.Prenom == El.Prenom && E.Promotion == El.Promotion)
                    return true;
            }

            return false;
        }
        public static bool VerifExistenceExterieur(string fichierCible, Exterieur E)
        {
            List<Exterieur> all = AllExterieur(fichierCible);
            foreach (Exterieur Ex in all)
            {
                if (Ex.Nom == Ex.Nom && Ex.Prenom == Ex.Prenom && Ex.Entreprise == Ex.Entreprise)
                    return true;
            }

            return false;
        }
        public static bool VerifExistenceEnseignant(string fichierCible, Enseignant E)
        {
            List<Enseignant> all = AllEnseignant(fichierCible);
            foreach (Enseignant En in all)
            {
                if (En.Nom == E.Nom && En.Prenom == En.Prenom)
                {
                    foreach (string M in En.Enseignement)
                    {
                        if (E.Enseignement.Contains(M) == false)
                            return false;
                    }
                    return true;
                }
                    
            }

            return false;
        }
        public static bool VerifExistenceMatiere(string fichierCible, string M)
        {
            List<string> all = AllMatiere(fichierCible);
            foreach (string mat in all)
            {
                if (mat == M)
                {                    
                    return true;
                }
            }

            return false;
        }
    }
}
