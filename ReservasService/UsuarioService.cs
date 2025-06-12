using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReservasRepository.Interfaces;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;
using ReservasService.Interfaces;

    namespace ReservasService
    {
        public class UsuarioService : IUsuarioService
        {
            private readonly IUsuarioRepository _usuarioRepository;
            private readonly string senhaJwt;
            public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
            {
                _usuarioRepository = usuarioRepository;
                senhaJwt = configuration.GetSection("SenhaJwt").Value;
            }

            public async Task<string> ObterUsuarioEmailSenha(EntrarDto entrarDto)
            {
                var usuario = await _usuarioRepository.ObterPorEmailSenha(entrarDto);
                
                if(usuario == null)
                {
                    throw new Exception("Email ou Senha incorretos!");
                }

                return GerarToken(usuario);

            }

            public async Task<Usuario> CadastrarUsuario(Usuario usuario)
            {
                usuario.DataCriacao = DateTimeOffset.UtcNow;
                usuario.Ativo = true;

                return await _usuarioRepository.Criar(usuario);
            }

            public async Task<Usuario> EditarUsuario(Usuario usuario)
            {
                return await _usuarioRepository.Atualizar(usuario);
            }

            public async Task<bool> DesativarUsuario(int id)
            {
                var usuario = await _usuarioRepository.ObterPorId(id);
            
                if(usuario == null)
                {
                    throw new Exception("Ops! nenhum usuário encontrado");
                }

                usuario.Ativo = false;

                await _usuarioRepository.Atualizar(usuario);

                return true;
            }

            private string GerarToken(Usuario usuario)
            {
                var tokenJwt = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(senhaJwt);
                var tokenConfig = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Sid, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Name,usuario.Nome),
                        new Claim(ClaimTypes.Email, usuario.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenJwt.CreateToken(tokenConfig);
                return tokenJwt.WriteToken(token);
            }

        }
    }
