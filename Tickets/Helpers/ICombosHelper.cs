using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tickets.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync();

    }
}
