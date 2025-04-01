public class Animals
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public string ViewAnimals { get; set; }
    public int Age { get; set; }

    public void ReadFromConsole()
    {
        Console.Write("Enter name: ");
        Name = Console.ReadLine();
        Console.Write("Enter ViewAnimals: ");
        ViewAnimals = Console.ReadLine();
        Console.Write("Enter Weight: ");
        Weight = int.Parse(Console.ReadLine());
        Console.Write("Age: ");
        Age = int.Parse(Console.ReadLine());
    }

    public void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"ViewAnimals: {ViewAnimals}");
        Console.WriteLine($"Weight: {Weight}");
        Console.WriteLine($"Age: {Age}");
    }
}
