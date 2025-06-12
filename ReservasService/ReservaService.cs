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
        public class ReservaService : IReservaService
        {
            private readonly IReservaRepository _reservaRepository;
            public ReservaService(IReservaRepository reservaRepository)
            {
                _reservaRepository = reservaRepository;
            }

            public async Task<Reserva> CadastrarReserva(NovaReservaDto reserva)
            {  
                if(reserva.InicioReserva.Year == reserva.FimReserva.Year && 
                reserva.InicioReserva.Month == reserva.FimReserva.Month && 
                reserva.InicioReserva.Day == reserva.FimReserva.Day)
                {

                    var existeReserva = await _reservaRepository.ExisteHorarioSala(reserva.IdSala, reserva.InicioReserva, reserva.FimReserva);

                    if (existeReserva)
                    {
                        throw new Exception("Já existe uma reserva para essa data e horário!");
                    }
                    else
                    {
                        var novaReserva = new Reserva()
                        {
                            IdUsuario = reserva.IdUsuario,
                            IdSala = reserva.IdSala,
                            InicioReserva = reserva.InicioReserva,
                            FimReserva = reserva.FimReserva,
                            DataCriacao = DateTimeOffset.UtcNow,
                            Ativo = true
                        };

                        return await _reservaRepository.Criar(novaReserva);
                    }
                    
                }
                else
                {
                    throw new Exception("A Reserva só pode ser criada para o mesmo dia!");
                }   
            }

            public async Task<List<Reserva>> ObterReservas(int idSala, int idUsuario, DateTime? data, bool status = true)
            {
                return await _reservaRepository.ObterReservas(idSala, idUsuario, data, status);
            }

            public async Task<bool> CancelarReserva(int id)
            {
                var reserva = await _reservaRepository.ObterPorId(id);
            
                if(reserva == null)
                {
                    throw new Exception("Ops! nenhuma reserva encontrada");
                }

                reserva.Ativo = false;

                await _reservaRepository.Atualizar(reserva);

                return true;
            }

        }
    }
