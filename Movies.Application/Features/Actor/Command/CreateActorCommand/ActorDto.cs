namespace Movies.Application.Features.Actors.Command.CreateActorCommand
{
    public class ActorDto
    {
        public ushort ActorId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime LastUpdate { get; set; }
    }
}