using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zoo100
{
    internal class Zoo
    {
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

       public void AddAnimals()
        {
            Animals newItem = new();
            newItem.ReadFromConsole();
            items.Add(newItem);
        }

        public void AddKorm()
        {
            Korm newKorm = new();
            newKorm.ReadFromConsole();
            korms.Add(newKorm);
        }

        public void ShowKorm()
        {
            foreach (Korm korm in korms)
                korm.Show();
        }

         public void ShowAnimals()
        {
            foreach (Animals item in items)
                item.Show();
        }

        public void Searchanimal()
        {
            Console.Write("Enter animal name to search: ");
            string name = Console.ReadLine();

            var found = items.Find(x => x.Name == name);
            if (found == null)
            {
                Console.WriteLine("Animal not found!");
                return;
            }
            found.Show();
        }

        public void Searchkorm()
        {

            Console.Write("Enter Korm name to search: ");
            string name2 = Console.ReadLine();

            var found2 = korms.Find(x => x.Name == name2);
            if (found2 == null)
            {
                Console.WriteLine("Korm not found!");
                return;
            }
            found2.Show();
        }

        public void SaveProducts()
        {
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText("database.json", json);
        }

        public void LoadProducts()
        {
            var jsonData = File.ReadAllText("database.json");
            items = JsonSerializer.Deserialize<List<Animals>>(jsonData);
        }

        public void DeleteProduct()
        {
            Console.Write("Enter animal name to delete: ");
            string name3 = Console.ReadLine();

            var found3 = items.Find(x => x.Name == name3);
            if (found3 == null)
            {
                Console.WriteLine("Animal not found!");
                return;
            }
            items.Remove(found3);
        }

        public void BuyTicket()
        {
            foreach (Ticket item in tikets)
                item.ShowTicketInfo();
        }

        public void ShowTicket()
        {

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
        }
    }
}
