using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex
{
    class Pokedex
    {
        static private List<string> types; 

        public static void PokedexAll(List<List<Pokemon>> genList) //Affichage de tout le pokédex avec toute les informations  concernant les Pokemon
        {
            foreach (List<Pokemon> list in genList)
            {
                foreach (Pokemon poke in list)
                {
                    Console.WriteLine("__________________");
                    Console.WriteLine($"ID : {poke.id} \nNom : {poke.name.fr}\nType : {poke.types[0]}");
                }
            }
        }




        public static void PoidsMoyen(List<List<Pokemon>> genList, String type) //Calcul la moyenne de poids d'un type de Pokemon précis 
        {
            Console.Clear();
            Console.Write($"Voici le poid moyen de ce type de Pokemon {type} : ");
            int totalWeight = 0;
            int nbPoke = 0;
            foreach (List<Pokemon> gen in genList)
            {
                foreach (Pokemon poke in gen)
                {
                    if (poke.types.Contains(type))
                    {
                        totalWeight += poke.weight;
                        nbPoke++;
                    }
                }
            }
            Console.Write($"{totalWeight / nbPoke} kg");
        }


        public static string PokeType() //Permet à l'utilisateur de choisir un Pokemon précis selon son type 
        {
            do
            {
                Console.Write("Liste des types :\n");
                int i = 1;
                foreach (string type in types)
                {
                    Console.Write($"{i} - {type}\n");
                    i++;
                }
                string choice = Console.ReadLine();
                foreach (string type in types)
                    switch (choice)
                    {
                        case "1": return types[0];
                        case "2": return types[1];
                        case "3": return types[2];
                        case "4": return types[3];
                        case "5": return types[4];
                        case "6": return types[5];
                        case "7": return types[6];
                        case "8": return types[7];
                        case "9": return types[8];
                        case "10": return types[9];
                        case "11": return types[10];
                        case "12": return types[11];
                        case "13": return types[12];
                        case "14": return types[13];
                        case "15": return types[14];
                        case "16": return types[15];
                        case "17": return types[16];
                        case "18": return types[17];
                        default: break;
                    }
                Console.Clear();
            } while (true);
        }

        public static void AfficheParGéneration(List<Pokemon> pokeList) //Affichage des Pokemon par type de génération
        {
            foreach (Pokemon poke in pokeList)
            {
                Console.WriteLine("__________________");
                Console.WriteLine($"ID : {poke.id} \nNom : {poke.name.fr}");
            }
        }

        public static void AfficheParType(List<List<Pokemon>> genList, String type) //Affichage de tous les Pokémon d'un type choisi
        {
            Console.Clear();
            int nbPokeType = 0;
            Console.WriteLine($"Voici les Pokémon de tout les types {type}");
            foreach (List<Pokemon> list in genList)
            {
                foreach (Pokemon poke in list)
                {
                    if (poke.types.Contains(type))
                    {
                        Console.WriteLine("__________________");
                        Console.WriteLine($"ID : {poke.id} \nNom : {poke.name.fr}");
                        nbPokeType++;
                    }
                }
            }
        }

        internal static void AfficheParGéneration(List<List<Pokemon>> pokedex)
        {
            throw new NotImplementedException();
        }

        internal static void AfficheParType(List<List<Pokemon>> pokedex)
        {
            throw new NotImplementedException();
        }

        public static List<string> GenListType(List<List<Pokemon>> genList) //Génerer la liste des types en rapport avec tous les types dans le pokédex
        {
            List<string> types = new List<string>();
            foreach (List<Pokemon> gen in genList)
            {
                foreach (Pokemon poke in gen)
                {
                    if (!types.Contains(Convert.ToString(poke.types[0])))
                    {
                        types.Add(Convert.ToString(poke.types[0]));
                    }
                }
            }
            return types;
        }

        public static void AfficheTypeParGen(List<List<Pokemon>> genList) //Affiche un Pokemon de tout les types pour chaque génération
        {
            List<string> types = new List<string>();
            int i = 1;
            foreach (List<Pokemon> gen in genList)
            {
                Console.WriteLine($"________Génération {i}________");
                types.Clear();
                foreach (Pokemon poke in gen)
                {
                    if (!types.Contains(Convert.ToString(poke.types[0])))
                    {
                        types.Add(Convert.ToString(poke.types[0]));
                        Console.WriteLine("__________________");
                        Console.WriteLine($"ID : {poke.id} \nNom : {poke.name.fr}\nType : {Convert.ToString(poke.types[0])}\n");
                    }
                }
                i++;
            }
        }

        static public void setTypes(List<List<Pokemon>> genList) //Setter de la liste de type afin de pouvoir l'instancier dans le programme principal
        {
            types = GenListType(genList);
        }
    }
}