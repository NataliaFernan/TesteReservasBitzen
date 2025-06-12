using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;

namespace ReservasRepository.Interfaces
{
        public interface IUsuarioRepository
        {
            Task<Usuario> Atualizar(Usuario usuario);
            Task<Usuario> Criar(Usuario usuario);
            Task<Usuario?> ObterPorId(int id);
            Task<Usuario?> ObterPorEmailSenha(EntrarDto entrarDto);
        }
}
