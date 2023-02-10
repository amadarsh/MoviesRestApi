using Movies.Application.Features.Film.Query.GetFilmsListQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Responses
{
    public class GetFilmsPagedResponse : PagedResponse
    {
        public List<FilmListVm> Films { get; private set; }
        public GetFilmsPagedResponse(int totalCount, int pageSize, int currentPage, List<FilmListVm> films) : base(totalCount, pageSize, currentPage)
        {
            Films = films;
        }
    }
}
