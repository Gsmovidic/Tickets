namespace Tickets.Models
{
    public class TicketVM2
    {
        public int Id { get; set; }
        public bool WasUsed { get; set; }

        public string Document { get; set; }

        public string Name  { get; set; }

        public int EntranceId { get; set; }
    }
}
