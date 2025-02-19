using MovieRental.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieShopRental.Models
{
    public class Movie
    {
       

        [Key]
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }

        public int ReleaseYear { get; set; }
        public string? Director { get; set; }

        public string? Description { get; set; }
        public ICollection<RentalDetail> ?RentalDetails { get; set; }
    }
}
