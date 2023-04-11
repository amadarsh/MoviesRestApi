using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Features.Actors.Command.CreateActorCommand
{
    public class CreateActorCommand: IRequest<ActorDto>
    {
        [Required]
        [MaxLength(45)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(45)]
        public string LastName { get; set; } = null!;
    }
}
