using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasRepository.Models.Dto
{
    public class NovaReservaDto
    {
        public int IdUsuario { get; set; }
        public int IdSala { get; set; }
        public DateTime InicioReserva { get; set; }
        public DateTime FimReserva { get; set; }
    }
}
