using Shopping.Insfrastructure.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá trị")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Độ dài tối thiểu là 2 ký tự")]

        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage ="Vui lòng nhập ký tự")]
        [Column(TypeName="decimal(8,2)")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục")]
        public long CategoryId { get; set; }

        public Category Category { get; set; }
        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
