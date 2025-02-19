using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MovieShopRental.Models;

namespace MovieRental.Models
{
    public class RentalDetail
    {
        [Key]
        public int RentalDetailId { get; set; }
        public int RentalHeaderId { get; set; }
        public int MovieId { get; set; }
        public RentalHeader? RentalHeader { get; set; }
        public Movie? Movies { get; set; }




    }
}
