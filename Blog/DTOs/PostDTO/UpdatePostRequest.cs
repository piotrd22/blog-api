using System.ComponentModel.DataAnnotations;

namespace Blog.DTOs.PostDTO
{
    public class UpdatePostRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must be between 1 and 100 characters", MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Created at is required")]
        public DateTime? CreatedAt { get; set; }

        [Required(ErrorMessage = "Updated at is required")]
        public DateTime? UpdatedAt { get; set; }
    }
}
