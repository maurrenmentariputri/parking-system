using System;

namespace Status_Vehicle_Menu.controller
{
    using Parking_Model.model;
    using System.Text.RegularExpressions;
    using Input.utils;
    using System.Runtime.CompilerServices;

    public class Status_Vehicle_Menu
    {
        public static void MainStatusVehicle(ParkingSlot[] parking, char menu)
        {            
            switch (menu)
            {
                case '3':
                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine("Even for 1, Odd For 2 : ");
                        char userInput = Input.InputChar();
                        if(userInput=='1')
                        {
                            EvenVehicle(parking);
                            break;
                        } else if(userInput=='2')
                        {
                            OddVehicle(parking);
                            break;
                        }else{
                            Console.WriteLine("You can only input 1 or 2. Press any key to re-input");
                            Console.ReadKey(true);
                        }
                        
                    }    
                    break;
                case '4':
                    TypeVehicle(parking);
                    break;   
                case '5':
                    Colorvehicle(parking);
                    break;
                case '6':
                    Console.Write("Enter plate number: ");
                    string? searchPlateNumber = Console.ReadLine();
                    FindVehicleByPlateNumber(parking, searchPlateNumber);
                    break;
                default:
                    break;
            }
        }
        public static void Colorvehicle(ParkingSlot[] parking)
        {
            List<int> vehicle = Input.CheckVehicle(parking);
            string? color;
            bool exist=false;            
            while (true)
            {
                Console.Write("Color : ");
                color = Console.ReadLine();
                Console.Clear();
                if (color=="")
                {
                    Console.WriteLine("input cannot be empty");
                }else
                {
                    break;
                }
            }
            foreach (var item in vehicle)
            {
                if (parking[item].Vehicle.Color==color)
                {
                    if (item==0)
                    {
                        Console.WriteLine($"Vehicle With {color} Color Parked On ");
                        exist=true;
                    }
                    Console.Write($"Slot\t: {parking[item].Slot} ");
                }
            }            
            if(!exist)
            {
                Console.Write($"there are no {color} vehicles in the parking lot");
                Input.PressAnyKey();
                return;
            }
            Console.WriteLine();
            Input.PressAnyKeyToContinue();
        }
        public static void TypeVehicle(ParkingSlot[] parking)
        {
            List<int> vehicle = Input.CheckVehicle(parking);
            int Motorcycle=0; int Car=0;
                        foreach (var item in vehicle)
            {
                if (parking[item].Vehicle.Type=="Motorcycle")
                {
                    Motorcycle++;
                } else
                {
                    Car++;
                }
            }
            Console.WriteLine($"Motorcycle : {Motorcycle}, Car : {Car}");            
            Input.PressAnyKeyToContinue();
        }
        public static void EvenVehicle(ParkingSlot[] parking)
        {
            
            List<string> numbersOnly = new List<string>();
            List<int> vehicle = Input.CheckVehicle(parking);
            bool exist=false;
            if(vehicle.Count==0)
            {
                Console.WriteLine("Parking lot still empty");
                Input.PressAnyKey();
                return;
            }
            Console.Clear();
            foreach (var item in vehicle)
            {
                numbersOnly.Add(Regex.Replace(parking[item].Vehicle.PlateNumber, @"[^\d]", ""));
            }
            for (int i = 0; i < numbersOnly.Count; i++)
            {
                
                if(int.Parse(numbersOnly[i])%2==0)
                {
                    if(!exist)
                    {   
                        Console.WriteLine("List vehicle with even plate number");
                    }
                    Console.WriteLine($"Slot {i+1}. {parking[vehicle[i]].Vehicle.PlateNumber}");
                    exist=true;
                }
                
            }
            if(!exist)
            {
                Console.WriteLine("There are no even plate number in the parking lot");
                Input.PressAnyKey();
                return;
            }
            Input.PressAnyKeyToContinue();
        }
        public static void OddVehicle(ParkingSlot[] parking)
        {
            List<string> numbersOnly = new List<string>();
            List<int> vehicle = Input.CheckVehicle(parking);
            bool exist=false;
            if(vehicle.Count==0)
            {
                Console.WriteLine("Parking lot still empty");
                Input.PressAnyKey();
                return;
            }
            Console.Clear();
            foreach (var item in vehicle)
            {
                numbersOnly.Add(Regex.Replace(parking[item].Vehicle.PlateNumber, @"[^\d]", ""));
            }
            for (int i = 0; i < numbersOnly.Count; i++)
            {
                
                if(int.Parse(numbersOnly[i])%2!=0)
                {
                    if(!exist)
                    {
                        Console.WriteLine("List vehicle with Odd plate number");
                    }
                    Console.WriteLine($"Slot {i+1}. {parking[vehicle[i]].Vehicle.PlateNumber}");
                    exist=true;
                }
                
            }
            if(!exist)
            {
                Console.WriteLine("There are no Odd Plate Number in the parking lot");
                Input.PressAnyKey();
                return;
            }
            Input.PressAnyKeyToContinue();
        }
       public static void FindVehicleByPlateNumber(ParkingSlot[] parking, string? searchPlateNumber)
        {
            
            List<int> vehicleIndices = Input.CheckVehicle(parking);
            bool found = false;

            for (int i = 0; i < parking.Length; i++)
            {
                if (parking[i].Vehicle.PlateNumber == searchPlateNumber)
                {
                    Console.WriteLine($"Slot {i + 1} for plate number {searchPlateNumber}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Slot for plate number {searchPlateNumber} not found");
            }
        }




    }
}
