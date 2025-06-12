using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Interfaces;
using ReservasRepository.Models;
using ReservasService.Interfaces;

    namespace ReservasService
    {
        public class SalaService : ISalaService
        {
            private readonly ISalaRepository _salaRepository;
            public SalaService(ISalaRepository salaRepository)
            {
                _salaRepository = salaRepository;
            }

            public async Task<Sala> CadastrarSala(Sala sala)
            {
                sala.DataCriacao = DateTimeOffset.UtcNow;
                sala.Ativo = true;

                return await _salaRepository.Criar(sala);
            }

            public async Task<Sala> EditarSala(Sala sala)
            {
                return await _salaRepository.Atualizar(sala);
            }

            public async Task<bool> DesativarSala(int id)
            {
                var sala = await _salaRepository.ObterPorId(id);
            
                if(sala == null)
                {
                    throw new Exception("Ops! nenhuma sala encontrado");
                }

                sala.Ativo = false;

                await _salaRepository.Atualizar(sala);

                return true;
            }

        }
    }
