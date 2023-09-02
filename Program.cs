using System;
using Main_Menu.controller;

class Program
{
    static void Main()
    {
        int slot = 0;
        while (true)
        {
            Console.Write("Input the number of parking slots =");
            string? slotInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(slotInput))
            {
                if (int.TryParse(slotInput, out slot))
                {
                    Console.WriteLine("You enter a number: " + slot);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter the correct number.");
                }
            }
        }
        Console.Clear();
        MainMenu.menu(slot);
    }
}
