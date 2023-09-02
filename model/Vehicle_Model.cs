namespace Vehicle_Model.model
{
    public struct Vehicle
    {
        public string Name;
        public string PlateNumber;
        public string Type;
        public string Color;

        public void Display()
        {
            Console.WriteLine($"{Name}\t{PlateNumber}\t{Type}\t{Color}");
        }

        public void Create()
{
    Console.Write("Vehicle Name\t: ");
    string? input = Console.ReadLine();
    if (input != null)
    {
        Name = input;
    }

    Console.Write("Plate Number\t: ");
    input = Console.ReadLine();
    if (input != null)
    {
        PlateNumber = input;
    }

    while (true)
    {
        Console.Write("Type Motorcycle or Car: ");
        input = Console.ReadLine();
        if (input != null)
        {
            if (input == "Motorcycle" || input == "Car")
            {
                Type = input;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Only 'Motorcycle' or 'Car' are allowed");
            }
        }
    }

    if (Type == "Motorcycle")
    {
        Console.Write("Motorcycle Color\t: ");
    }
    else if (Type == "Car")
    {
        Console.Write("Car Color\t: ");
    }

    input = Console.ReadLine();
    if (input != null)
    {
        Color = input;
    }
}

        public void Out()
        {
            Name="";
            PlateNumber="";
            Type="";
            Color="";
        }
    }
}
