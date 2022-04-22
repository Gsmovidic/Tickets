using System.ComponentModel.DataAnnotations;

namespace Tickets.Data.Entities
{
    public class Ticket
    {

        public int Id { get; set; }
        public bool WasUsed { get; set; }
        [Required]
        [Display(Name="Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caractéres")]
        public string Document { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caractéres")]
        public string Name { get; set; }

        public Entrance Entrance { get; set; }

        public DateTime Date { get; set; }
    }
}
