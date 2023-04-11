using AutoMapper;
using MediatR;
using Movies.Application.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Film.Query.GetActorsByFilmQuery
{
    public class GetActorsByFilmQueryHandler : IRequestHandler<GetActorsByFilmQuery, List<ActorListVm>>
    {
        private readonly IMapper mapper;
        private readonly IActorRespository actorRespository;

        public GetActorsByFilmQueryHandler(IMapper mapper, IActorRespository actorRespository)
        {
            this.mapper = mapper;
            this.actorRespository = actorRespository;
        }
        public async Task<List<ActorListVm>> Handle(GetActorsByFilmQuery request, CancellationToken cancellationToken)
        {
            var actors = await actorRespository.GetActorsByFilmId(request.FilmId);
            return mapper.Map<List<ActorListVm>>(actors);
        }
    }
}
