using System.Text.Json;

Console.Clear(); // очищення консолі
List<Animals> items = new()
{
    new Animals() { Name = "Tiger", ViewAnimals = "terrestrial", Weight = 80,Age = 10 },
    new Animals() { Name = "Monkey", ViewAnimals = "terrestrial", Weight = 10,Age = 13 },
    new Animals() { Name = "Dog", ViewAnimals = "terrestrial", Weight = 15,Age = 6 },
};
List<Korm> korms = new()
{
     new Korm() { Name = "Viskis", Weight = 5, Number = 80,},
    new Korm() { Name = "Kittyket", Weight = 8, Number = 10,},
    new Korm() { Name = "Kormis", Weight = 10, Number = 15, },
};
while (true)
{
    Console.Clear();
    Console.WriteLine("-------WELCOME ZOO-------");
    Console.WriteLine("----------Menu-----------\r\n" +
                     "1.Add Animal\r\n" +
                     "2.Add korm\r\n" +
                     "3.Show Korm\r\n" +
                     "4.Show Animals\r\n" +
                     "5.Search search\r\n" +
                     "6.Search korm\r\n" +
                     "7.Save Products\n" +
                     "8.Load Products");
    Console.WriteLine("______________________________");

    Console.Write("Your choice: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Animals newItem = new();
            newItem.ReadFromConsole();
            items.Add(newItem);
            break;
        case 2:
            Korm newkorms = new();
            newkorms.ReadFromConsole();
            korms.Add(newkorms);
            break;

        case 3:
            foreach (Korm korm in korms)
                korm.Show();
            break;

        case 4:
            foreach (Animals item in items)
                item.Show();
            break;

        case 5:
            Console.Write("Enter Animals, name to search: ");
            string name = Console.ReadLine();

            var found = items.Find(x => x.Name == name);
            if (found == null)
            {
                Console.WriteLine("Animals not found!");
                break;
            }
            found.Show();
            break;

        case 6:
            Console.Write("Enter Korm, name to search: ");
            string name2 = Console.ReadLine();

            var found2 = korms.Find(x => x.Name == name2);
            if (found2 == null)
            {
                Console.WriteLine("Korm not found!");
                break;
            }
            found2.Show();
            break;

        case 7:
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText("database.json", json);
            break;

        case 8:
            var jsonData = File.ReadAllText("database.json");
            items = JsonSerializer.Deserialize<List<Animals>>(jsonData);
            break;


    }

    Console.ReadKey();
}

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
        ViewAnimals = (Console.ReadLine());
        Console.Write(" Enter Weight: ");
        Weight = int.Parse(Console.ReadLine());
        Console.Write(" Age: ");
        Age = int.Parse(Console.ReadLine());
    }

    public void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"ViewAnimals: {ViewAnimals}");
        Console.WriteLine($" Weight: {Weight}");
        Console.WriteLine($"Age: {Age}");
    }
}

public class Korm
{
    public string Name { get; set; }
    public int Weight { get; set; }

    public int Number { get; set; }

    public void ReadFromConsole()
    {
        Console.Write("Enter Name");
        Name = Console.ReadLine();
        Console.Write("Enter Weight");
        Weight = int.Parse(Console.ReadLine());
        Console.Write("Enter Number");
        Number = int.Parse(Console.ReadLine());

    }
    public void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Weight: {Weight}");
        Console.WriteLine($" Number: {Number}");
    }
}