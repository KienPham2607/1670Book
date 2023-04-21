using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1670Book.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Book name must between 5 to 100 charecter"), MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        [Required, DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 101, ErrorMessage = "Book unit price must be 1 to 100 dolar")]
        public double Price { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Quantity must be 1 to 1000")]
        public int Quantity { get; set; }
        [Required, StringLength(255), MaxLength(255), MinLength(1)]
        public string Image { get; set; }
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int IdCategory { get; set; }
        public virtual Category? Category { get; set; }
    }
}
