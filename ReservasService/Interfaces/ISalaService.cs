using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Models;

namespace ReservasService.Interfaces
{
    public interface ISalaService
    {
        Task<Sala> CadastrarSala(Sala sala);
        Task<Sala> EditarSala(Sala sala);
        Task<bool> DesativarSala(int id);
    }
}
