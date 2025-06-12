using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Models;

namespace ReservasRepository.Interfaces
{
        public interface ISalaRepository
        {
        Task<Sala> Atualizar(Sala sala);
        Task<Sala?> ObterPorId(int id);
        Task<Sala> Criar(Sala sala);
        }
}
