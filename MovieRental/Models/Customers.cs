using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateOnly BirthDate { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
        
        public int Number { get; set; }

        public ICollection<RentalHeader> ?RentalHeader { get; set; }
    }
}
