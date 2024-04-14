using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAssignment.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Item name")]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
        public decimal Price { get; set; }

        public string? PictureUrl { get; set; }
    }
}
