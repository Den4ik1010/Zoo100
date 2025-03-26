using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

Console.Clear(); // очищення консолі
List<Animals> items = new()
{
    new Animals() { Name = "Tiger", ViewAnimals = "terrestrial", Weight = 80, Age = 10 },
    new Animals() { Name = "Monkey", ViewAnimals = "terrestrial", Weight = 10, Age = 13 },
    new Animals() { Name = "Dog", ViewAnimals = "terrestrial", Weight = 15, Age = 6 },
};
List<Korm> korms = new()
{
    new Korm() { Name = "Viskis", Weight = 5, Number = 80 },
    new Korm() { Name = "Kittyket", Weight = 8, Number = 10 },
    new Korm() { Name = "Kormis", Weight = 10, Number = 15 },
};
List<Ticket> tikets = new()
{
    new Ticket("ZooTiket", 10, 1000),
};

while (true)
{
    Console.Clear();
    Console.WriteLine("-------WELCOME ZOO-------");
    Console.WriteLine("----------Menu-----------\r\n" +
                     "0. Exit\n" +
                     "1. Add Animal\r\n" +
                     "2. Add korm\r\n" +
                     "3. Show Korm\r\n" +
                     "4. Show Animals\r\n" +
                     "5. Search animal\r\n" +
                     "6. Search korm\r\n" +
                     "7. Save Products\n" +
                     "8. Load Products\n" +
                     "9. Delete Product\n" +
                     "10. Buy Ticket\n" +
                     "11. Show Ticket");
    Console.WriteLine("______________________________");

    Console.Write("Your choice: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 0:
            Console.WriteLine("Have a good day!");
            return;
        case 1:
            Animals newItem = new();
            newItem.ReadFromConsole();
            items.Add(newItem);
            break;
        case 2:
            Korm newKorm = new();
            newKorm.ReadFromConsole();
            korms.Add(newKorm);
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
            Console.Write("Enter animal name to search: ");
            string name = Console.ReadLine();

            var found = items.Find(x => x.Name == name);
            if (found == null)
            {
                Console.WriteLine("Animal not found!");
                break;
            }
            found.Show();
            break;

        case 6:
            Console.Write("Enter Korm name to search: ");
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

        case 9:
            Console.Write("Enter animal name to delete: ");
            string name3 = Console.ReadLine();

            var found3 = items.Find(x => x.Name == name3);
            if (found3 == null)
            {
                Console.WriteLine("Animal not found!");
                break;
            }
            items.Remove(found3);
            break;
        case 10:
            foreach (Ticket item in tikets)
                item.ShowTicketInfo();
            break;

        case 11:
            Console.WriteLine("Enter the number of tickets you want to buy:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity > tikets[0].totalTickets)
            {
                Console.WriteLine("Not enough tickets. Only " + tikets[0].totalTickets + " tickets available.");
            }
            else
            {
                tikets[0].totalTickets -= quantity;
                double totalPrice = quantity * tikets[0].ticketPrice;
                Console.WriteLine("You bought " + quantity + " tickets for " + totalPrice + " UAH.");
                Console.WriteLine("Remaining tickets: " + tikets[0].totalTickets);
            }
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

public class Ticket
{
    public string ticketName { get; set; }
    public double ticketPrice { get; set; }
    public int totalTickets { get; set; }

    public Ticket(string ticketName, double ticketPrice, int totalTickets)
    {
        this.ticketName = ticketName;
        this.ticketPrice = ticketPrice;
        this.totalTickets = totalTickets;
    }

    public void ShowTicketInfo()
    {
        Console.WriteLine("ticketName: " + ticketName);
        Console.WriteLine("ticketPrice: " + ticketPrice + " UAH");
        Console.WriteLine("totalTickets: " + totalTickets);
    }
}
