using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Zoo100;

Console.Clear(); // очищення консолі

Zoo z = new();

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
            z.AddAnimals();
            break;
        case 2:
            z.AddKorm();
            break;

        case 3:
           z.ShowKorm();
            break;

        case 4:
           z.ShowAnimals();
            break;

        case 5:
            z.Searchanimal();
            break;

        case 6:
           z.Searchkorm();
            break;

        case 7:
           z.SaveProducts();
            break;

        case 8:
           z.LoadProducts();
            break;

        case 9:
           z.DeleteProduct();
            break;
        case 10:
           z.BuyTicket();
            break;

        case 11:
           z.ShowTicket();
            break;
    }

    Console.ReadKey();
}
