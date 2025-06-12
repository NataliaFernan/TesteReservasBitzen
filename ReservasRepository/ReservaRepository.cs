using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservasRepository.Interfaces;
using ReservasRepository.Models;

namespace ReservasRepository
{
    namespace ReservasRepository
    {
        public class ReservaRepository : IReservaRepository
        {
            private readonly AppDbContext _context;

            public ReservaRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Reserva> Atualizar(Reserva reserva)
            {
                _context.Reservas.Update(reserva);

                await _context.SaveChangesAsync();

                return reserva;
            }

            public async Task<Reserva> Criar(Reserva reserva)
            {
                _context.Reservas.Add(reserva);

                await _context.SaveChangesAsync();

                return reserva;
            }

            public async Task<Reserva?> ObterPorId(int id)
            {
                return await _context.Reservas.FindAsync(id);
            }

            public async Task<List<Reserva>> ObterReservas(int idSala, int idUsuario, DateTime? data, bool status = true)
            {
                var query = _context.Reservas.AsQueryable();

                if (idUsuario != 0)
                {
                    query = query.Where(r => r.IdUsuario == idUsuario);
                }

                if (idSala != 0)
                {
                    query = query.Where(r => r.IdSala == idSala);
                }

                query = query.Where(r => r.Ativo == status);
                
                if (data.HasValue)
                {
                    query = query.Where(r => r.InicioReserva.Date == data.Value.Date);
                }

                return await query.ToListAsync();
            }

            public async Task<bool> ExisteHorarioSala(int idSala, DateTimeOffset inicio, DateTimeOffset fim)
            {
                return await _context.Reservas
                    .AnyAsync(r =>
                    r.IdSala == idSala &&
                    r.Ativo == true &&
                    r.InicioReserva < fim &&
                    r.FimReserva > inicio   
                );
            }
        }
    }
}
