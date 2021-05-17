﻿using System;

namespace GreatPyramidTreasureConsoleRPG
{
    public class Bar
    {
        private bool specialDrink = true;

        public void BarOptions(IClass characterClass)
        {
            if (characterClass != null)
            {
                bool value = true;
                while (value)
                {
                    Console.WriteLine("Co chcesz zrobić:");
                    Console.WriteLine("1. Zapytaj barmana co słychać w okolicy.");
                    Console.WriteLine("2. Napij się czegoś.");
                    Console.WriteLine("3. Pokaż mi swoje towary. //To do");
                    Console.WriteLine("4. Odejdź od baru.");
                    int choice = StandardFunctions.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            Dialogues.ConvWithBarman(characterClass);
                            break;

                        case 2:
                            this.DrinkSmth(characterClass);
                            break;

                        case 3:
                            Bar.Shop();
                            break;

                        case 4:
                            value = StandardFunctions.ExitRoom();
                            break;

                        default:
                            StandardFunctions.NoOption();
                            break;
                    }
                }
            }
        }

        private static void DrinkWater(IClass characterClass)
        {
            if (characterClass.Gold < 5)
            {
                Dialogues.NoGold();
            }
            else
            {
                if (characterClass.Level < 5)
                {
                    characterClass.Exp += 5;
                    characterClass.Gold -= 5;
                    characterClass.AddLevel();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Twoje punkty doświadczenia zwiększyły się o 5.");
                    Console.ResetColor();
                }
                else if (characterClass.Level >= 5)
                {
                    characterClass.Gold -= 5;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Masz za wysoki poziom!");
                    Console.WriteLine("Po prostu napiłeś się wody!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Masz za niski poziom aby wypić Wody!!!");
                    Console.ResetColor();
                }
            }
        }

        private static void DrinkWhisky(IClass characterClass)
        {
            if (characterClass.Gold < 15)
            {
                Dialogues.NoGold();
            }
            else
            {
                if (characterClass.Level >= 5 && characterClass.Level < 10)
                {
                    characterClass.Exp += 5;
                    characterClass.Gold -= 15;
                    characterClass.AddLevel();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Twoje punkty doświadczenia zwiększyły się o 5.");
                    Console.ResetColor();
                }
                else if (characterClass.Level >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Masz za wysoki poziom!");
                    Console.WriteLine("Po prostu napiłeś się whisky!");
                    Console.ResetColor();
                    characterClass.Gold -= 15;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Masz za niski poziom aby wypić Whisky!!!");
                    Console.ResetColor();
                }
            }
        }

        private static void Shop()
        {
            ////To do + ekwipunek
        }

        private void DrinkSmth(IClass characterClass)
        {
            bool value = true;
            while (value)
            {
                Console.WriteLine("Co chcesz zrobić:");
                Console.WriteLine("1: Zamów szklankę wody /5g");
                Console.WriteLine("2: Zamów szklankę dobrej whisky /15g ");
                Console.WriteLine("3. Zamów coś specjalnego /150g");
                Console.WriteLine("4. Zrezygnuj.");
                int choice = StandardFunctions.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Bar.DrinkWater(characterClass);
                        break;

                    case 2:
                        Bar.DrinkWhisky(characterClass);
                        break;

                    case 3:
                        this.DrinkSmthSpecial(characterClass);
                        break;

                    case 4:
                        value = StandardFunctions.ExitRoom();
                        break;

                    default:
                        StandardFunctions.NoOption();
                        break;
                }
            }
        }

        private void DrinkSmthSpecial(IClass characterClass)
        {
            if (this.specialDrink)
            {
                if (characterClass.Gold < 150)
                {
                    Dialogues.NoGold();
                }
                else
                {
                    if (characterClass.Level >= 15)
                    {
                        Console.WriteLine("Napij się specjalności prosto od krzyżaków z Marlborka!");
                        Console.WriteLine("Miód pitny zwany Grunwald! Coś wspaniałego!");
                        Console.WriteLine("Napiłeś się legendarnego miodu pitnego, który pochodzi ze stołów biesiadnych przed bitwą pod Grunwaldem.");
                        characterClass.Exp += 5000;
                        characterClass.Dex += 5;
                        characterClass.Str += 5;
                        characterClass.Vit += 5;
                        characterClass.Gold -= 150;
                        characterClass.AddLevel();
                        characterClass.UpdateStats();
                        this.specialDrink = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Twoje punkty doświadczenia zwiększyły się o 5000.");
                        Console.WriteLine("Twoje statystyki zwiększyły się o 5.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Masz za niski poziom aby skosztować tej specjalności!!!");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To była jedyna sztuka, niestety.");
                Console.WriteLine("Nie wiem czy kiedykolwiek dostanę podobny towar.");
                Console.ResetColor();
            }
        }
    }
}