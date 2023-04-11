using Microsoft.EntityFrameworkCore;
using Movies.Application.RequestHelpers;
using Movies.Application.Respository;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence.Repository
{
    public class FilmRespository : BaseRepository<Film>, IFilmRepository
    {
        public FilmRespository(SakilaContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Film>> GetFilmsWithDetails(GetFilmsQueryParameters filmsQueryParameters)
        {
            var films = dbContext.Films.AsNoTracking();
            if(filmsQueryParameters.Title!= null)
            {
                films = films.Where(f => f.Title.ToLower().Contains(filmsQueryParameters.Title.ToLower()));
            }
            return await films.OrderBy(f => f.Title)
                .Skip(filmsQueryParameters.Size * (filmsQueryParameters.Page- 1))
                .Take(filmsQueryParameters.Size)
                .ToListAsync();
        }

        public async Task<int> GetFilmsCount(GetFilmsQueryParameters filmsQueryParameters)
        {
            var films = dbContext.Films.AsNoTracking();

            if (filmsQueryParameters.Title != null)
            {
                films = films.Where(f => f.Title.ToLower().Contains(filmsQueryParameters.Title.ToLower()));
            }

            return films.Count() ;
        }

        public async Task<Film> GetFilmDetails(int id)
        {
            var film = await dbContext.Films.AsNoTracking()
                .Include(f => f.FilmCategories).ThenInclude(fc => fc.Category)
                .Include(f => f.Language)
                .Include(f => f.OriginalLanguage)
                .FirstOrDefaultAsync(f => f.FilmId == id);

            return film;
        }
    }
}
