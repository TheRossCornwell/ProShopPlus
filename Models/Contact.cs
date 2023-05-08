using System.ComponentModel.DataAnnotations;

namespace ProShopPlus.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Telephone Number Required")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Phone]
        public string? AltPhoneNumber { get; set; }

        public string? Notes { get; set; }
    }
}
