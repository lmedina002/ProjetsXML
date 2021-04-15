using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace ProjetProgAvancee
{
    class Interaction
    {
        public static void Introduction()
        {
            string fichierProjet = "Projets.xml";            
            Console.WriteLine("Bonjour,");
            Console.WriteLine("Bienvenue dans le catalogue de projet de l'ENSC");
            int rep = 0;
            bool exception;
            do { 
                Console.WriteLine("La navigation dans le catalogue se fait en saisissant le chiffre situé devant l'interaction que vous souhaitez sélectionner.");
                Console.WriteLine("Que souhaitez vous-faire ?");
                Console.WriteLine("1 - Afficher tous les projets");
                Console.WriteLine("2 - Parcourir les projets par personnes");
                Console.WriteLine("3 - Parcourir les projets par matières");
                Console.WriteLine("4 - Rechercher un projet");
                Console.WriteLine("5 - Ajouter un nouveau projet");
                Console.WriteLine("6 - Modifier un projet existant");
                Console.WriteLine("7 - Quitter");

                try
                {
                    rep = int.Parse(Console.ReadLine());
                    exception = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Saisie incorrecte");
                    exception = true;
                }


                if ((rep < 1 || rep > 7) && exception == false)
                {
                    Console.WriteLine("Saisie incorrecte");
                }
            } while (rep < 1 || rep > 7 || exception==true);

            switch (rep)
            {
                case 1:
                    AfficherAllProjet();
                    break;
                case 2:
                    AfficherAllPersonne();
                    break;
                case 3:
                    AfficherAllMatiere();
                    break;
                case 4:
                    MenuRecherche();
                    break;
                case 5:
                    AjoutProjet();
                    break;
                case 6:
                    MenuRechercheModif();
                    break;
                case 7:
                    Fin();
                    break;
                default:
                    Introduction();
                    break;
                    
            }

        }

        public static void MenuRecherche()
        {
            int rep = 0;
            bool exception;
            do
            {
                Console.WriteLine("Veuillez sélectionner le critère selon lequel vous souhaitez réaliser votre recherche");
                Console.WriteLine("1 - Nom du projet");
                Console.WriteLine("2 - Nom d'un participant");
                try
                {
                    rep = int.Parse(Console.ReadLine());
                    exception = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Saisie incorrecte");
                    exception = true;
                }


                if ((rep < 1 || rep > 2) && exception == false)
                {
                    Console.WriteLine("Saisie incorrecte");
                }
            } while (rep< 1 || rep> 2 || exception==true);

            switch(rep)
            {
                case 1:
                    RechercheNomProjet();
                    break;
                case 2:
                    RechercheNomParticipant();
                    break;
                default:
                    MenuRecherche();
                    break;
            }

        }
        public static void RechercheNomProjet()
        {
            string fichierProjet = "Projets.xml";
            Console.WriteLine("Veuillez saisir le nom (ou un partie du nom) du projet recherché");
            string nom = Console.ReadLine();
            List<Projet> listRes = Recherche.RechercheProjetNom(nom, fichierProjet);
            int rep = 0;
            bool exception = false;
            if (listRes.Count == 0)
            {
                Console.WriteLine("Aucun résultats trouvés.");
                do
                {
                    Console.WriteLine("Que souhaitez-vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Ajouter un nouveau projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        AjoutProjet();
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }

            }
            else if(listRes.Count == 1)
            {
                Console.WriteLine("1 résultat trouvé");
                Console.WriteLine(listRes[0]);
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[0]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0} résultats trouvés", listRes.Count);
                int i = 1;
                foreach (Projet P in listRes)
                {
                    Console.WriteLine("{0} - {1}", i, P);
                    i += 1;
                }
                Console.WriteLine("----------------------------------------------");               
                do
                {
                    Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                    Console.WriteLine("Sinon saisir:");
                    Console.WriteLine("A pour retourner à l'accueil");
                    Console.WriteLine("B pour réaliser une nouvelle recherche");
                    Console.WriteLine("C pour quitter");
                    string choix = Console.ReadLine();
                    if (choix.ToLower() == "a")
                        Introduction();
                    else if (choix.ToLower() == "b")
                        MenuRecherche();
                    else if (choix.ToLower() == "c")
                        Fin();
                    else
                    {
                        try
                        {
                            rep = int.Parse(choix);
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    }
                } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                Console.Clear();
                Console.WriteLine(listRes[rep-1]);
                int rep2 = 0;                
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep2 = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep2 < 1 || rep2 > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep2 < 1 || rep2 > 4 || exception == true);

                switch (rep2)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[rep-1]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }
            }
        }
        public static void RechercheNomParticipant()
        {
            string fichierProjet = "Projets.xml";
            Console.WriteLine("Veuillez saisir le nom du participant recherché");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le prénom du participant recherché");
            string prenom = Console.ReadLine();
            List<Projet> listRes = Recherche.RechercheProjetParticipant(nom, prenom,fichierProjet);
            int rep = 0;
            bool exception = false;
            if (listRes.Count == 0)
            {
                Console.WriteLine("Aucun résultats trouvés.");
                do
                {
                    Console.WriteLine("Que souhaitez-vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Ajouter un nouveau projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        AjoutProjet();
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }

            }
            else if (listRes.Count == 1)
            {
                Console.WriteLine("1 résultat trouvé");
                Console.WriteLine(listRes[0]);
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[0]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0} résultats trouvés", listRes.Count);
                int i = 1;
                foreach (Projet P in listRes)
                {
                    Console.WriteLine("{0} - {1}", i, P);
                    i += 1;
                }
                Console.WriteLine("----------------------------------------------");
                do
                {
                    Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                    Console.WriteLine("Sinon saisir:");
                    Console.WriteLine("A pour retourner à l'accueil");
                    Console.WriteLine("B pour réaliser une nouvelle recherche");
                    Console.WriteLine("C pour quitter");
                    string choix = Console.ReadLine();
                    if (choix.ToLower() == "a")
                        Introduction();
                    else if (choix.ToLower() == "b")
                        MenuRecherche();
                    else if (choix.ToLower() == "c")
                        Fin();
                    else
                    {
                        try
                        {
                            rep = int.Parse(choix);
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    }
                } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                Console.Clear();
                Console.WriteLine(listRes[rep-1]);
                int rep2 = 0;
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep2 = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep2 < 1 || rep2 > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep2 < 1 || rep2 > 4 || exception == true);

                switch (rep2)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[rep-1]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomParticipant();
                        break;
                }
            }
        }
        public static void RechercheNomMatiere()
        {
            string fichierProjet = "Projets.xml";
            Console.WriteLine("Veuillez saisir le nom de la matière recherchée");
            string nom = Console.ReadLine();
            List<Projet> listRes = Recherche.RechercheProjetMatiere(nom, fichierProjet);
            int rep = 0;
            bool exception = false;
            if (listRes.Count == 0)
            {
                Console.WriteLine("Aucun résultats trouvés.");
                do
                {
                    Console.WriteLine("Que souhaitez-vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Ajouter un nouveau projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        AjoutProjet();
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomMatiere();
                        break;
                }

            }
            else if (listRes.Count == 1)
            {
                Console.WriteLine("1 résultat trouvé");
                Console.WriteLine(listRes[0]);
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[0]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomMatiere();
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0} résultats trouvés", listRes.Count);
                int i = 1;
                foreach (Projet P in listRes)
                {
                    Console.WriteLine("{0} - {1}", i, P);
                    i += 1;
                }
                Console.WriteLine("----------------------------------------------");
                do
                {
                    Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                    Console.WriteLine("Sinon saisir:");
                    Console.WriteLine("A pour retourner à l'accueil");
                    Console.WriteLine("B pour réaliser une nouvelle recherche");
                    Console.WriteLine("C pour quitter");
                    string choix = Console.ReadLine();
                    if (choix.ToLower() == "a")
                        Introduction();
                    else if (choix.ToLower() == "b")
                        MenuRecherche();
                    else if (choix.ToLower() == "c")
                        Fin();
                    else
                    {
                        try
                        {
                            rep = int.Parse(choix);
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    }
                } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                Console.Clear();
                Console.WriteLine(listRes[rep-1]);
                int rep2 = 0;
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep2 = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep2 < 1 || rep2 > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep2 < 1 || rep2 > 4 || exception == true);

                switch (rep2)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[rep-1]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomMatiere();
                        break;
                }
            }
        }
        public static void MenuRechercheModif()
        {
            Console.WriteLine("Réaliser une recherche afin de trouver le projet que vous souhaitez modifier");
            MenuRecherche();
        }
        public static void AjoutProjet()
        {
            string fichierProjet = "Projets.xml";
            string fichierPersonne = "Personnes.xml";
            string fichierMatiere = "Matieres.xml";

            //------ Récuperation identifiant dernier projet stocké ------//
            if (File.Exists(fichierProjet))
            {
                int maxProjet = Recherche.RechercheMaxIdProjet(fichierProjet);
                Projet.MajId(maxProjet + 1);
            }
            if (File.Exists(fichierPersonne))
            {
                int maxPersonne = Recherche.RechercheMaxIdPersonne(fichierPersonne);
                Personne.MajId(maxPersonne + 1);
            }
            //------------------------------------------------------------//

            Console.WriteLine("----------- Création d'un nouveau projet -----------");
            Console.WriteLine("Veuillez saisir le nom du projet");
            string name = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le sujet du projet");
            string sujet = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le type du projet");
            string type = Console.ReadLine();
            Console.WriteLine("Veuillez saisir la date de début du projet (JJ/MM/YYYY)");
            DateTime dateStart = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la date de fin du projet (JJ/MM/YYYY)");
            DateTime dateFin = DateTime.Parse(Console.ReadLine());

            Projet P = new Projet(name, sujet, dateStart, dateFin, type);

            Console.WriteLine("Ajout des participants:");
            int rep2 = 0;
            bool exception = false;
            do
            {
                int choix = 0;
                bool fail = false;
                do
                {
                    do
                    {
                        Console.WriteLine("1 - Ajouter une nouvelle personne");
                        Console.WriteLine("2 - Sélectionner une personne déjà existante dans le catalogue");                        
                        try
                        {
                            choix = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((choix < 1 || choix > 2) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    } while (choix < 1 || choix > 2 || exception == true);

                    switch (choix)
                    {
                        case 1: //Ajout personne
                            int rep = 0;
                            fail = false;
                            do
                            {
                                Console.WriteLine("Le participant est:");
                                Console.WriteLine("1 - Un élève");
                                Console.WriteLine("2 - Un enseignant");
                                Console.WriteLine("3 - Une personne extérieure à l'Ensc");
                                try
                                {
                                    rep = int.Parse(Console.ReadLine());
                                    exception = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                    exception = true;
                                }


                                if ((rep < 1 || rep > 3) && exception == false)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                }
                            } while (rep < 1 || rep > 3 || exception == true);

                            Console.WriteLine("Veuillez saisir le nom du participant");
                            string partiName = Console.ReadLine();
                            Console.WriteLine("Veuillez saisir le prenom du participant");
                            string partiSurname = Console.ReadLine();
                            Console.WriteLine("Veuillez saisir le role du participant");
                            string role = Console.ReadLine();
                            switch (rep)
                            {
                                case 1:
                                    Console.WriteLine("Veuillez saisir la promotion de l'élève");
                                    int promo = int.Parse(Console.ReadLine());
                                    Eleve El = new Eleve(partiName, partiSurname, promo);
                                    P.AjoutParticipant(El, role);
                                    if(Recherche.VerifExistenceEleve(fichierPersonne,El) == false)
                                        GestionXml.EleveXml(El, fichierPersonne);                                    
                                    break;
                                case 2:
                                    int rep5 = 0;
                                    Enseignant Es = new Enseignant(partiName, partiSurname);
                                    do
                                    {
                                        Console.WriteLine("Veuillez saisir la matière enseignée par l'enseignant");
                                        string mat = Console.ReadLine();
                                        Es.AjoutMatiere(mat);
                                        if (Recherche.VerifExistenceMatiere(fichierMatiere, mat) == false)
                                            GestionXml.MatiereXml(mat, fichierMatiere);
                                        do
                                        {
                                            Console.WriteLine("Souhaitez-vous ajouter d'autre matières ?");
                                            Console.WriteLine("1 - Oui");
                                            Console.WriteLine("2 - Non");
                                            try
                                            {
                                                rep5 = int.Parse(Console.ReadLine());
                                                exception = false;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Saisie incorrecte");
                                                exception = true;
                                            }


                                            if ((rep5 < 1 || rep5 > 2) && exception == false)
                                            {
                                                Console.WriteLine("Saisie incorrecte");
                                            }
                                        } while (rep5 < 1 || rep5 > 2 || exception == true);

                                    } while (rep5 == 1);
                                    P.AjoutParticipant(Es, role);
                                    if (Recherche.VerifExistenceEnseignant(fichierPersonne, Es) == false)
                                        GestionXml.EnseignantXml(Es, fichierPersonne);
                                    break;
                                case 3:
                                    Console.WriteLine("Veuillez saisir l'entreprise de la personne");
                                    string cie = Console.ReadLine();
                                    Exterieur Ex = new Exterieur(partiName, partiSurname, cie);
                                    P.AjoutParticipant(Ex, role);
                                    if (Recherche.VerifExistenceExterieur(fichierPersonne, Ex) == false)
                                        GestionXml.ExterieurXml(Ex, fichierPersonne);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2: //Parcourir la liste des personnes
                            List<Eleve> allEleve = Recherche.AllEleve(fichierPersonne);
                            List<Exterieur> allExterieur = Recherche.AllExterieur(fichierPersonne);
                            List<Enseignant> allEnseignant = Recherche.AllEnseignant(fichierPersonne);
                            int k = 1;
                            Console.WriteLine("\n----- Elèves -----");
                            foreach (Eleve E in allEleve)
                            {
                                Console.WriteLine("{0} - {1}", k, E);
                                k += 1;
                            }
                            Console.WriteLine("\n----- Extérieurs -----");
                            foreach (Exterieur E in allExterieur)
                            {
                                Console.WriteLine("{0} - {1}", k, E);
                                k += 1;
                            }
                            Console.WriteLine("\n----- Enseignants -----");
                            foreach (Enseignant E in allEnseignant)
                            {
                                Console.WriteLine("{0} - {1}", k, E);
                                k += 1;
                            }
                            string choixP = "";
                            int choixNum = 1;
                            do
                            {
                                Console.WriteLine("\nSaisissez le numéro associé à la personne que vous souhaitez ajouter");
                                Console.WriteLine("Si vous ne trouvez pas la personne désirée saisissez A");
                                choixP = Console.ReadLine();
                                if (choixP.ToLower() == "a")
                                {
                                    fail = true;
                                }
                                else
                                {
                                    try
                                    {
                                        choixNum = int.Parse(choixP);
                                        exception = false;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Saisie incorrecte");
                                        exception = true;
                                    }


                                    if ((choixNum < 1 || choixNum > k-1) && exception == false)
                                    {
                                        Console.WriteLine("Saisie incorrecte");
                                    }
                                }
                            } while (choixNum < 1 || choixNum > k-1 || exception == true);
                            if(fail == false)
                            {
                                Console.WriteLine("Veuillez saisir le role du participant");
                                role = Console.ReadLine();
                                if (choixNum <= allEleve.Count)
                                {
                                    P.AjoutParticipant(allEleve[choixNum - 1], role);
                                }
                                else if (choixNum > allEleve.Count && choixNum <= allEleve.Count + allExterieur.Count)
                                {
                                    P.AjoutParticipant(allExterieur[choixNum - allEleve.Count - 1], role);
                                }
                                else
                                {
                                    P.AjoutParticipant(allEnseignant[choixNum - allEleve.Count - allExterieur.Count - 1], role);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                } while (fail == true);

                do
                {
                    Console.WriteLine("Souhaitez-vous ajouter d'autres participants");
                    Console.WriteLine("1 - Oui");
                    Console.WriteLine("2 - Non");
                    try
                    {
                        rep2 = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep2 < 1 || rep2 > 2) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep2 < 1 || rep2 > 2 || exception == true);            
            } while (rep2 != 2);

            Console.WriteLine("Ajout des livrables:");
            do
            {
                Console.WriteLine("Veuillez saisir le type du livrable");
                string livType = Console.ReadLine();
                Console.WriteLine("Veuillez saisir la date de rendu du livrable (JJ/MM/YYYY)");
                DateTime livDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Veuillez saisir la note du livrable (vous pouvez saisir -1 si celui-ci n'est pas encore noté)");
                try
                {
                    int livNote = int.Parse(Console.ReadLine());                    
                    Livrable L = new Livrable(livDate, livType, livNote);
                    P.AjoutLivrable(L);
                    exception = false;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Saisie incorrecte");
                    exception = true;
                }

                do
                { 
                    Console.WriteLine("Souhaitez-vous ajouter d'autres livrables");
                    Console.WriteLine("1 - Oui");
                    Console.WriteLine("2 - Non");
                    try
                    {
                        rep2 = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }

                    if ((rep2 < 1 || rep2 > 2) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }

                } while (rep2 < 1 || rep2 > 2 || exception == true);
            
            } while (rep2 != 2);

            int choix2 = 0;
            Console.WriteLine("Ajout des matières concernées par le projet");
            do
            {
                bool fail = false;
                do
                {
                    do
                    {
                        Console.WriteLine("1 - Sélectionner une matière déjà existante dans le catalogue");
                        Console.WriteLine("2 - Ajouter une nouvelle matière");
                        try
                        {
                            choix2 = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((choix2 < 1 || choix2 > 2) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    } while (choix2 < 1 || choix2 > 2 || exception == true);

                    switch (choix2)
                    {
                        case 1: //Affichage des matieres déjà existantes
                            List<string> all = Recherche.AllMatiere(fichierMatiere);
                            int k = 1;
                            foreach (string M in all)
                            {
                                Console.WriteLine("{0} - {1}", k, M);
                                k += 1;
                            }
                            string choixM = "";
                            int choixNum2 = 1;
                            do
                            {
                                Console.WriteLine("\nSaisissez le numéro associé à la matiere que vous souhaitez ajouter");
                                Console.WriteLine("Si vous ne trouvez pas la matière désirée saisissez A");
                                choixM = Console.ReadLine();
                                if (choixM.ToLower() == "a")
                                {
                                    fail = true;
                                }
                                else
                                {
                                    try
                                    {
                                        choixNum2 = int.Parse(choixM);
                                        exception = false;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Saisie incorrecte");
                                        exception = true;
                                    }


                                    if ((choixNum2 < 1 || choixNum2 > k - 1) && exception == false)
                                    {
                                        Console.WriteLine("Saisie incorrecte");
                                    }
                                }
                            } while (choixNum2 < 1 || choixNum2 > k - 1 || exception == true);

                            if (fail == false)
                                P.AjoutMatiere(all[choixNum2 - 1]);
                            break;
                        case 2: //Ajout nouvelle matiere
                            fail = false;
                            Console.WriteLine("Saisissez le nom de la matière");
                            string mat = Console.ReadLine();
                            P.AjoutMatiere(mat);
                            if (Recherche.VerifExistenceMatiere(fichierMatiere, mat) == false)
                                GestionXml.MatiereXml(mat, fichierMatiere);
                            break;
                        default:
                            break;
                    }
                } while (fail == true);

                do
                {
                    Console.WriteLine("Souhaitez-vous ajouter d'autres matieress");
                    Console.WriteLine("1 - Oui");
                    Console.WriteLine("2 - Non");
                    try
                    {
                        rep2 = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep2 < 1 || rep2 > 2) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep2 < 1 || rep2 > 2 || exception == true);

            } while (rep2 == 1);

            int repRenew = 0;
            do
            {
                Console.WriteLine("Ce projet est-il le renouvellement d'un autre projet ?");
                Console.WriteLine("1 - Oui");
                Console.WriteLine("2 - Non");
                try
                {
                    repRenew = int.Parse(Console.ReadLine());
                    exception = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Saisie incorrecte");
                    exception = true;
                }

                if ((repRenew < 1 || repRenew > 2) && exception == false)
                {
                    Console.WriteLine("Saisie incorrecte");
                }
            } while (repRenew < 1 || repRenew > 2 || exception == true);

            if (repRenew == 1)
            {
                
                List<Projet> listRes = Recherche.AllProjet(fichierProjet);
                if (listRes.Count == 0)
                    Console.WriteLine("Aucun projet disponible");
                else
                {
                    do
                    {
                        Console.WriteLine("{0} résultats trouvés", listRes.Count);
                        Console.WriteLine("Saisissez le numéro associé au projet souhaité");
                        int i = 1;
                        foreach (Projet Pr in listRes)
                        {
                            Console.WriteLine("{0} - {1}", i, Pr);
                            i += 1;
                        }
                        try
                        {
                            rep2 = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep2 < 1 || rep2 > i-1) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    } while (rep2 < 1 || rep2 > 2 || exception == true);

                    P.SuiteDe(listRes[rep2 - 1].Id);
                }


            }

            GestionXml.ProjetXml(P, fichierProjet);

            do
            {
                Console.WriteLine("\nQue souhaitez vous faire ?");
                Console.WriteLine("1 - Retourner à l'accueil");
                Console.WriteLine("2 - Modifier ce projet");
                Console.WriteLine("3 - Quitter");
                try
                {
                    rep2 = int.Parse(Console.ReadLine());
                    exception = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Saisie incorrecte");
                    exception = true;
                }


                if ((rep2 < 1 || rep2 > 3) && exception == false)
                {
                    Console.WriteLine("Saisie incorrecte");
                }
            } while (rep2 < 1 || rep2 > 3 || exception == true);

            switch (rep2)
            {
                case 1:
                    Introduction();
                    break;
                case 2:
                    ModifProjet(P);
                    break;
                case 3:
                    Fin();
                    break;
                default:
                    AjoutProjet();
                    break;
            }

        }
        public static void ModifProjet(Projet P)
        {
            string fichierProjet = "Projets.xml";
            string fichierMatiere = "Matieres.xml";
            string fichierPersonne = "Personnes.xml";
            int rep = 0;
            bool exception;
            do
            {
                Console.WriteLine("Quel partie du projet souhaitez vous modifier ?");
                Console.WriteLine("1 - Nom");
                Console.WriteLine("2 - Sujet");
                Console.WriteLine("3 - Type de projet");
                Console.WriteLine("4 - Participants");
                Console.WriteLine("5 - Livrables");
                Console.WriteLine("6 - Date de début");
                Console.WriteLine("7 - Date de fin");
                Console.WriteLine("8 - Domaine");
                Console.WriteLine("9 - Renouvellement d'un projet");
                Console.WriteLine("10 - Supprimer le projet");
                try
                {
                    rep = int.Parse(Console.ReadLine());
                    exception = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Saisie incorrecte");
                    exception = true;
                }


                if ((rep < 1 || rep > 10) && exception == false)
                {
                    Console.WriteLine("Saisie incorrecte");
                }
            } while (rep < 1 || rep > 10 || exception == true);

            //Variables pour s'il y a eu des modifications de matières ou personnes pour ensuite mettre a jour le fichier xml
            bool matXml = false;
            bool partiXml = false;


            int suppr = 0;

            switch (rep)
            {
                case 1:
                    Console.WriteLine("Veuillez saisir le nouveau nom du projet");
                    string nom = Console.ReadLine();
                    P.Nom = nom;
                    break;
                case 2:
                    Console.WriteLine("Veuillez saisir le nouveau sujet du projet");
                    string sujet = Console.ReadLine();
                    P.Sujet = sujet;
                    break;
                case 3:
                    Console.WriteLine("Veuillez saisir le nouveau type du projet");
                    string type = Console.ReadLine();
                    P.TypeProjet = type;
                    break;
                case 4:
                    partiXml = true;
                    int k = 0;
                    int rep2 = 0;
                    foreach (var parti in P.ListeParticipants)
                    {
                        k += 1;
                        Console.WriteLine("{0} - Nom: {1}  Prenom: {2}  Role: {3}", k, parti.Item1.Nom, parti.Item1.Prenom, parti.Item2);
                    }

                    rep2 = 1;
                    bool ajout = false;
                    string choixP = "";
                    do
                    {
                        Console.WriteLine("Choisissez le participant à modifier");
                        Console.WriteLine("Ou saisissez A pour ajouter un nouveau participant");
                        choixP = Console.ReadLine();
                        if (choixP.ToLower() == "a")
                            ajout = true;
                        else
                        {
                            ajout = false;
                            try
                            {
                                rep2 = int.Parse(choixP);
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }

                            if ((rep2 < 1 || rep2 > P.ListeParticipants.Count) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        }
                    } while (rep2 < 1 || rep2 > P.ListeParticipants.Count || exception == true);

                    int rep3 = 0;

                    if (ajout)
                    {
                        int repo = 0;
                        do
                        {
                            Console.WriteLine("Le participant est:");
                            Console.WriteLine("1 - Un élève");
                            Console.WriteLine("2 - Un enseignant");
                            Console.WriteLine("3 - Une personne extérieure à l'Ensc");
                            try
                            {
                                repo = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((repo < 1 || repo > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (repo < 1 || repo > 3 || exception == true);

                        Console.WriteLine("Veuillez saisir le nom du participant");
                        string partiName = Console.ReadLine();
                        Console.WriteLine("Veuillez saisir le prenom du participant");
                        string partiSurname = Console.ReadLine();
                        Console.WriteLine("Veuillez saisir le role du participant");
                        string role = Console.ReadLine();
                        switch (repo)
                        {
                            case 1:
                                Console.WriteLine("Veuillez saisir la promotion de l'élève");
                                int promo = int.Parse(Console.ReadLine());
                                Eleve El = new Eleve(partiName, partiSurname, promo);
                                P.AjoutParticipant(El, role);
                                if (Recherche.VerifExistenceEleve(fichierPersonne, El) == false)
                                    GestionXml.EleveXml(El, fichierPersonne);
                                break;
                            case 2:
                                int rep6 = 0;
                                Enseignant Es = new Enseignant(partiName, partiSurname);
                                do
                                {
                                    Console.WriteLine("Veuillez saisir la matière enseignée par l'enseignant");
                                    string mat = Console.ReadLine();
                                    Es.AjoutMatiere(mat);
                                    do
                                    {
                                        Console.WriteLine("Souhaitez-vous ajouter d'autre matières ?");
                                        Console.WriteLine("1 - Oui");
                                        Console.WriteLine("2 - Non");
                                        try
                                        {
                                            rep6 = int.Parse(Console.ReadLine());
                                            exception = false;
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Saisie incorrecte");
                                            exception = true;
                                        }


                                        if ((rep6 < 1 || rep6 > 2) && exception == false)
                                        {
                                            Console.WriteLine("Saisie incorrecte");
                                        }
                                    } while (rep6 < 1 || rep6 > 2 || exception == true);

                                } while (rep6 == 1);
                                P.AjoutParticipant(Es, role);
                                if (Recherche.VerifExistenceEnseignant(fichierPersonne, Es) == false)
                                    GestionXml.EnseignantXml(Es, fichierPersonne);
                                break;
                            case 3:
                                Console.WriteLine("Veuillez saisir l'entreprise de la personne");
                                string cie = Console.ReadLine();
                                Exterieur Ex = new Exterieur(partiName, partiSurname, cie);
                                P.AjoutParticipant(Ex, role);
                                if (Recherche.VerifExistenceExterieur(fichierPersonne, Ex) == false)
                                    GestionXml.ExterieurXml(Ex, fichierPersonne);
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("Choisissez l'action à réaliser");
                            Console.WriteLine("1 - Modifier le nom");
                            Console.WriteLine("2 - Modifier le prenom");
                            Console.WriteLine("3 - Modifier le role");
                            Console.WriteLine("4 - Supprimer le participant");
                            try
                            {
                                rep3 = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }

                            if ((rep3 < 1 || rep3 > 4) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }

                        } while (rep3 < 1 || rep3 > 4 || exception == true);

                        switch (rep3)
                        {
                            case 1:
                                Console.WriteLine("Veuillez saisir le nouveau nom");
                                string newName = Console.ReadLine();
                                P.ListeParticipants[rep2 - 1].Item1.Nom = newName;
                                break;
                            case 2:
                                Console.WriteLine("Veuillez saisir le nouveau prenom");
                                string newSurname = Console.ReadLine();
                                P.ListeParticipants[rep2 - 1].Item1.Prenom = newSurname;
                                break;
                            case 3:
                                Console.WriteLine("Veuillez saisir le nouveau role");
                                string newRole = Console.ReadLine();
                                P.ListeParticipants[rep2 - 1] = Tuple.Create(P.ListeParticipants[rep2 - 1].Item1, newRole); //Creation d'un nouveau tuple car l'Item 2 est en lecture seule
                                break;
                            case 4:
                                P.RetraitParticipant(P.ListeParticipants[rep2 - 1].Item1);
                                Console.WriteLine("Le participant à été supprimé");
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case 5:
                    int h = 1;
                    foreach (Livrable L in P.ListeLivrables)
                    {
                        Console.WriteLine("{0} - {1}", h, L);
                        h += 1;
                    }
                    do
                    {
                        Console.WriteLine("Veuillez sélectionner le livrable à modifier");
                        try
                        {
                            rep = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }

                        if ((rep < 1 || rep > P.ListeLivrables.Count + 1) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }

                    } while (rep < 1 || rep > P.ListeLivrables.Count + 1 || exception == true);
                    rep2 = 0;
                    do
                    {
                        Console.WriteLine("Veuillez sélectionner l'action à réaliser");
                        Console.WriteLine("1 - Modifier le type du livrable");
                        Console.WriteLine("2 - Modifier la date de rendu");
                        Console.WriteLine("3 - Modifier la note");
                        try
                        {
                            rep2 = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }

                        if ((rep2 < 1 || rep2 > 3) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }

                    } while (rep2 < 1 || rep2 > 3 || exception == true);
                    
                    switch(rep2)
                    {
                        case 1:
                            Console.WriteLine("Veuillez saisir le nouveau type du livrable");
                            string newType = Console.ReadLine();
                            P.ListeLivrables[rep - 1].Type = newType;
                            break;
                        case 2:
                            Console.WriteLine("Veuillez saisir la nouvelle date de rendu (JJ/MM/YYYY)");
                            DateTime newDate = DateTime.Parse(Console.ReadLine());
                            P.ListeLivrables[rep - 1].DateRendu = newDate;
                            break;
                        case 3:
                            int rep4 = 0;
                            do
                            {
                                Console.WriteLine("Veuillez saisir la nouvelle note du livrable");
                                try
                                {
                                    rep4 = int.Parse(Console.ReadLine());
                                    exception = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                    exception = true;
                                }
                            } while (exception == true);
                            P.ListeLivrables[rep - 1].Note = rep4;
                            break;
                    }
                    break;
                case 6:
                    Console.WriteLine("Veuillez saisir la nouvelle date de début du projet (JJ/MM/YYYY)");
                    DateTime newDateStart = DateTime.Parse(Console.ReadLine());
                    P.DateDebut = newDateStart;
                    break;
                case 7:
                    Console.WriteLine("Veuillez saisir la nouvelle date de fin du projet (JJ/MM/YYYY)");
                    DateTime newDateEnd = DateTime.Parse(Console.ReadLine());
                    P.DateFin = newDateEnd;
                    break;
                case 8:
                    matXml = true;
                    Console.WriteLine("Voici la liste des matières en lien avec ce projet");
                    int j = 1;
                    foreach(string M in P.Domaine)
                    {
                        Console.WriteLine("{0} - {1}", j, M);
                        j += 1;
                    }

                    string choixM = "";
                    int choixNum = 1;
                    bool modif = false;
                    do
                    { 
                        Console.WriteLine("Saisissez le numéro associé à la matière que vous souhaitez modifier");
                        Console.WriteLine("Sinon saisissez A pour ajouter une matière");
                        choixM = Console.ReadLine();
                        if (choixM.ToLower() == "a")
                        {
                            //Ajout
                            Console.WriteLine("Saisissez le nom de la matière à ajouter");
                            string nomMat = Console.ReadLine();
                            P.AjoutMatiere(nomMat);
                            modif = false;
                        }
                        else
                        {
                            try
                            {
                                choixNum = int.Parse(choixM);
                                exception = false;
                                modif = true;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((choixNum < 1 || choixNum > j - 1) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        }
                    } while (choixNum < 1 || choixNum > j - 1 || exception == true);
                                        
                    if(modif)
                    {
                        Console.WriteLine("Saisissez le nouveau nom de la matière ou appuyer directement sur Entrée pour supprimer la matière");
                        string newMat = Console.ReadLine();
                        if (newMat == "")
                            P.RetraitMatiere(P.Domaine[choixNum - 1]);
                        else
                            P.Domaine[choixNum - 1] = newMat;
                    }                                        
                    break;
                case 9:
                    int repRenew = 0;
                    do
                    {
                        Console.WriteLine("Que souhaitez vous faire ?");
                        Console.WriteLine("1 - Annuler le renouvellement");
                        Console.WriteLine("2 - Choisir un projet");
                        try
                        {
                            repRenew = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }

                        if ((repRenew < 1 || repRenew > 2) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }

                    } while (repRenew < 1 || repRenew > 2 || exception == true);

                    if (repRenew == 1)
                        P.RenouvellementDe = -1;
                    else
                    {
                        List<Projet> listRes = Recherche.AllProjet(fichierProjet);
                        if (listRes.Count == 0)
                            Console.WriteLine("Aucun projet disponible");
                        else
                        {
                            rep2 = 1;
                            int i = 1;
                            do
                            {
                                Console.WriteLine("{0} résultats trouvés", listRes.Count);
                                Console.WriteLine("Saisissez le numéro associé au projet souhaité");
                                i = 1;
                                foreach (Projet Pr in listRes)
                                {
                                    Console.WriteLine("{0} - {1}", i, Pr);
                                    i += 1;
                                }
                                try
                                {
                                    rep2 = int.Parse(Console.ReadLine());
                                    exception = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                    exception = true;
                                }


                                if ((rep2 < 1 || rep2 > i - 1) && exception == false)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                }
                            } while (rep2 < 1 || rep2 > i - 1 || exception == true);

                            P.SuiteDe(listRes[rep2 - 1].Id);
                        }
                    }
                        break;
                case 10:
                    do
                    {                        
                        Console.WriteLine("Confirmez la suppression du projet ?");
                        Console.WriteLine("1 - Oui");
                        Console.WriteLine("2 - Non");
                        
                        try
                        {
                            suppr = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((suppr < 1 || suppr > 2) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    } while (suppr < 1 || suppr > 2 || exception == true);

                    if (suppr == 1)
                    {
                        GestionXml.SupprProjet(fichierProjet, P);
                        Console.WriteLine("Projet supprimé");
                    }

                    break;
                default:
                    break;

            }

            if(suppr != 1)
                GestionXml.MajProjetXml(fichierProjet, P);
            
            if(matXml)
            {
                //Projets.xml -> Matieres.xml
                foreach (string M in P.Domaine)
                    if (Recherche.VerifExistenceMatiere(fichierMatiere, M) == false)
                        GestionXml.MatiereXml(M, fichierMatiere);

                //Matieres.xml -> Projets.xml
                List<string> allMat = Recherche.AllMatiere(fichierMatiere);
                List<Projet> allProj = Recherche.AllProjet(fichierProjet);
                bool obs = true;
                foreach (string M in allMat)
                {
                    obs = true;
                    foreach (Projet Proj in allProj)
                    {
                        if (Proj.Domaine.Contains(M))
                            obs = false;
                    }

                    if (obs)
                        GestionXml.SupprMatiere(fichierMatiere, M);
                }
            }

            if(partiXml)
            {
                //Projets.xml -> Personnes.xml
                foreach (var Parti in P.ListeParticipants)
                {
                    if (Object.ReferenceEquals(Parti.Item1.GetType(), typeof(Eleve)))
                    {
                        if (Recherche.VerifExistenceEleve(fichierPersonne, (Eleve)Parti.Item1) == false)
                            GestionXml.EleveXml((Eleve)Parti.Item1, fichierPersonne);
                    }
                    else if (Object.ReferenceEquals(Parti.Item1.GetType(), typeof(Exterieur)))
                    {
                        if (Recherche.VerifExistenceExterieur(fichierPersonne, (Exterieur)Parti.Item1) == false)
                            GestionXml.ExterieurXml((Exterieur)Parti.Item1, fichierPersonne);
                    }
                    else if (Object.ReferenceEquals(Parti.Item1.GetType(), typeof(Enseignant)))
                    {
                        if (Recherche.VerifExistenceEnseignant(fichierPersonne, (Enseignant)Parti.Item1) == false)
                            GestionXml.EnseignantXml((Enseignant)Parti.Item1, fichierPersonne);
                    }
                }

                //Personnes.xml -> Projets.xml
                List<Eleve> allEleve = Recherche.AllEleve(fichierPersonne);
                List<Exterieur> allExterieur = Recherche.AllExterieur(fichierPersonne);
                List<Enseignant> allEnseignant = Recherche.AllEnseignant(fichierPersonne);
                List<Projet> allProj = Recherche.AllProjet(fichierProjet);
                bool obs = true;
                foreach (Eleve El in allEleve)
                {
                    obs = true;
                    foreach (Projet Proj in allProj)
                    {
                        foreach (var Partici in Proj.ListeParticipants)
                        {
                            if (Partici.Item1 == El)
                                obs = false;
                        }
                        
                    }

                    if (obs)
                        GestionXml.SupprEleve(fichierPersonne, El);
                }

                foreach (Exterieur Ex in allExterieur)
                {
                    obs = true;
                    foreach (Projet Proj in allProj)
                    {
                        foreach (var Partici in Proj.ListeParticipants)
                        {
                            if (Partici.Item1 == Ex)
                                obs = false;
                        }

                    }

                    if (obs)
                        GestionXml.SupprExterieur(fichierPersonne, Ex);
                }

                foreach (Enseignant En in allEnseignant)
                {
                    obs = true;
                    foreach (Projet Proj in allProj)
                    {
                        foreach (var Partici in Proj.ListeParticipants)
                        {
                            if (Partici.Item1 == En)
                                obs = false;
                        }

                    }

                    if (obs)
                        GestionXml.SupprEnseignant(fichierPersonne, En);
                }
            }
            
            int rep5 = 0;
            do
            {
                Console.WriteLine("\nQue souhaitez vous faire ?");
                Console.WriteLine("1 - Retourner à l'accueil");
                Console.WriteLine("2 - Modifier ce projet");
                Console.WriteLine("3 - Quitter");
                try
                {
                    rep5 = int.Parse(Console.ReadLine());
                    exception = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Saisie incorrecte");
                    exception = true;
                }


                if ((rep5 < 1 || rep5 > 3) && exception == false)
                {
                    Console.WriteLine("Saisie incorrecte");
                }
            } while (rep5 < 1 || rep5 > 3 || exception == true);

            switch (rep5)
            {
                case 1:
                    Introduction();
                    break;
                case 2:
                    ModifProjet(P);
                    break;
                case 3:
                    Fin();
                    break;
                default:
                    AjoutProjet();
                    break;
            }

        }
        public static void AfficherAllProjet()
        {
            Console.Clear();
            string fichierProjet = "Projets.xml";
            List<Projet> listRes = Recherche.AllProjet(fichierProjet);
            int rep = 0;
            bool exception = false;
            if (listRes.Count == 0)
            {
                Console.WriteLine("Aucun résultats trouvés.");
                do
                {
                    Console.WriteLine("Que souhaitez-vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Ajouter un nouveau projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        AjoutProjet();
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }

            }
            else if (listRes.Count == 1)
            {
                Console.WriteLine("1 résultat trouvé");
                Console.WriteLine(listRes[0]);
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep < 1 || rep > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep < 1 || rep > 4 || exception == true);

                switch (rep)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[0]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0} résultats trouvés", listRes.Count);
                int i = 1;
                foreach (Projet P in listRes)
                {
                    Console.WriteLine("\n{0} - {1}", i, P);
                    i += 1;
                }
                Console.WriteLine("----------------------------------------------");
                do
                {
                    Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                    Console.WriteLine("Sinon saisir:");
                    Console.WriteLine("A pour retourner à l'accueil");
                    Console.WriteLine("B pour réaliser une nouvelle recherche");
                    Console.WriteLine("C pour quitter");
                    string choix = Console.ReadLine();
                    if (choix.ToLower() == "a")
                        Introduction();
                    else if (choix.ToLower() == "b")
                        MenuRecherche();
                    else if (choix.ToLower() == "c")
                        Fin();
                    else
                    {
                        try
                        {
                            rep = int.Parse(choix);
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    }
                } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                Console.Clear();
                Console.WriteLine(listRes[rep-1]);
                int rep2 = 0;
                do
                {
                    Console.WriteLine("\nQue souhaitez vous faire ?");
                    Console.WriteLine("1 - Retourner à l'accueil");
                    Console.WriteLine("2 - Réaliser une nouvelle recherche");
                    Console.WriteLine("3 - Modifier ce projet");
                    Console.WriteLine("4 - Quitter");
                    try
                    {
                        rep2 = int.Parse(Console.ReadLine());
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((rep2 < 1 || rep2 > 4) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                } while (rep2 < 1 || rep2 > 4 || exception == true);

                switch (rep2)
                {
                    case 1:
                        Introduction();
                        break;
                    case 2:
                        MenuRecherche();
                        break;
                    case 3:
                        ModifProjet(listRes[rep-1]);
                        break;
                    case 4:
                        Fin();
                        break;
                    default:
                        RechercheNomProjet();
                        break;
                }
            }
        }
        public static void AfficherAllPersonne()
        {
            Console.Clear();
            string fichierProjet = "Projets.xml";
            string fichierPersonne = "Personnes.xml";
            List<Eleve> allEleve = Recherche.AllEleve(fichierPersonne);
            List<Exterieur> allExterieur = Recherche.AllExterieur(fichierPersonne);
            List<Enseignant> allEnseignant = Recherche.AllEnseignant(fichierPersonne);
            int k = 1;
            Console.WriteLine("\n----- Elèves -----");
            foreach (Eleve E in allEleve)
            {
                Console.WriteLine("{0} - {1}", k, E);
                k += 1;
            }
            Console.WriteLine("\n----- Extérieurs -----");
            foreach (Exterieur E in allExterieur)
            {
                Console.WriteLine("{0} - {1}", k, E);
                k += 1;
            }
            Console.WriteLine("\n----- Enseignants -----");
            foreach (Enseignant E in allEnseignant)
            {
                Console.WriteLine("{0} - {1}", k, E);
                k += 1;
            }
            string choixP = "";
            int choixNum = 2;
            bool exception = false;
            bool fail = false;
            do
            {
                Console.WriteLine("\nSaisissez le numéro associé à la personne dont vous souhaitez consulter les projets");
                Console.WriteLine("Si vous ne trouvez pas la personne désirée saisissez A");
                choixP = Console.ReadLine();
                if (choixP.ToLower() == "a")
                {
                    fail = true;
                }
                else
                {
                    try
                    {
                        choixNum = int.Parse(choixP);
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((choixNum < 1 || choixNum > k - 1) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                }
            } while (choixNum < 1 || choixNum > k - 1 || exception == true);

            if (fail == false)
            {
                if (choixNum <= allEleve.Count)
                {
                    List<Projet> listRes = Recherche.RechercheProjetParticipant(allEleve[choixNum - 1].Nom, allEleve[choixNum - 1].Prenom, fichierProjet);
                    int rep = 0;
                    exception = false;
                    if (listRes.Count == 0)
                    {
                        Console.WriteLine("Aucun résultats trouvés.");
                        do
                        {
                            Console.WriteLine("Que souhaitez-vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Ajouter un nouveau projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep < 1 || rep > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep < 1 || rep > 3 || exception == true);

                        switch (rep)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                AjoutProjet();
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }

                    }
                    else if (listRes.Count == 1)
                    {
                        Console.WriteLine("1 résultat trouvé");
                        Console.WriteLine(listRes[0]);
                        do
                        {
                            Console.WriteLine("\nQue souhaitez vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Modifier ce projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep < 1 || rep > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep < 1 || rep > 3 || exception == true);

                        switch (rep)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                ModifProjet(listRes[0]);
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} résultats trouvés", listRes.Count);
                        int i = 1;
                        foreach (Projet P in listRes)
                        {
                            Console.WriteLine("{0} - {1}", i, P);
                            i += 1;
                        }
                        Console.WriteLine("----------------------------------------------");
                        do
                        {
                            Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                            Console.WriteLine("Sinon saisir:");
                            Console.WriteLine("A pour retourner à l'accueil");
                            Console.WriteLine("B pour réaliser une nouvelle recherche");
                            Console.WriteLine("C pour quitter");
                            string choix = Console.ReadLine();
                            if (choix.ToLower() == "a")
                                Introduction();
                            else if (choix.ToLower() == "b")
                                MenuRecherche();
                            else if (choix.ToLower() == "c")
                                Fin();
                            else
                            {
                                try
                                {
                                    rep = int.Parse(choix);
                                    exception = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                    exception = true;
                                }


                                if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                }
                            }
                        } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                        Console.Clear();
                        Console.WriteLine(listRes[rep]);
                        int rep2 = 0;
                        do
                        {
                            Console.WriteLine("\nQue souhaitez vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Modifier ce projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep2 = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep2 < 1 || rep2 > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep2 < 1 || rep2 > 3 || exception == true);

                        switch (rep2)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                ModifProjet(listRes[rep]);
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }
                    }
                }
                else if (choixNum > allEleve.Count && choixNum <= allEleve.Count + allExterieur.Count)
                {
                    List<Projet> listRes = Recherche.RechercheProjetParticipant(allExterieur[choixNum - 1 - allEleve.Count].Nom, allExterieur[choixNum - 1 - allEleve.Count].Prenom, fichierProjet);
                    int rep = 0;
                    exception = false;
                    if (listRes.Count == 0)
                    {
                        Console.WriteLine("Aucun résultats trouvés.");
                        do
                        {
                            Console.WriteLine("Que souhaitez-vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Ajouter un nouveau projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep < 1 || rep > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep < 1 || rep > 3 || exception == true);

                        switch (rep)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                AjoutProjet();
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }

                    }
                    else if (listRes.Count == 1)
                    {
                        Console.WriteLine("1 résultat trouvé");
                        Console.WriteLine(listRes[0]);
                        do
                        {
                            Console.WriteLine("\nQue souhaitez vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Modifier ce projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep < 1 || rep > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep < 1 || rep > 3 || exception == true);

                        switch (rep)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                ModifProjet(listRes[0]);
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} résultats trouvés", listRes.Count);
                        int i = 1;
                        foreach (Projet P in listRes)
                        {
                            Console.WriteLine("{0} - {1}", i, P);
                            i += 1;
                        }
                        Console.WriteLine("----------------------------------------------");
                        do
                        {
                            Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                            Console.WriteLine("Sinon saisir:");
                            Console.WriteLine("A pour retourner à l'accueil");
                            Console.WriteLine("B pour réaliser une nouvelle recherche");
                            Console.WriteLine("C pour quitter");
                            string choix = Console.ReadLine();
                            if (choix.ToLower() == "a")
                                Introduction();
                            else if (choix.ToLower() == "b")
                                MenuRecherche();
                            else if (choix.ToLower() == "c")
                                Fin();
                            else
                            {
                                try
                                {
                                    rep = int.Parse(choix);
                                    exception = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                    exception = true;
                                }


                                if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                }
                            }
                        } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                        Console.Clear();
                        Console.WriteLine(listRes[rep]);
                        int rep2 = 0;
                        do
                        {
                            Console.WriteLine("\nQue souhaitez vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Modifier ce projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep2 = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep2 < 1 || rep2 > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep2 < 1 || rep2 > 3 || exception == true);

                        switch (rep2)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                ModifProjet(listRes[rep]);
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }
                    }
                }
                else
                {
                    List<Projet> listRes = Recherche.RechercheProjetParticipant(allEnseignant[choixNum - 1 - allEleve.Count - allExterieur.Count].Nom, allEleve[choixNum - 1 - allExterieur.Count - allEleve.Count].Prenom, fichierProjet);
                    int rep = 0;
                    exception = false;
                    if (listRes.Count == 0)
                    {
                        Console.WriteLine("Aucun résultats trouvés.");
                        do
                        {
                            Console.WriteLine("Que souhaitez-vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Ajouter un nouveau projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep < 1 || rep > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep < 1 || rep > 3 || exception == true);

                        switch (rep)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                AjoutProjet();
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }

                    }
                    else if (listRes.Count == 1)
                    {
                        Console.WriteLine("1 résultat trouvé");
                        Console.WriteLine(listRes[0]);
                        do
                        {
                            Console.WriteLine("\nQue souhaitez vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Modifier ce projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep < 1 || rep > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep < 1 || rep > 3 || exception == true);

                        switch (rep)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                ModifProjet(listRes[0]);
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} résultats trouvés", listRes.Count);
                        int i = 1;
                        foreach (Projet P in listRes)
                        {
                            Console.WriteLine("{0} - {1}", i, P);
                            i += 1;
                        }
                        Console.WriteLine("----------------------------------------------");
                        do
                        {
                            Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                            Console.WriteLine("Sinon saisir:");
                            Console.WriteLine("A pour retourner à l'accueil");
                            Console.WriteLine("B pour réaliser une nouvelle recherche");
                            Console.WriteLine("C pour quitter");
                            string choix = Console.ReadLine();
                            if (choix.ToLower() == "a")
                                Introduction();
                            else if (choix.ToLower() == "b")
                                MenuRecherche();
                            else if (choix.ToLower() == "c")
                                Fin();
                            else
                            {
                                try
                                {
                                    rep = int.Parse(choix);
                                    exception = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                    exception = true;
                                }


                                if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                                {
                                    Console.WriteLine("Saisie incorrecte");
                                }
                            }
                        } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                        Console.Clear();
                        Console.WriteLine(listRes[rep]);
                        int rep2 = 0;
                        do
                        {
                            Console.WriteLine("\nQue souhaitez vous faire ?");
                            Console.WriteLine("1 - Retourner à l'accueil");
                            Console.WriteLine("2 - Réaliser une nouvelle recherche");
                            Console.WriteLine("3 - Modifier ce projet");
                            Console.WriteLine("4 - Quitter");
                            try
                            {
                                rep2 = int.Parse(Console.ReadLine());
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep2 < 1 || rep2 > 3) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        } while (rep2 < 1 || rep2 > 3 || exception == true);

                        switch (rep2)
                        {
                            case 1:
                                Introduction();
                                break;
                            case 2:
                                MenuRecherche();
                                break;
                            case 3:
                                ModifProjet(listRes[rep]);
                                break;
                            case 4:
                                Fin();
                                break;
                            default:
                                RechercheNomProjet();
                                break;
                        }
                    }
                }
            }
            else
                Introduction();
        }
        public static void AfficherAllMatiere()
        {
            Console.Clear();
            string fichierProjet = "Projets.xml";
            string fichierMatiere = "Matieres.xml";
            List<string> all = Recherche.AllMatiere(fichierMatiere);
            int k = 1;
            Console.WriteLine("\n----- Matières -----");
            foreach (string M in all)
            {
                Console.WriteLine("{0} - {1}", k, M);
                k += 1;
            }
            string choixM = "";
            int choixNum = 2;
            bool exception = false;
            bool fail = false;
            do
            {
                Console.WriteLine("\nSaisissez le numéro associé à la matière dont vous souhaitez consulter les projets");
                Console.WriteLine("Si vous ne trouvez pas la personne désirée saisissez A");
                choixM = Console.ReadLine();
                if (choixM.ToLower() == "a")
                {
                    fail = true;
                }
                else
                {
                    try
                    {
                        choixNum = int.Parse(choixM);
                        exception = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Saisie incorrecte");
                        exception = true;
                    }


                    if ((choixNum < 1 || choixNum > k - 1) && exception == false)
                    {
                        Console.WriteLine("Saisie incorrecte");
                    }
                }
            } while (choixNum < 1 || choixNum > k - 1 || exception == true);

            if (fail == false)
            {
                List<Projet> listRes = Recherche.RechercheProjetMatiere(all[choixNum - 1], fichierProjet);
                int rep = 0;
                exception = false;
                if (listRes.Count == 0)
                {
                    Console.WriteLine("Aucun résultats trouvés.");
                    do
                    {
                        Console.WriteLine("Que souhaitez-vous faire ?");
                        Console.WriteLine("1 - Retourner à l'accueil");
                        Console.WriteLine("2 - Réaliser une nouvelle recherche");
                        Console.WriteLine("3 - Ajouter un nouveau projet");
                        Console.WriteLine("4 - Quitter");
                        try
                        {
                            rep = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep < 1 || rep > 3) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    } while (rep < 1 || rep > 3 || exception == true);

                    switch (rep)
                    {
                        case 1:
                            Introduction();
                            break;
                        case 2:
                            MenuRecherche();
                            break;
                        case 3:
                            AjoutProjet();
                            break;
                        case 4:
                            Fin();
                            break;
                        default:
                            RechercheNomProjet();
                            break;
                    }

                }
                else if (listRes.Count == 1)
                {
                    Console.WriteLine("1 résultat trouvé");
                    Console.WriteLine(listRes[0]);
                    do
                    {
                        Console.WriteLine("\nQue souhaitez vous faire ?");
                        Console.WriteLine("1 - Retourner à l'accueil");
                        Console.WriteLine("2 - Réaliser une nouvelle recherche");
                        Console.WriteLine("3 - Modifier ce projet");
                        Console.WriteLine("4 - Quitter");
                        try
                        {
                            rep = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep < 1 || rep > 3) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    } while (rep < 1 || rep > 3 || exception == true);

                    switch (rep)
                    {
                        case 1:
                            Introduction();
                            break;
                        case 2:
                            MenuRecherche();
                            break;
                        case 3:
                            ModifProjet(listRes[0]);
                            break;
                        case 4:
                            Fin();
                            break;
                        default:
                            RechercheNomProjet();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("{0} résultats trouvés", listRes.Count);
                    int i = 1;
                    foreach (Projet P in listRes)
                    {
                        Console.WriteLine("{0} - {1}", i, P);
                        i += 1;
                    }
                    Console.WriteLine("----------------------------------------------");
                    do
                    {
                        Console.WriteLine("Pour obtenir plus de détails sur un projet veuillez saisir le numéro associé à celui-ci.");
                        Console.WriteLine("Sinon saisir:");
                        Console.WriteLine("A pour retourner à l'accueil");
                        Console.WriteLine("B pour réaliser une nouvelle recherche");
                        Console.WriteLine("C pour quitter");
                        string choix = Console.ReadLine();
                        if (choix.ToLower() == "a")
                            Introduction();
                        else if (choix.ToLower() == "b")
                            MenuRecherche();
                        else if (choix.ToLower() == "c")
                            Fin();
                        else
                        {
                            try
                            {
                                rep = int.Parse(choix);
                                exception = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Saisie incorrecte");
                                exception = true;
                            }


                            if ((rep < 1 || rep > listRes.Count + 1) && exception == false)
                            {
                                Console.WriteLine("Saisie incorrecte");
                            }
                        }
                    } while (rep < 1 || rep > listRes.Count + 1 || exception == true);

                    Console.Clear();
                    Console.WriteLine(listRes[rep]);
                    int rep2 = 0;
                    do
                    {
                        Console.WriteLine("\nQue souhaitez vous faire ?");
                        Console.WriteLine("1 - Retourner à l'accueil");
                        Console.WriteLine("2 - Réaliser une nouvelle recherche");
                        Console.WriteLine("3 - Modifier ce projet");
                        Console.WriteLine("4 - Quitter");
                        try
                        {
                            rep2 = int.Parse(Console.ReadLine());
                            exception = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Saisie incorrecte");
                            exception = true;
                        }


                        if ((rep2 < 1 || rep2 > 3) && exception == false)
                        {
                            Console.WriteLine("Saisie incorrecte");
                        }
                    } while (rep2 < 1 || rep2 > 3 || exception == true);

                    switch (rep2)
                    {
                        case 1:
                            Introduction();
                            break;
                        case 2:
                            MenuRecherche();
                            break;
                        case 3:
                            ModifProjet(listRes[rep]);
                            break;
                        case 4:
                            Fin();
                            break;
                        default:
                            RechercheNomProjet();
                            break;
                    }
                }
            }
            else
                Introduction();
        }
        public static void Fin()
        {
            Environment.Exit(0);
        }
    }
}
