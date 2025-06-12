using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservasRepository.Interfaces;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;

namespace ReservasRepository
{
    namespace ReservasRepository
    {
        public class UsuarioRepository : IUsuarioRepository
        {
            private readonly AppDbContext _context;

            public UsuarioRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Usuario> Atualizar(Usuario usuario)
            {
                _context.Usuarios.Update(usuario);

                await _context.SaveChangesAsync();

                return usuario;
            }

            public async Task<Usuario> Criar(Usuario usuario)
            {
                _context.Usuarios.Add(usuario);

                await _context.SaveChangesAsync();

                return usuario;
            }

            public async Task<Usuario?> ObterPorEmailSenha(EntrarDto entrarDto)
            {
                return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == entrarDto.Email && x.Senha == entrarDto.Senha);
            }

            public async Task<Usuario?> ObterPorId(int id)
            {
                return await _context.Usuarios.FindAsync(id);
            }
        }
    }
}
