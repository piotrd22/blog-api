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

        //public async Task<Post> AddPost(CreatePostRequest post)
        //{
        //    _dataContext.Add(post);
        //    await _dataContext.SaveChangesAsync();
        //    return 
        //}
    }
}
