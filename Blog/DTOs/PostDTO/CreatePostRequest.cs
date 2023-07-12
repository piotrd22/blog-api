using System.ComponentModel.DataAnnotations;

namespace Blog.DTOs.PostDTO
{
    public class CreatePostRequest
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must be between 1 and 100 characters", MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
    }
}
