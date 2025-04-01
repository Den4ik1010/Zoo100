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
