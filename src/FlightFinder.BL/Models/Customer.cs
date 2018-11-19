using System.ComponentModel.DataAnnotations;

namespace FlightFinder.BL.Models
{
    public class Customer
    {
        [Required, MinLength(6)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}