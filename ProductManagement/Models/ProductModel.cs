using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProductManagement.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int Code { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        [StringLength(4000, MinimumLength = 10, ErrorMessage ="MinimumLength Should be 10 and Maximum 4000")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        
        public DateTime ExpiryDate { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        public string Category { get; set; }
        public string ProductImage { get; set; }
        [Required(ErrorMessage = "choose one")]
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

