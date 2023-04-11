using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Film.Query.GetActorsByFilmQuery
{
    public class GetActorsByFilmQuery: IRequest<List<ActorListVm>>
    {
        public int FilmId { get; set; }
    }
}
