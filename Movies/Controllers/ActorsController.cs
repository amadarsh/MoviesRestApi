using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Features.Actors.Command.CreateActorCommand;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ActorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody]CreateActorCommand createActorCommand)
        {
            var dto = await mediator.Send(createActorCommand);
            return Ok(dto);
        }
    }
}
