public class Korm
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Number { get; set; }

    public void ReadFromConsole()
    {
        Console.Write("Enter Name: ");
        Name = Console.ReadLine();
        Console.Write("Enter Weight: ");
        Weight = int.Parse(Console.ReadLine());
        Console.Write("Enter Number: ");
        Number = int.Parse(Console.ReadLine());
    }

    public void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Weight: {Weight}");
        Console.WriteLine($"Number: {Number}");
    }
}
