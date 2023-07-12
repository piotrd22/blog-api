using Blog.DTOs.PostDTO;

namespace Blog.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post?> GetPost(int id)
        {
            var post = await _dataContext.Posts.FindAsync(id);
            return post;
        }

        public async Task<Post> AddPost(Post post)
        {
            var entityEntry = _dataContext.Add(post);
            await _dataContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<Post?> DeletePost(int id)
        {
            var post = await _dataContext.Posts.FindAsync(id);
            if (post == null) { return null; }

            var entityEntry = _dataContext.Posts.Remove(post);
            await _dataContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<Post?> UpdatePost(int id, Post request)
        {
            var post = await _dataContext.Posts.FindAsync(id);
            if (post == null) { return null; }

            post.Description = request.Description;
            post.Title = request.Title;
            post.UpdatedAt = request.UpdatedAt;

            await _dataContext.SaveChangesAsync();

            return post;
        }
    }
}
