﻿using System;
using System.Collections.Generic;

namespace Pokevmon
{
    public class Draw
    {
        #region Basic
        static public void HorizontalLine(int posX, int posY, int length, char x)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write(x);
                Console.WriteLine();
            }
        }
        static public void VerticalLine(int posX, int posY, int length, char x)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.Write(x);
                Console.WriteLine();
            }
        }
        static public void Border(int posX1, int posY1, int posX2, int posY2, char x)
        {
            HorizontalLine(posX1, posY1, posX2 - posX1, x);
            VerticalLine(posX1, posY1, posY2 - posY1 + 1, x);
            VerticalLine(posX2, posY1, posY2 - posY1 + 1, x);
            HorizontalLine(posX1, posY2, posX2 - posX1, x);
        }
        #endregion

        #region Pokemon
        private static int size = 17; //increase size if more data is needed during display
        private void FullStat(int Full, char x, int pos, int nr)
        {
            Console.SetCursorPosition(8, 5 + size * nr + pos);
            Console.Write(Full);
            for (int i = 0; i < Full / 2; i++)
            {
                Console.SetCursorPosition(12 + i, 5 + size * nr + pos);
                Console.Write(x);
            }
        }
        private void CurrentStat(int Current, char x, int pos, int nr)
        {
            Console.SetCursorPosition(4, 5 + size * nr + pos);
            Console.Write(Current + "/");
            for (int i = 0; i < Current / 2; i++)
            {
                Console.SetCursorPosition(12 + i, 5 + size * nr + pos);
                Console.Write(x);
            }
        }
        public void Stats(Pokemon pokemon, int layer)
        {
            HorizontalLine(0, size * layer, 26, '-');
            if (pokemon.Type[1] == Element.None)
                Console.WriteLine($"{pokemon.Name} lvl.{pokemon.Level}\n{pokemon.Type[0]} Type\n\n\nExp to lvl:\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\n\nTotal Basestats: {pokemon.TotalBase}\nAverage Basestats: {pokemon.AverageBase}");
            else
                Console.WriteLine($"{pokemon.Name} lvl.{pokemon.Level}\n{pokemon.Type[0]} & {pokemon.Type[1]}\n\n\nExp to lvl:\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\n\nTotal Basestats: {pokemon.TotalBase}\nAverage Basestats: {pokemon.AverageBase}");

            Sprite(pokemon, 18, 1 + size * layer, pokemon.Color, 0);
            VerticalLine(26, size * layer, 18, '|');
            Console.SetCursorPosition(0, 4 + size * layer);
            Console.WriteLine($"{pokemon.CurrentExpTotal}/{pokemon.Exp_Max} exp");
            Console.SetCursorPosition(12, 6 + size * layer);
            Console.WriteLine($"{pokemon.CurrentExp}/{pokemon.Exp_NextLvl}");

            ExpBar(pokemon, 12, 5 + size * layer);
            FullStat(pokemon.HP_Full, '░', 3, layer);
            CurrentStat((int)pokemon.CurrentHP, '█', 3, layer);
            FullStat(pokemon.Speed_Full, '█', 4, layer);
            FullStat(pokemon.Attack_Full, '█', 5, layer);
            FullStat(pokemon.Defense_Full, '█', 6, layer);
            FullStat(pokemon.SpAttack_Full, '█', 7, layer);
            FullStat(pokemon.SpDefense_Full, '█', 8, layer);

            HorizontalLine(0, size * (layer + 1), 26, '-');
        }
        public void DexStats(Pokemon pokemon, int layer)
        {
            HorizontalLine(0, size * layer, 26, '-');
            if (pokemon.Type[1] == Element.None)
                Console.WriteLine($"\nNo.{pokemon.Number} {pokemon.Name}\n{pokemon.Type[0]} Type\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\n\nTotal Basestats: {pokemon.TotalBase}\nAverage Basestats: {pokemon.AverageBase}");
            else
                Console.WriteLine($"\nNo.{pokemon.Number} {pokemon.Name}\n{pokemon.Type[0]} & {pokemon.Type[1]}\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\n\nTotal Basestats: {pokemon.TotalBase}\nAverage Basestats: {pokemon.AverageBase}");

            Sprite(pokemon, 18, 1 + size * layer, pokemon.Color, 0);
            VerticalLine(26, size * layer, 18, '|');
            FullStat(pokemon.HP_Base, '█', 1, layer);
            FullStat(pokemon.Speed_Base, '█', 2, layer);
            FullStat(pokemon.Attack_Base, '█', 3, layer);
            FullStat(pokemon.Defense_Base, '█', 4, layer);
            FullStat(pokemon.SpAttack_Base, '█', 5, layer);
            FullStat(pokemon.SpDefense_Base, '█', 6, layer);

            HorizontalLine(0, size * (layer + 1), 26, '-');
        }
        private void HealthBar(Pokemon pokemon, int posX, int posY)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('░');
            }

            for (int i = 0; i < pokemon.CurrentHP / (pokemon.HP_Full * 1.0) * 20; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('█');
            }
            Console.ResetColor();
        }
        private void ExpBar(Pokemon pokemon, int posX, int posY)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('▄');
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < pokemon.CurrentExp / (pokemon.Exp_NextLvl * 1.0) * 10; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('▄');
            }
            Console.ResetColor();
        }
        private void Sprite(Pokemon pokemon, int posX, int posY, int color, int perspective)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.WriteLine(pokemon.Sprite[perspective, i]);
            }
            Console.ResetColor();
        }
        public string Menu(string menu)
        {
            string input;
            Console.WriteLine(menu);
            input = Console.ReadLine();
            Console.Clear();
            return input;
        }
        public string ScrollMenu(string input, List<Pokemon> list, bool details)
        {
            Draw draw = new Draw();
            int page = 0;

            while (input != "exit" && input != "q")
            {
                while (list.Count != 0 && input != "q")
                {
                    int j = 0;
                    for (int i = page; i < list.Count && i < page + 3; i++)
                    {
                        if (details)
                            draw.Stats(list[i], j);
                        else
                            draw.DexStats(list[i], j);
                        j++;
                    }
                    input = draw.Menu("SELECTION SCREEN\n1.scroll up\n2.scroll down\nq.exit");
                    if (input == "previous" || input == "1")
                        page--;
                    else if (input == "next" || input == "2")
                        page++;

                    if (page >= list.Count - 2)
                        page = list.Count - 3;
                    if (page <= -1)
                        page = 0;

                    Console.Clear();
                }
                if (list.Count == 0)
                {
                    Console.WriteLine("Looks kind of empty in here!");
                    input = "q";
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            return "";
        }
        public void Battle(Pokemon myPokemon, Pokemon wildPokemon)
        {
            Border(1, 10, 63, 15, '░');
            Border(40, 10, 63, 15, '░');
            Border(0, 0, 64, 16, '█');
            Console.SetCursorPosition(44, 12);
            Console.Write("FIGHT      CATCH");
            Console.SetCursorPosition(44, 13);
            Console.Write("POKEMON    RUN");

            //myPokemon
            Console.SetCursorPosition(40, 2);
            Console.WriteLine($"{wildPokemon.Name} Lvl.{wildPokemon.Level}");
            HealthBar(wildPokemon, 40, 3);
            Console.SetCursorPosition(40, 4);
            Console.WriteLine($"{Math.Round(wildPokemon.CurrentHP)}/{wildPokemon.HP_Full} Hp");
            Sprite(wildPokemon, 6, 3, wildPokemon.Color, 0);

            //wildPokemon
            Console.SetCursorPosition(40, 6);
            Console.WriteLine($"{myPokemon.Name} Lvl.{myPokemon.Level}");
            HealthBar(myPokemon, 40, 7);
            ExpBar(myPokemon, 50, 8);
            Console.SetCursorPosition(40, 8);
            Console.WriteLine($"{Math.Round(myPokemon.CurrentHP)}/{myPokemon.HP_Full} Hp");
            Console.SetCursorPosition(50, 9);
            Sprite(myPokemon, 24, 7, myPokemon.Color, 1);

            //text
            Console.SetCursorPosition(3, 12);
            Console.WriteLine($"What will {myPokemon.Name} do?");
            Console.SetCursorPosition(3, 13);

            #endregion
        }
    }
}