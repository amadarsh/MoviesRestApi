using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movies.Application.Features.Film.Query.GetActorsByFilmQuery
{
    public class ActorListVm
    {
        public ushort ActorId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime LastUpdate { get; set; }
    }
}