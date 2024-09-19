using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRS_AtmProject.Application.Atms.Commands;
using CQRS_AtmProject.Application.Atms.Queries;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Data;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;
using CQRS_AtmProject.Application.Transactions.Commands;
using CQRS_AtmProject.Application.Transactions.Command;

namespace CQRS_AtmProject.Infrastructure.Services
{
    public class AtmService : IAtmService
    {
        private readonly IMediator _mediator;
        private readonly IAtmRepository _atmRepository;
        private readonly IMapper _mapper;

        public AtmService(IMediator mediator, IAtmRepository atmRepository, IMapper mapper)
        {
            _mediator = mediator;
            _atmRepository = atmRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<AtmDto>>> GetAllAtmsAsync()
        {
            var query = new GetAllAtmsQuery();
            var atms = await _mediator.Send(query);

            return atms;
        }

        public async Task<ServiceResponse<AtmDto>> GetAtmByIdAsync(int id)
        {
            var query = new GetAtmByIdQuery { Id = id };
            var atm = await _mediator.Send(query);

            return atm;
        }

        public async Task<ServiceResponse<AtmDto>> CreateAtmAsync(CreateAtmDto createAtmDto)
        {
            var command = _mapper.Map<CreateAtmCommand>(createAtmDto);
            var result = await _mediator.Send(command);

            return result;
        }

        public async Task<ServiceResponse<AtmDto>> UpdateAtmAsync(int id, UpdateAtmDto updateAtmDto)
        {
            var command = _mapper.Map<UpdateAtmCommand>(updateAtmDto);
            var result = await _mediator.Send(command);

            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteAtmAsync(int id)
        {
            var command = new DeleteAtmCommand { Id = id };
            var result = await _mediator.Send(command);

            return result;
        }

    }
}