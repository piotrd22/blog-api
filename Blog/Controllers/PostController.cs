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
    }
}
