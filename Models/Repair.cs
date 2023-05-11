using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShopPlus.Models
{
    public class Repair
    {

        // Keys
        [Key]
        public int ID { get; set; }
        [ForeignKey("ContactID")]
        public int ContactID { get; set; }

        // Dates ---------------------|
        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? StartDate { get; set; }

        [DisplayName("Target Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateOnly? TargetDate { get; set; }

        // Repair Info ---------------------|
        [Required]
        [DisplayName("Repair Type")]
        public string? Type { get; set; }
        [Required]
        [DisplayName("Components")]
        public string? Component { get; set; }
        [DisplayName("Repair Description")]
        public string? Description { get; set; }

        // Payment ---------------------|
        [DisplayName("Cost")]
        public double? Cost { get; set; }
        [Required]
        [DisplayName("Paid")]
        public string? Paid { get; set; }
        [DisplayName("Balance")]
        public double? Balance { get; set; }

        //Progress ---------------------|
        [Required]
        public string? Progress { get; set; }

        public Contact? Contact { get; set; }

        
    }
}
