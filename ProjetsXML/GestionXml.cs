using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ProjetProgAvancee
{
    class GestionXml
    {
        //Fonctions d'écriture
        public static void EleveXml(Eleve E, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode baseNode = xmlDoc.CreateElement("Eleve");
            XmlNode idNode = xmlDoc.CreateElement("Id");
            idNode.InnerText = E.Id.ToString();
            XmlNode nameNode = xmlDoc.CreateElement("Nom");
            nameNode.InnerText = E.Nom;
            XmlNode surnameNode = xmlDoc.CreateElement("Prenom");
            surnameNode.InnerText = E.Prenom;
            XmlNode promoNode = xmlDoc.CreateElement("Promotion");
            promoNode.InnerText = E.Promotion.ToString();
            baseNode.AppendChild(idNode);
            baseNode.AppendChild(nameNode);
            baseNode.AppendChild(surnameNode);
            baseNode.AppendChild(promoNode);

            if (File.Exists(fichierCible))
            {
                xmlDoc.Load(fichierCible);
                XmlNode rootNode = xmlDoc.SelectSingleNode("//Personnes");
                rootNode.AppendChild(baseNode);
            }
            else
            {
                XmlNode rootNode = xmlDoc.CreateElement("Personnes");
                xmlDoc.AppendChild(rootNode);
                rootNode.AppendChild(baseNode);
            }

            xmlDoc.Save(fichierCible);
        }

        public static void ExterieurXml(Exterieur E, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode baseNode = xmlDoc.CreateElement("Exterieur");
            XmlNode idNode = xmlDoc.CreateElement("Id");
            idNode.InnerText = E.Id.ToString();
            XmlNode nameNode = xmlDoc.CreateElement("Nom");
            nameNode.InnerText = E.Nom;
            XmlNode surnameNode = xmlDoc.CreateElement("Prenom");
            surnameNode.InnerText = E.Prenom;
            XmlNode cieNode = xmlDoc.CreateElement("Entreprise");
            cieNode.InnerText = E.Entreprise;
            baseNode.AppendChild(idNode);
            baseNode.AppendChild(nameNode);
            baseNode.AppendChild(surnameNode);
            baseNode.AppendChild(cieNode);

            if (File.Exists(fichierCible))
            {
                xmlDoc.Load(fichierCible);
                XmlNode rootNode = xmlDoc.SelectSingleNode("//Personnes");
                rootNode.AppendChild(baseNode);
            }
            else
            {
                XmlNode rootNode = xmlDoc.CreateElement("Personnes");
                xmlDoc.AppendChild(rootNode);
                rootNode.AppendChild(baseNode);
            }

            xmlDoc.Save(fichierCible);
        }

        public static void EnseignantXml(Enseignant E, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode baseNode = xmlDoc.CreateElement("Enseignant");
            XmlNode idNode = xmlDoc.CreateElement("Id");
            idNode.InnerText = E.Id.ToString();
            XmlNode nameNode = xmlDoc.CreateElement("Nom");
            nameNode.InnerText = E.Nom;
            XmlNode surnameNode = xmlDoc.CreateElement("Prenom");
            surnameNode.InnerText = E.Prenom;
            XmlNode matBaseNode = xmlDoc.CreateElement("Matieres");
            foreach (string M in E.Enseignement)
            {
                XmlNode matNode = xmlDoc.CreateElement("Matiere");
                matNode.InnerText = M;
                matBaseNode.AppendChild(matNode);
            }
            baseNode.AppendChild(idNode);
            baseNode.AppendChild(nameNode);
            baseNode.AppendChild(surnameNode);
            baseNode.AppendChild(matBaseNode);

            if (File.Exists(fichierCible))
            {
                xmlDoc.Load(fichierCible);
                XmlNode rootNode = xmlDoc.SelectSingleNode("//Personnes");
                rootNode.AppendChild(baseNode);
            }
            else
            {
                XmlNode rootNode = xmlDoc.CreateElement("Personnes");
                xmlDoc.AppendChild(rootNode);
                rootNode.AppendChild(baseNode);
            }

            xmlDoc.Save(fichierCible);

        }

        public static void LivrableXml(Livrable L, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode baseNode = xmlDoc.CreateElement("Livrable");
            XmlNode typeNode = xmlDoc.CreateElement("Type");
            typeNode.InnerText = L.Type;
            XmlNode dateNode = xmlDoc.CreateElement("Date");
            dateNode.InnerText = L.DateRendu.ToString();
            XmlNode noteNode = xmlDoc.CreateElement("Note");
            noteNode.InnerText = L.Note.ToString();
            baseNode.AppendChild(typeNode);
            baseNode.AppendChild(dateNode);
            baseNode.AppendChild(noteNode);

            if (File.Exists(fichierCible))
            {
                xmlDoc.Load(fichierCible);
                XmlNode rootNode = xmlDoc.SelectSingleNode("//Livrables");
                rootNode.AppendChild(baseNode);
            }
            else
            {
                XmlNode rootNode = xmlDoc.CreateElement("Livrables");
                xmlDoc.AppendChild(rootNode);
                rootNode.AppendChild(baseNode);
            }

            xmlDoc.Save(fichierCible);
        }

        public static void MatiereXml(string M, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode baseNode = xmlDoc.CreateElement("Matiere");
            baseNode.InnerText = M;
            
            if (File.Exists(fichierCible))
            {
                xmlDoc.Load(fichierCible);
                XmlNode rootNode = xmlDoc.SelectSingleNode("//Matieres");
                rootNode.AppendChild(baseNode);
            }
            else
            {
                XmlNode rootNode = xmlDoc.CreateElement("Matieres");
                xmlDoc.AppendChild(rootNode);
                rootNode.AppendChild(baseNode);
            }

            xmlDoc.Save(fichierCible);

        }

        public static void ProjetXml(Projet P, string fichierCible)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode baseNode = xmlDoc.CreateElement("Projet");
            XmlNode idNode = xmlDoc.CreateElement("Id");
            idNode.InnerText = P.Id.ToString();
            XmlNode nameNode = xmlDoc.CreateElement("Nom");
            nameNode.InnerText = P.Nom;
            XmlNode subjectNode = xmlDoc.CreateElement("Sujet");
            subjectNode.InnerText = P.Sujet;
            XmlNode dateStartNode = xmlDoc.CreateElement("DateDebut");
            dateStartNode.InnerText = P.DateDebut.ToString();
            XmlNode dateFinNode = xmlDoc.CreateElement("DateFin");
            dateFinNode.InnerText = P.DateFin.ToString();
            XmlNode typeNode = xmlDoc.CreateElement("Type");
            typeNode.InnerText = P.TypeProjet;
            XmlNode partiBaseNode = xmlDoc.CreateElement("Participants");
            foreach (var Parti in P.ListeParticipants)
            {
                XmlNode partiNode = xmlDoc.CreateElement("Participant");
                XmlNode partiNameNode = xmlDoc.CreateElement("Nom");
                partiNameNode.InnerText = Parti.Item1.Nom;
                XmlNode partiSurnameNode = xmlDoc.CreateElement("Prenom");
                partiSurnameNode.InnerText = Parti.Item1.Prenom;
                XmlNode partiRoleNode = xmlDoc.CreateElement("Role");
                partiRoleNode.InnerText = Parti.Item2;
                if (Object.ReferenceEquals(Parti.Item1.GetType(), typeof(Eleve)))
                {
                    Eleve E = (Eleve)Parti.Item1;
                    partiNode.Attributes.Append(xmlDoc.CreateAttribute("Eleve"));
                    XmlNode partiPromoNode = xmlDoc.CreateElement("Promotion");
                    partiPromoNode.InnerText = E.Promotion.ToString();

                    partiNode.AppendChild(partiNameNode);
                    partiNode.AppendChild(partiSurnameNode);
                    partiNode.AppendChild(partiPromoNode);
                    partiNode.AppendChild(partiRoleNode);
                }
                if (Object.ReferenceEquals(Parti.Item1.GetType(), typeof(Enseignant)))
                {
                    Enseignant E = (Enseignant)Parti.Item1;
                    partiNode.Attributes.Append(xmlDoc.CreateAttribute("Enseignant"));
                    XmlNode partiMatsNode = xmlDoc.CreateElement("Matieres");
                    foreach (string M in E.Enseignement)
                    {
                        XmlNode partiMatNode = xmlDoc.CreateElement("Matiere");
                        partiMatNode.InnerText = M;
                        partiMatsNode.AppendChild(partiMatNode);
                    }

                    partiNode.AppendChild(partiNameNode);
                    partiNode.AppendChild(partiSurnameNode);
                    partiNode.AppendChild(partiMatsNode);
                    partiNode.AppendChild(partiRoleNode);
                }
                if (Object.ReferenceEquals(Parti.Item1.GetType(), typeof(Exterieur)))
                {
                    Exterieur E = (Exterieur)Parti.Item1;
                    partiNode.Attributes.Append(xmlDoc.CreateAttribute("Exterieur"));
                    XmlNode partiCieNode = xmlDoc.CreateElement("Entreprise");
                    partiCieNode.InnerText = E.Entreprise.ToString();

                    partiNode.AppendChild(partiNameNode);
                    partiNode.AppendChild(partiSurnameNode);
                    partiNode.AppendChild(partiCieNode);
                    partiNode.AppendChild(partiRoleNode);
                }
                
                partiBaseNode.AppendChild(partiNode);
            }
            XmlNode livBaseNode = xmlDoc.CreateElement("Livrables");
            foreach (Livrable L in P.ListeLivrables)
            {
                XmlNode livNode = xmlDoc.CreateElement("Livrable");
                XmlNode livTypeNode = xmlDoc.CreateElement("Type");
                livTypeNode.InnerText = L.Type;
                XmlNode livDateNode = xmlDoc.CreateElement("Date");
                livDateNode.InnerText = L.DateRendu.ToString();
                XmlNode livNoteNode = xmlDoc.CreateElement("Note");
                livNoteNode.InnerText = L.Note.ToString();
                livNode.AppendChild(livTypeNode);
                livNode.AppendChild(livDateNode);
                livNode.AppendChild(livNoteNode);

                livBaseNode.AppendChild(livNode);
            }
            XmlNode renouvNode = xmlDoc.CreateElement("RenouvellementDe");
            renouvNode.InnerText = P.RenouvellementDe.ToString();

            XmlNode matBaseNode = xmlDoc.CreateElement("Matieres");
            foreach (string M in P.Domaine)
            {
                XmlNode matNode = xmlDoc.CreateElement("Matiere");
                matNode.InnerText = M;
                matBaseNode.AppendChild(matNode);
            }

            baseNode.AppendChild(idNode);
            baseNode.AppendChild(nameNode);
            baseNode.AppendChild(subjectNode);
            baseNode.AppendChild(dateStartNode);
            baseNode.AppendChild(dateFinNode);
            baseNode.AppendChild(typeNode);
            baseNode.AppendChild(partiBaseNode);
            baseNode.AppendChild(livBaseNode);
            baseNode.AppendChild(renouvNode);
            baseNode.AppendChild(matBaseNode);

            if (File.Exists(fichierCible))
            {
                xmlDoc.Load(fichierCible);
                XmlNode rootNode = xmlDoc.SelectSingleNode("//Projets");
                rootNode.AppendChild(baseNode);
            }
            else
            {
                XmlNode rootNode = xmlDoc.CreateElement("Projets");
                xmlDoc.AppendChild(rootNode);
                rootNode.AppendChild(baseNode);
            }

            xmlDoc.Save(fichierCible);
        }

        //Fonctions reconstruction
        public static Projet ReconstructionProjet(XmlDocument xmlDoc, XmlNode baseNode)
        {
            //Le XmlNode en entrée doit correspondre au noeud <Projet>
            XmlNode idNode = baseNode.SelectSingleNode("Id");
            int id = int.Parse(idNode.InnerText);
            XmlNode nameNode = baseNode.SelectSingleNode("Nom");
            string nom = nameNode.InnerText;
            XmlNode subjectNode = baseNode.SelectSingleNode("Sujet");
            string sujet = subjectNode.InnerText;
            XmlNode dateStartNode = baseNode.SelectSingleNode("DateDebut");
            DateTime dateStart = DateTime.Parse(dateStartNode.InnerText);
            XmlNode dateFinNode = baseNode.SelectSingleNode("DateFin");
            DateTime dateFin = DateTime.Parse(dateFinNode.InnerText);
            XmlNode typeNode = baseNode.SelectSingleNode("Type");
            string type = typeNode.InnerText;

            Projet P = new Projet(nom, sujet, dateStart, dateFin, type, id);

            //Participants
            XmlNode basePartiNode = baseNode.SelectSingleNode("Participants");
            XmlNodeList partiNodes = basePartiNode.SelectNodes("Participant");
            foreach (XmlNode partiNode in partiNodes)
            {
                XmlNode partiNameNode = partiNode.SelectSingleNode("Nom");
                string partiName = partiNameNode.InnerText;
                XmlNode partiSurnameNode = partiNode.SelectSingleNode("Prenom");
                string partiSurname = partiSurnameNode.InnerText;
                XmlNode partiRoleNode = partiNode.SelectSingleNode("Role");
                string partiRole = partiRoleNode.InnerText;
                if (partiNode.Attributes["Eleve"] != null)
                {
                    XmlNode partiPromoNode = partiNode.SelectSingleNode("Promotion");
                    int partiPromo = int.Parse(partiPromoNode.InnerText);
                    Eleve E = new Eleve(partiName, partiSurname, partiPromo);
                    P.AjoutParticipant(E, partiRole);
                }
                else if (partiNode.Attributes["Exterieur"] != null)
                {
                    XmlNode partiCieNode = partiNode.SelectSingleNode("Entreprise");
                    string partiCie = partiCieNode.InnerText;
                    Exterieur E = new Exterieur(partiName, partiSurname, partiCie);
                    P.AjoutParticipant(E, partiRole);
                }
                else if (partiNode.Attributes["Enseignant"] != null)
                {
                    Enseignant E = new Enseignant(partiName, partiSurname);
                    XmlNode partiMatsNode = partiNode.SelectSingleNode("Matieres");
                    XmlNodeList partiMatNodes = partiMatsNode.SelectNodes("Matiere");
                    foreach (XmlNode partiMatNode in partiMatNodes)
                    {                        
                        E.AjoutMatiere(partiMatNode.InnerText);
                    }
                    P.AjoutParticipant(E, partiRole);
                }
            }               
                
            

            //Livrables
            XmlNode livsNode = baseNode.SelectSingleNode("Livrables");
            XmlNodeList livNodes = livsNode.SelectNodes("Livrable");
            foreach (XmlNode livNode in livNodes)
            {
                XmlNode livTypeNode = livNode.SelectSingleNode("Type");                
                XmlNode livDateNode = livNode.SelectSingleNode("Date");
                XmlNode livNoteNode = livNode.SelectSingleNode("Note");
                Livrable L = new Livrable(DateTime.Parse(livDateNode.InnerText), livTypeNode.InnerText, int.Parse(livNoteNode.InnerText));
                P.AjoutLivrable(L);
            }

            //Matieres
            XmlNode matsNode = baseNode.SelectSingleNode("Matieres");
            XmlNodeList matNodes = matsNode.SelectNodes("Matiere");
            foreach (XmlNode matNode in matNodes)
            {                
                P.AjoutMatiere(matNode.InnerText);
            }

            //Renouvellement
            XmlNode renewNode = baseNode.SelectSingleNode("RenouvellementDe");
            P.SuiteDe(int.Parse(renewNode.InnerText));

            return P;
        }
        public static Eleve ReconstructionEleve(XmlDocument xmlDoc, XmlNode baseNode)
        {
            //Le XmlNode en entrée doit correspondre au noeud <Eleve>
            XmlNode idNode = baseNode.SelectSingleNode("Id");
            int id = int.Parse(idNode.InnerText);
            XmlNode nameNode = baseNode.SelectSingleNode("Nom");
            string nom = nameNode.InnerText;
            XmlNode surnameNode = baseNode.SelectSingleNode("Prenom");
            string surname = surnameNode.InnerText;
            XmlNode promoNode = baseNode.SelectSingleNode("Promotion");
            int promo = int.Parse(promoNode.InnerText);

            Eleve E = new Eleve(nom, surname, promo, id);
            return E;
        }
        public static Exterieur ReconstructionExterieur(XmlDocument xmlDoc, XmlNode baseNode)
        {
            //Le XmlNode en entrée doit correspondre au noeud <Exterieur>
            XmlNode idNode = baseNode.SelectSingleNode("Id");
            int id = int.Parse(idNode.InnerText);
            XmlNode nameNode = baseNode.SelectSingleNode("Nom");
            string nom = nameNode.InnerText;
            XmlNode surnameNode = baseNode.SelectSingleNode("Prenom");
            string surname = surnameNode.InnerText;
            XmlNode cieNode = baseNode.SelectSingleNode("Entreprise");
            string cie = cieNode.InnerText;

            Exterieur E = new Exterieur(nom, surname, cie, id);
            return E;
        }
        public static Enseignant ReconstructionEnseignant(XmlDocument xmlDoc, XmlNode baseNode)
        {
            //Le XmlNode en entrée doit correspondre au noeud <Enseignant>
            XmlNode idNode = baseNode.SelectSingleNode("Id");
            int id = int.Parse(idNode.InnerText);
            XmlNode nameNode = baseNode.SelectSingleNode("Nom");
            string nom = nameNode.InnerText;
            XmlNode surnameNode = baseNode.SelectSingleNode("Prenom");
            string surname = surnameNode.InnerText;
            Enseignant E = new Enseignant(nom, surname, id);
            XmlNode matsNode = baseNode.SelectSingleNode("Matieres");
            XmlNodeList matNodes = matsNode.SelectNodes("Matiere");
            foreach (XmlNode matNode in matNodes)
            {
                E.AjoutMatiere(matNode.InnerText);
            }
                        
            return E;
        }
        //Fonction Maj
        public static void MajProjetXml(string fichierCible, Projet P)
        {            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNode rootNode = xmlDoc.DocumentElement;
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode idNode = singleNode.SelectSingleNode("Id");
                if (idNode.InnerText == P.Id.ToString())
                {
                    rootNode.RemoveChild(singleNode);
                }
            }                   
            
            xmlDoc.Save(fichierCible);
            ProjetXml(P, fichierCible);
        }
        //Fonctions Suppression
        public static void SupprProjet(string fichierCible, Projet P)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNode rootNode = xmlDoc.DocumentElement;
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Projets/Projet");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode idNode = singleNode.SelectSingleNode("Id");
                if (idNode.InnerText == P.Id.ToString())
                {
                    rootNode.RemoveChild(singleNode);
                }
            }

            xmlDoc.Save(fichierCible);

        }
        public static void SupprMatiere(string fichierCible, string mat)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNode rootNode = xmlDoc.DocumentElement;
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Matieres/Matiere");
            foreach (XmlNode singleNode in baseNodes)
            {                
                if (singleNode.InnerText == mat)
                {
                    rootNode.RemoveChild(singleNode);
                }
            }

            xmlDoc.Save(fichierCible);
        }
        public static void SupprEleve(string fichierCible, Eleve E)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNode rootNode = xmlDoc.DocumentElement;
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Personnes/Eleve");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode nameNode = singleNode.SelectSingleNode("Nom");
                XmlNode surnameNode = singleNode.SelectSingleNode("Prenom");
                XmlNode promoNode = singleNode.SelectSingleNode("Promo");
                if (nameNode.InnerText == E.Nom && surnameNode.InnerText == E.Prenom && promoNode.InnerText == E.Promotion.ToString())
                {
                    rootNode.RemoveChild(singleNode);
                }
            }
            xmlDoc.Save(fichierCible);
        }
        public static void SupprExterieur(string fichierCible, Exterieur E)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNode rootNode = xmlDoc.DocumentElement;
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Personnes/Exterieur");
            foreach (XmlNode singleNode in baseNodes)
            {
                XmlNode nameNode = singleNode.SelectSingleNode("Nom");
                XmlNode surnameNode = singleNode.SelectSingleNode("Prenom");
                XmlNode promoNode = singleNode.SelectSingleNode("Entreprise");
                if (nameNode.InnerText == E.Nom && surnameNode.InnerText == E.Prenom && promoNode.InnerText == E.Entreprise)
                {
                    rootNode.RemoveChild(singleNode);
                }
            }
            xmlDoc.Save(fichierCible);
        }
        public static void SupprEnseignant(string fichierCible, Enseignant E)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichierCible);
            XmlNode rootNode = xmlDoc.DocumentElement;
            XmlNodeList baseNodes = xmlDoc.SelectNodes("//Personnes/Enseignant");
            bool equal = false;
            foreach (XmlNode singleNode in baseNodes)
            {
                equal = true;
                XmlNode nameNode = singleNode.SelectSingleNode("Nom");
                XmlNode surnameNode = singleNode.SelectSingleNode("Prenom");
                XmlNodeList matNodes = singleNode.SelectNodes("Matieres");
                if (nameNode.InnerText == E.Nom && surnameNode.InnerText == E.Prenom)
                {
                    foreach (XmlNode matNode in matNodes)
                    {
                        if (E.Enseignement.Contains(matNode.InnerText) == false)
                            equal = false;
                    }

                    if(equal)
                        rootNode.RemoveChild(singleNode);
                }
            }
            xmlDoc.Save(fichierCible);
        }

    }
}
