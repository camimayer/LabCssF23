using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace project1
{
    class Program
    {
        // declaration des variables
        static List<int> ids = new List<int> { 0001, 0002, 0003, 0004, 0005 };
        static List<string> utilisateurs = new List<string> { "Flavio", "Camila", "Samir", "Maria", "Eve" };
        static  List<string> idsProduits = new List<string> { "A1", "A2", "B1", "B2", "B3", "L1", "L2", "L3" };
        static List<string> nameProduits = new List<string> { "Crayons", "Cahier Canada", "Table pliante", "Fauteuil en cuir", "Bureau d'étudiant", "Laptop ASUS", "Laptop HP", "Laptop Acer" };
        static List<double> prixProduits = new List<double> { 3.99, 1.59, 66.99, 199.99, 118.99, 600.89, 700.89, 250.99 };
        
        static List<string> choixProduitsUser = new List<string>();
        

        static void EncontreUsuario() {
            int id;
            Boolean userTrouve = false;

            while (userTrouve == false)
            {
                Console.WriteLine("Veuillez vous identifier : ");
                id = int.Parse(Console.ReadLine());

                for (int i = 0; i < ids.Count; i++)
                {
                    if (id == ids[i])
                    {
                        Console.WriteLine("Bonjour, " + utilisateurs[i]);
                        userTrouve = true;
                        Console.ReadKey();
                    }
                }

                if (userTrouve == false)
                {
                    Console.WriteLine("ERREUR: Numéro d'employé invalide");
                }
             }
         }

        static void Menu()
        {
            string choix = "1";

            while (choix != "9")
            {
                    Console.Clear();
                    Console.WriteLine("*************************");
                    Console.WriteLine("      MENU PRINCIPAL");
                    Console.WriteLine("*************************");
                    Console.WriteLine("1. Ajouter un article  ");
                    Console.WriteLine("2. Supprimer un article ");
                    Console.WriteLine("3. Afficher le panier ");
                    Console.WriteLine("0. Payer ");
                    Console.WriteLine("9. Quitter le programme");
                    Console.Write("Votre choix: ");

                    choix = Console.ReadLine();

                    switch (choix)
                    {
                        case "1": Ajoute(); break;
                        case "2": Supprime(); break;
                        case "3": Afficher(); ; break;
                        case "0": Paiement(); break;
                        case "9":
                            Console.Write("Appuyez sur une touche du clavier pour quitter le program");
                            Console.ReadKey(); break;
                        default:
                            Console.WriteLine("Choix invalide...");
                            Console.ReadKey(); break;
                    }
            }
        }

        static void Ajoute()
        {
            string choix;
            Console.Clear();
            Console.WriteLine("*************************");
            Console.WriteLine("      AJOUTE ARTICLE");
            Console.WriteLine("*************************");

           for (int i = 0; i < idsProduits.Count; i++)
            {
                Console.WriteLine(idsProduits[i] + ": " + nameProduits[i] + " - " + prixProduits[i] + "$");
            }
            Console.Write("Votre choix: ");
            choix = Console.ReadLine();

            while (choix != "A1" && choix != "A2" && choix != "B1" && choix != "B2" && choix != "B3" && choix != "L1" && choix != "L2" && choix != "L3")
            {
                Console.Write("Choix invalide... Votre choix: ");
                choix = Console.ReadLine();
            }

            choixProduitsUser.Add(choix);
            Console.Clear();
            Menu();
        }

        static void Afficher()
        {
            Console.Clear();
            Console.WriteLine("\n*************************");
            Console.WriteLine("      VOTRE PANIER");
            Console.WriteLine("*************************");

            if (choixProduitsUser.Count != 0)
            {
                for (int i = 0; i < choixProduitsUser.Count; i++)
                {
                    int index = idsProduits.IndexOf(choixProduitsUser[i]);

                    Console.WriteLine(idsProduits[index] + ": " + nameProduits[index] + " - " + prixProduits[index] + "$");
                }
            }
            else
            {
                Console.WriteLine("  Votre panier est vide");
                Console.WriteLine("*************************");
            }
            Console.Write("\nAppuyez sur une touche du clavier pour aller au Menu Principal");
            Console.ReadKey();
            Menu();
        }

        static void Supprime()
        {
            string choix = "";

            while (choix != "R1")
            {
                Console.Clear();
                Console.WriteLine("*************************");
                Console.WriteLine("     RETIRER ARTICLE");
                Console.WriteLine("*************************");

                if (choixProduitsUser.Count != 0)
                {
                    for (int j = 0; j < choixProduitsUser.Count; j++)
                    {
                        int index = idsProduits.IndexOf(choixProduitsUser[j]);
                        Console.WriteLine(idsProduits[index] + ": " + nameProduits[index] + " - " + prixProduits[index] + "$");
                    }

                    Console.Write("Entrez le code produit ou R1 pour revenir au menu principal : ");
                    choix = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("  Votre panier est vide");
                    Console.WriteLine("*************************");
                    choix = "R1";
                }

                if (choix == "R1")
                {
                    Console.Write("\nAppuyez sur une touche du clavier pour aller au Menu Principal");
                }
                else
                {
                    for (int i = 0; i < choixProduitsUser.Count; i++)
                    {
                        if (choix == choixProduitsUser[i])
                        {
                            choixProduitsUser.Remove(choix);
                            Console.WriteLine("Article supprimé avec succès !!!");
                            i = choixProduitsUser.Count;
                        }
                        else
                        {
                            if (i == (choixProduitsUser.Count - 1))
                            {
                                Console.WriteLine("Choix invalide...");
                            }
                        }
                    }
                }
                Console.ReadKey();
                
            }
            Menu();
        }
        
        static void Paiement()
        {
            const double tps = 5.0, tvq = 9.975, rabais = 25;
            double stotal = 0.0, total = 0.0, vtps = 0.0, vtvq = 0.0, vrabais=0.0;
            Console.Clear();
            Console.WriteLine("******************************");
            Console.WriteLine("**          FACTURE         **");
            Console.WriteLine("******************************");

            if (choixProduitsUser.Count != 0)
            {
                for (int i = 0; i < choixProduitsUser.Count; i++)
                {
                    int index = idsProduits.IndexOf(choixProduitsUser[i]);
                    Console.WriteLine(idsProduits[index] + ": " + nameProduits[index] + " - " + prixProduits[index] + "$");
                    stotal += prixProduits[index];
                    vrabais += prixProduits[index] * rabais / 100;
                }
                stotal -= vrabais;
                vtps = stotal * tps / 100;
                vtvq = stotal * tvq / 100;
                total = stotal + vtps + vtvq;
                Console.WriteLine("    Rabais mystère : " + vrabais + "$");
                Console.WriteLine("------------------------------");
                Console.WriteLine("         Sous-total: " + stotal + "$");
                Console.WriteLine("                TPS: " + vtps + "$");
                Console.WriteLine("                TVQ: " + vtvq + "$");
                Console.WriteLine("              TOTAL: " + total + "$");
                Console.WriteLine("******************************");
                Console.WriteLine("Vous avez été servi par "); 
                Console.WriteLine("Date  : " + DateTime.Now.ToString("yyyy-MM-dd"));
                Console.WriteLine("Heure : " + DateTime.Now.ToString("HH:mm:ss"));
                Console.WriteLine("******************************");

            }
            else
            {
                Console.WriteLine("     Votre panier est vide    ");
                Console.WriteLine("******************************");
            }


            Console.Write("\nAppuyez sur une touche du clavier pour aller au Menu Principal");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        static void Main(string[] args)
        {
           
            EncontreUsuario();
            Menu();

        }
        
    }

}

