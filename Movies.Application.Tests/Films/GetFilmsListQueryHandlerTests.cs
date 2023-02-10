using AutoMapper;
using Moq;
using Movies.Application.Features.Film.Query.GetFilmsListQuery;
using Movies.Application.RequestHelpers;
using Movies.Application.Responses;
using Movies.Application.Respository;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movies.Application.Tests.Films
{
    public class GetFilmsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IFilmRepository> _mockRepository;
        public GetFilmsListQueryHandlerTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

            var films = GetFilms();
            _mockRepository = new Mock<IFilmRepository>();
            _mockRepository.Setup(mock => mock.GetFilmsWithDetails(It.IsAny<GetFilmsQueryParameters>())).ReturnsAsync(films);
            _mockRepository.Setup(mock => mock.AddAsync(It.IsAny<Film>())).ReturnsAsync(
                (Film film) =>
                {
                    films.Add(film);
                    return film;
                });
        }

        [Fact]
        public async Task GetFilmsListTest()
        {
            var handler = new GetFilmsListQueryHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new GetFilmsListQuery() { queryParameters = new RequestHelpers.GetFilmsQueryParameters()}, CancellationToken.None);

            Assert.IsType<GetFilmsPagedResponse>(result);
            Assert.Equal(6,result.Films.Count);

        }


        private List<Film> GetFilms()
        {
            return new List<Film>
            {
                new Film {FilmId = 1, Title = "Film 1"},
                new Film {FilmId = 2, Title = "Film 2"},
                new Film {FilmId = 3, Title = "Film 3"},
                new Film {FilmId = 4, Title = "Film 4"},
                new Film {FilmId = 5, Title = "Film 5"},
                new Film {FilmId = 6, Title = "Film 6"}
            };
        }
    }
}
