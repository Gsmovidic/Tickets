using Tickets.Data.Entities;

namespace Tickets.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEntrancesAsync();
        }


        
        private async Task CheckEntrancesAsync()
        {

            if (!_context.Entrances.Any())
            {
                Entrance entrance1 = new Entrance
                {
                    Description = "Norte",
                    Tickets = new List<Ticket>()

                };

                Entrance entrance2 = new Entrance
                {
                    Description = "Sur",
                    Tickets = new List<Ticket>()
                };

                Entrance entrance3 = new Entrance
                {
                    Description = "Occidental",
                    Tickets = new List<Ticket>()
                };

                Entrance entrance4 = new Entrance
                {
                    Description = "Oriental",
                    Tickets = new List<Ticket>()
                };

                List<Ticket> tickets1 = new List<Ticket>();
                for (int i = 1; i <= 1250; i++)
                {
                    Ticket t = new Ticket
                    {
                        WasUsed = false,
                        Entrance = entrance1,
                        Document="",
                        Name = "",
                        Date = DateTime.Now
                    };
                    tickets1.Add(t);
                    _context.Tickets.Add(t);
                }
                entrance1.Tickets = tickets1;

                List<Ticket> tickets2 = new List<Ticket>();
                for (int i = 1250; i <= 2500; i++)
                {
                    Ticket t = new Ticket
                    {
                        WasUsed = false,
                        Entrance = entrance2
                        ,
                        Document = "",
                        Name="",
                        Date=DateTime.Now
                    };
                    tickets2.Add(t);
                    _context.Tickets.Add(t);
                }
                entrance2.Tickets = tickets2;

                List<Ticket> tickets3 = new List<Ticket>();
                for (int i = 2500; i <= 3750; i++)
                {
                    Ticket t = new Ticket
                    {
                        WasUsed = false,
                        Entrance = entrance3,
                        Document = "",
                        Name = "",
                        Date = DateTime.Now
                    };
                    tickets3.Add(t);
                    _context.Tickets.Add(t);
                }
                entrance3.Tickets = tickets3;


                List<Ticket> tickets4 = new List<Ticket>();
                for (int i = 3750; i <= 5000; i++)
                {
                    Ticket t = new Ticket
                    {
                        WasUsed = false,
                        Entrance = entrance4,
                        Document = "",
                        Name = "",
                        Date = DateTime.Now
                    };
                    tickets4.Add(t);
                    _context.Tickets.Add(t);
                }
                entrance4.Tickets = tickets4;

                _context.Entrances.Add(entrance1);
                _context.Entrances.Add(entrance2);
                _context.Entrances.Add(entrance3);
                _context.Entrances.Add(entrance4);
            }
            await _context.SaveChangesAsync();

        }

       
    }
}