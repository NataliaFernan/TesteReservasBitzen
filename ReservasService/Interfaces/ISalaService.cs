using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;

namespace ReservasService.Interfaces
{
    public interface ISalaService
    {
        Task<Sala> CadastrarSala(SalaDto sala);
        Task<Sala> EditarSala(Sala sala);
        Task<bool> DesativarSala(int id);
    }
}
