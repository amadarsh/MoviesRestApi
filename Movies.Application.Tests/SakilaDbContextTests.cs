using Microsoft.EntityFrameworkCore;
using Movies.Application.Respository;
using Movies.Persistence;
using Movies.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movies.Application.Tests
{
    public class SakilaDbContextTests
    {
        private readonly SakilaContext sakilaContext;
        private readonly IFilmRepository filmRepository;

        public SakilaDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<SakilaContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            sakilaContext = new SakilaContext(dbContextOptions);
            filmRepository = new FilmRespository(sakilaContext);
        }

        [Fact]
        public async Task CreateFilm()
        {
            var addedFilm = await filmRepository.AddAsync(new Domain.Entities.Film { Title = "Film1", LanguageId = 1, LastUpdate= DateTime.UtcNow,
                RentalDuration = 3, RentalRate = 10, ReplacementCost = 20});
            var film = await filmRepository.GetAsync(addedFilm.FilmId);
            Assert.NotNull(film);
            Assert.Equal("Film1", film.Title);
        }
    }
}
