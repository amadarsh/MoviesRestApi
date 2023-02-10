using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Features.Film.Query.GetFilmsListQuery;
using Movies.Application.RequestHelpers;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IMediator mediator;

        public FilmsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name ="GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetFilmsQueryParameters queryParameters)
        {
            return Ok(await mediator.Send(new GetFilmsListQuery { queryParameters = queryParameters}));
        }
    }
}
