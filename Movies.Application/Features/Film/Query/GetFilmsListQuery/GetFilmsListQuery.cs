using MediatR;
using Movies.Application.RequestHelpers;
using Movies.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Film.Query.GetFilmsListQuery
{
    public class GetFilmsListQuery:  IRequest<GetFilmsPagedResponse>
    {
        public GetFilmsQueryParameters queryParameters { get; set; } = new();
    }
}
