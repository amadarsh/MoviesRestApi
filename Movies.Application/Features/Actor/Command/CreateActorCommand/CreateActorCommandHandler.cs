using AutoMapper;
using MediatR;
using Movies.Application.Respository;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Actors.Command.CreateActorCommand
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, ActorDto>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Actor> asyncRepository;

        public CreateActorCommandHandler(IMapper mapper, IAsyncRepository<Actor> asyncRepository)
        {
            this.mapper = mapper;
            this.asyncRepository = asyncRepository;
        }
        public async Task<ActorDto> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var newEntity = mapper.Map<Actor>(request);
            await asyncRepository.AddAsync(newEntity);

            return mapper.Map<ActorDto>(newEntity);
        }
    }
}
