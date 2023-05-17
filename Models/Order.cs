using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShopPlus.Models
{
    public class Order
    {

        //Keys
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Contact ID")]
        [ForeignKey("ContactID")]
        public int? ContactID { get; set; }

        // Dates ------------------|
        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? StartDate { get; set; }

        [DisplayName("Ordered Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? OrderDate { get; set; }

        [DisplayName("Estimated Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? EstimatedDate { get; set; }

        [DisplayName("Arrived Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? ArrivedDate { get; set; }

        // Order Info ----------------|
        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Product { get; set; }

        [DisplayName("Order Code")]
        public string? OrderCode { get; set; }

        // Payment ------------------|
        [DisplayName("Cost")]
        public double? Cost { get; set; }
        [Required]
        [DisplayName("Paid")]
        public string? Paid { get; set; }
        [DisplayName("Balance")]
        public double? Balance { get; set; }

        //Progress
        [Required]
        public string? Progress { get; set; }
        public Contact? Contact { get; set; }

    }
}
