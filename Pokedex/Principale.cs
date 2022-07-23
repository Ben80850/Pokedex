using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace Pokedex
{
    class Principale
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Le Pokedex se met à jour.....");

            //Instanciation des listes de pokemon pour chaque génération
            List<Pokemon> gen1 = new List<Pokemon>();
            List<Pokemon> gen2 = new List<Pokemon>();
            List<Pokemon> gen3 = new List<Pokemon>();
            List<Pokemon> gen4 = new List<Pokemon>();
            List<Pokemon> gen5 = new List<Pokemon>();
            List<Pokemon> gen6 = new List<Pokemon>();
            List<Pokemon> gen7 = new List<Pokemon>();
            List<Pokemon> gen8 = new List<Pokemon>();

            //Création des threads correspondant à chaque génération
            Thread threadGen1 = new Thread(() => GetPokemon(1, 151, gen1));
            Thread threadGen2 = new Thread(() => GetPokemon(152, 251, gen2));
            Thread threadGen3 = new Thread(() => GetPokemon(252, 386, gen3));
            Thread threadGen4 = new Thread(() => GetPokemon(387, 493, gen4));
            Thread threadGen5 = new Thread(() => GetPokemon(494, 649, gen5));
            Thread threadGen6 = new Thread(() => GetPokemon(650, 721, gen6));
            Thread threadGen7 = new Thread(() => GetPokemon(722, 802, gen7));
            Thread threadGen8 = new Thread(() => GetPokemon(803, 898, gen8));

            //Création de la liste des threads de génération afin de refactoriser le code
            List<Thread> threads = new List<Thread>() { threadGen1, threadGen2, threadGen3, threadGen4, threadGen5, threadGen6, threadGen7, threadGen8 };

            //Lancement des threads
            foreach (Thread t in threads)
                t.Start();

            //Attente threads
            foreach (Thread t in threads)
                if (t.IsAlive)
                    t.Join();

            //Création du pokédex
            List<List<Pokemon>> pokedex = new List<List<Pokemon>>() { gen1, gen2, gen3, gen4, gen5, gen6, gen7, gen8 };


            Pokedex.setTypes(pokedex);


            do
            {
                Console.Clear();
                //Affichage du menu
                Console.Write("1 - Afficher la liste des Pokémons :" +
                    "\n\n2 - Afficher un Pokémon de chaque type pour chaque génération" +
                    "\n\n3 - Afficher tous les Pokémons d'un type selon votre choix" +
                    "\n\n4 - Afficher tous les Pokémons de la génération 3" +
                    "\n\n5 - Afficher la moyenne de poids d'un type de Pokemon choisis !" +
                    "\n\n6 - Quitter l'application" +
                    "\n\n\nVotre choix : ");

                //Récupération du choix et renvoie vers chaque méthode pour chaque étape demandée
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Pokedex.PokedexAll(pokedex);
                        break;
                    case "2":
                        Console.Clear();
                        Pokedex.AfficheTypeParGen((pokedex));
                        break;
                    case "3":
                        Console.Clear();
                        Pokedex.AfficheParType(pokedex, Pokedex.PokeType());
                        break;
                    case "4":
                        Console.Clear();
                        Pokedex.AfficheParGéneration(gen3);
                        break;
                    case "5":
                        Console.Clear();
                        Pokedex.PoidsMoyen(pokedex, Pokedex.PokeType());
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Bye");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Valeur invalide saisie ! Rentre une valeur valide ! ");
                        break;
                }
                Console.ReadLine();
            } while (true);
        }

        private static void GetPokemon(int first, int last, List<Pokemon> pokemons) //Récupération des informations concernant l'API
        {
            using (System.Net.WebClient web = new System.Net.WebClient())
            {
                for (int i = first; i <= last; i++)
                {
                    //Sérialisation du JSON
                    string jsonString = web.DownloadString($"https://tmare.ndelpech.fr/tps/pokemons/{i}");
                    pokemons.Add(JsonSerializer.Deserialize<Pokemon>(jsonString));
                }
            }
        }
    }
}