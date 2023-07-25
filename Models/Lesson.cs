using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProShopPlus.Models
{
    public class Lesson
    {
        //Keys
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Contact ID")]
        [ForeignKey("ContactID")]
        public int? ContactID { get; set; }

        
        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? StartDate { get; set; }

        [Required]
        public string? Coach { get; set; }

        
        [Required]
        public string? Plan { get; set; }

        
        public string? Note { get; set; }



        [DisplayName("Paid")]
        public bool? Paid { get; set; } = default!;
        [DisplayName("Complete")]
        public bool? Complete { get; set; } = default!;

        
        public Contact? Contact { get; set; }
    }
}
