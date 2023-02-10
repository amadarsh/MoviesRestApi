using Movies.Application.Respository;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence.Repository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRespository
    {
        public ActorRepository(SakilaContext dbContext) : base(dbContext)
        {
        }
    }
}
