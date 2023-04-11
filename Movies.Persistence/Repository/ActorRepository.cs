using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Actor>> GetActorsByFilmId(int filmId)
        {
            var actors = dbContext.FilmActors.AsNoTracking()
                .Include(x => x.Actor)
                .Where(fa => fa.FilmId == filmId)
                .Select(fa => fa.Actor);

            return await actors.ToListAsync();
        }
    }
}
