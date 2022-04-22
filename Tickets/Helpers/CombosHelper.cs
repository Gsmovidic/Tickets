using Microsoft.AspNetCore.Mvc.Rendering;
using Tickets.Data;

namespace Tickets.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync()
        {
            throw new NotImplementedException();


        }

        public Task<IEnumerable<SelectListItem>> GetComboTicketsAsync(int entranceId)
        {
            throw new NotImplementedException();
        }
    }
}
