using Movies.Application.RequestHelpers;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Respository
{
    public interface IFilmRepository: IAsyncRepository<Film>
    {
        Task<IEnumerable<Film>> GetFilmsWithDetails(GetFilmsQueryParameters filmsQueryParameters);
        Task<int> GetFilmsCount(GetFilmsQueryParameters filmsQueryParameters);
        Task<Film> GetFilmDetails(int id);
    }
}
