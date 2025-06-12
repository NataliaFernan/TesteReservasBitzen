using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Interfaces;
using ReservasRepository.Models;

namespace ReservasRepository
{
    namespace ReservasRepository
    {
        public class SalaRepository : ISalaRepository
        {
            private readonly AppDbContext _context;

            public SalaRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Sala> Atualizar(Sala sala)
            {
                _context.Salas.Update(sala);

                await _context.SaveChangesAsync();

                return sala;
            }

            public async Task<Sala> Criar(Sala sala)
            {
                _context.Salas.Add(sala);

                await _context.SaveChangesAsync();

                return sala;
            }

            public async Task<Sala?> ObterPorId(int id)
            {
                return await _context.Salas.FindAsync(id);
            }
        }
    }
}
