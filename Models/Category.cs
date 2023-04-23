using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1670Book.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50), MaxLength(50), MinLength(1)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
