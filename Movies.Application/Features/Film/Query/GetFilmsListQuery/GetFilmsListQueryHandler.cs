using AutoMapper;
using MediatR;
using Movies.Application.Responses;
using Movies.Application.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Film.Query.GetFilmsListQuery
{
    public class GetFilmsListQueryHandler : IRequestHandler<GetFilmsListQuery, GetFilmsPagedResponse>
    {
        private readonly IMapper mapper;
        private readonly IFilmRepository filmRepository;

        public GetFilmsListQueryHandler(IMapper mapper, IFilmRepository filmRepository)
        {
            this.mapper = mapper;
            this.filmRepository = filmRepository;
        }
        public async Task<GetFilmsPagedResponse> Handle(GetFilmsListQuery request, CancellationToken cancellationToken)
        {
            var films = await filmRepository.GetFilmsWithDetails(request.queryParameters);
            int totalCount = await filmRepository.GetFilmsCount(request.queryParameters);
            var dtos = mapper.Map<List<FilmListVm>>(films);
            return new GetFilmsPagedResponse(totalCount, dtos.Count, request.queryParameters.Page, dtos);
        }
    }
}
