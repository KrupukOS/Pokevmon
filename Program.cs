﻿using System;
using System.Collections.Generic;

namespace Pokevmon
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw draw = new Draw();
            Pokedex pokedex = new Pokedex();
            Pokanics pokanics = new Pokanics();
            List<Pokemon> list = pokedex.Party;
            string input = "";
            int WildLvlMin = 2;
            int WildLvlMax = 6;

            //pokedex.Party[0] == pikachu
            pokanics.Heal(list[0]);

            //-------------GAME-LOOP-------------//
            while (input != "exit" && input != "q")
            {
                //draw menu and returns input
                input = draw.Menu("SELECTION SCREEN\n1.pokemon\n2.pokebox\n3.pokedex\n4.pokebag\n5.pokecenter\n6.battle\nq.exit");
                //show pokemon party
                if (input == "pokemon" || input == "1")
                    input = draw.ScrollMenu(input, pokedex.Party, true);
                //show pokemon storage
                else if (input == "pokebox" || input == "2")
                    input = draw.ScrollMenu(input, pokedex.Caught, false);
                //show all pokemon available in the program
                else if (input == "pokedex" || input == "3")
                    input = draw.ScrollMenu(input, pokedex.Wild, false);
                //show items
                else if (input == "pokebag" || input == "4")
                    input = draw.Menu("ERROR: looks like this part hasn't been coded yet!");
                //go to the pokemoncenter to heal your pokemon
                else if (input == "pokecenter" || input == "5")
                    pokanics.Pokecenter(pokedex);
                //battle random pokemon with random levels between 1 and 5
                else if (input == "battle" || input == "6")
                {
                    int randomLvl = Random(WildLvlMin, WildLvlMax);
                    int randomPk = Random(0, pokedex.Wild.Count);
                    pokedex.Wild[randomPk].Level = randomLvl;
                    pokanics.Heal(pokedex.Wild[randomPk]);
                    pokanics.Battle(pokedex.Party[0], pokedex.Wild[randomPk], pokedex);
                }
            }
        }
        //integer randomizer 
        public static int Random(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }
    }
}
//VERSION 1.0 (creation)
//menu loop added
//pokemon class with stats and UI possibilities
//pokedex (list of all pokemon)
//battle and healing system
//level and exp system

//VERSION 1.1 (fixes)
//seperate class for drawing UI
//merged attack and sp.attack method
//merged front and back sprite method
//pokedex now shows basestats instead of fullstats
//average basestats problem resolved
//reworked constructors

//VERSION 1.2 (fixes)
//pokemon can't reach higher levels than 100
//pokemon can't receive exp anymore after lvl100
//pokemon will keep their hp percentage upon leveling
//pokedex now uses pages to navigate
//improved experience formula for leveling

//VERSION 2 (catch em all)
//ability to catch pokemon :)
//wild and caught pokemon are stored in a seperate class (Pokedex)
//mechanics like receivedmg, healing, lvling... are now stored in a seperate class (Pokanics)
//pokedex now scrolls in segments (combined pages and scrolling)

//VERSION 2.1 (fixes)
//pokecenter now heals all your pokemons instead of just one
//implemented a chance formula for catching pokemon
//party and storage for pokemon are now seperate
//added a menu and scrollmenu method to reduce code


//TO DO'S
//different moves (physical/special) -> class
//move versus type effectiveness -> give pokemons arrays for types and moves
//natures
//evolution






/*
        else if (input == "heal" || input == "1")
        pokanics.DrinkPotion(pokedex.Party[0]);

    else if (input == "rest" || input == "2")
        pokanics.Heal(pokedex.Party[0]);

    else if (input == "level" || input == "3")
        pokanics.EatRareCandy(pokedex.Party[0]);
*/
//how to get items? find/buy? -> pokemart + money system, then again how to get money? trainers?
