using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class RentalHeader
    {
        [Key] 
        public int RentalHeaderId { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public Customers? Customer { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public ICollection<RentalDetail>? RentalDetails { get; set; }


           
        }
    }

