using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Interfaces;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;
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

            public async Task<Sala> CadastrarSala(SalaDto sala)
            {
                var salaCriar = new Sala()
                {
                    Nome = sala.Nome,
                    Capacidade = sala.Capacidade,
                    DataCriacao = DateTimeOffset.UtcNow,
                    Ativo = true
                };

                return await _salaRepository.Criar(salaCriar);
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
