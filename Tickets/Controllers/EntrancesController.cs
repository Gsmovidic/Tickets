#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tickets.Data;
using Tickets.Data.Entities;
using Tickets.Helpers;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class EntrancesController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public EntrancesController(DataContext context , ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        // GET: Entrances
        [HttpGet]
        public async Task<IActionResult> CheckTicket()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CheckTicket(TicketViewModel ticketVM) {
            int? n = ticketVM.id;
            if (ModelState.IsValid)
            {
              Ticket tic = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketVM.id);
                if (tic == null)
                {
                    ModelState.AddModelError(String.Empty, "No existe boleta con el número consultado");
                }
                else {
                    if ((bool)!tic.WasUsed)
                    {
                        return RedirectToAction(nameof(EditTicket) , new {Id=ticketVM.id });
                    }
                     else {
                        return RedirectToAction(nameof(TicketDetails), new {Id=ticketVM.id});
                    }
                }
            }
            return View();
        
        
        }

        public async Task<IActionResult> TicketDetails(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        

        }

        public async Task<IActionResult> EditTicket(int? id){
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            TicketVM2 tk2 = new () {
            Id = (int)ticket.Id,
            Document = ticket.Document,
            WasUsed= (bool)ticket.WasUsed,
            Name = ticket.Name
            };
            return View(tk2);

        }

        [HttpPost]

        public async Task<IActionResult> EditTicket(TicketVM2 tk2, int id)
        {
            if (id != tk2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid) 
            {
               
                Ticket tk = new() {
                Id = tk2.Id,
                Document = tk2.Document, 
                Name=tk2.Name,
                WasUsed = true,
                Date=DateTime.Now,
                
                };
                _context.Update(tk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CheckTicket));
            }

            return View(tk2);
        }

     
      
    }
}
