using AutoMapper;
using Movies.Application.Features.Film.Query.GetFilmsListQuery;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FilmCategory, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(o => o.Category.Name));
            CreateMap<Film, FilmListVm>()
                .ForMember(dest => dest.Language, opt => opt.MapFrom(o => o.Language.Name))
                .ForMember(dest => dest.OriginalLanguage, opt => opt.MapFrom(o => o.OriginalLanguage != null ? o.OriginalLanguage.Name : null));
        }
    }
}
