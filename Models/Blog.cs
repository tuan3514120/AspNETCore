using Shopping.Insfrastructure.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Blog
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá trị")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Độ dài tối thiểu là 2 ký tự")]

        public string Description { get; set; }


		public string Image { get; set; } = "noimage.png";

		[NotMapped]
		[FileExtension]
		public IFormFile ImageUpload { get; set; }
	}
}
