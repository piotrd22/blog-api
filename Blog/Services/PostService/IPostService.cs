using Blog.DTOs.PostDTO;

namespace Blog.Services.PostService
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post?> GetPost(int id);
        Task<Post> AddPost(Post post);
        Task<Post?> UpdatePost(int id, Post post);
        Task<Post?> DeletePost(int id);
    }
}
