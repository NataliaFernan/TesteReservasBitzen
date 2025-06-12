using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasRepository.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTimeOffset DataCriacao { get; set; } 
        public bool Ativo { get; set; } = true;
        public DateTime InicioReserva { get; set; }
        public DateTime FimReserva { get; set; }

        [ForeignKey("Sala")]
        public int IdSala { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
    }
}
