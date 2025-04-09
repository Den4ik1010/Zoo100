using Zoo100;

Console.Clear(); // очищення консолі

Zoo z = new();

Menu menu = new();

while (true)
{
    Console.Clear();
    Console.WriteLine("-------WELCOME ZOO-------");


    menu.ShowMenu();
    int choice = menu.AskUserInput();


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
