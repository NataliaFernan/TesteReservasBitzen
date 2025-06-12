using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;

namespace ReservasService.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CadastrarUsuario(UsuarioDto usuario);
        Task<Usuario> EditarUsuario(Usuario usuario);
        Task<bool> DesativarUsuario(int id);
        Task<string> ObterUsuarioEmailSenha(EntrarDto entrarDto);
    }
}
