using Movies.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movies.Application.Features.Film.Query.GetFilmsListQuery
{
    public class FilmListVm
    {
        public ushort FilmId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public short? ReleaseYear { get; set; }
        public byte LanguageId { get; set; }
        public byte? OriginalLanguageId { get; set; }
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public ushort? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string? Rating { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<CategoryDto> FilmCategories { get; set; } = new List<CategoryDto>();
        public List<InventoryDto> Inventories { get; set; } = new List<InventoryDto>();
        public string Language { get; set; } = null!;
        public string? OriginalLanguage { get; set; }
    }

    public class InventoryDto
    {
    }

    public class FilmCategoryDto
    {

    }

    public class CategoryDto
    {
        public byte CategoryId { get; set; }

        public string Name { get; set; } = null!;
    }
}