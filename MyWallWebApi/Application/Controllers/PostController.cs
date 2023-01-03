using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyWallWebApi.Domains.Services;
using MyWallWebApi.Insfrastructure.Data.Repositories;
using MyWallWebApi.Models;

namespace MyWallWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }


        [AllowAnonymous]
        [HttpGet("list-posts")]
        public async Task<ActionResult> ListPosts()
        {
            List<Post> list = await _postService.ListPosts();

            return Ok(list);
        }


        [HttpGet("list-my-posts")]
        public async Task<ActionResult> ListMyPosts()
        {
            List<Post> list = await _postService.ListUserPosts();

            return Ok(list);
        }

        [AllowAnonymous]
        [HttpGet("get-post")]
        public async Task<ActionResult> GetPost([FromQuery] int postId)
        {
            try
            {
                Post? item = await _postService.GetPost(postId);
                return Ok(item);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost("new-post")]
        public async Task<ActionResult> NewPost(Post post)
        {
            try
            {
                post = await _postService.NewPost(post);

                return Ok(post);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("update-post")]
        public async Task<ActionResult> UpdatePost(Post post)
        {
            try
            {
                return Ok(await _postService.UpdatePost(post));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("delete-post")]
        public async Task<ActionResult> DeletePost([FromBody] int id)
        {
            try
            {
                return Ok(await _postService.DeletePost(id));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
