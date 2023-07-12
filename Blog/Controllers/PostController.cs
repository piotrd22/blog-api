using AutoMapper;
using Blog.DTOs.PostDTO;
using Blog.Services.PostService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDTO>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();
            var postDTOs = posts.Select(post => _mapper.Map<PostDTO>(post)).ToList();
            return Ok(postDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<PostDTO>> AddPost(CreatePostRequest post)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var postToService = _mapper.Map<Post>(post);
            var addedPost = await _postService.AddPost(postToService);
            var addedPostDTO = _mapper.Map<PostDTO>(addedPost);
            return Ok(addedPostDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            if (post == null) { return NotFound(); }

            var postDTO = _mapper.Map<PostDTO>(post);
            return Ok(postDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PostDTO>> DeletePost(int id)
        {
            var post = await _postService.DeletePost(id);
            if (post == null) { return NotFound(); }

            var postDTO = _mapper.Map<PostDTO>(post);
            return Ok(postDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostDTO>> UpdatePost(int id, UpdatePostRequest post)
        {
            if (!ModelState.IsValid || id != post.Id) { return BadRequest(); }

            var postToService = _mapper.Map<Post>(post);
            var updatedPost = await _postService.UpdatePost(id, postToService);
            if (updatedPost == null) { return NotFound(); }

            var updatedPostDTO = _mapper.Map<PostDTO>(updatedPost);
            return Ok(updatedPostDTO);
        }
    }
}
