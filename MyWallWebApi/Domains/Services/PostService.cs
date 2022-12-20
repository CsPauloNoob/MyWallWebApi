using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWallWebApi.Insfrastructure.Data.Repositories;
using MyWallWebApi.Models;

namespace MyWallWebApi.Domains.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;



        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }



        public async Task<List<Post>> ListPosts()
        {
            List<Post> list = await _postRepository.ListPosts();

            return list;
        }



        public async Task<Post> GetPost( int postId)
        {
            Post? item = await _postRepository.GetPost(postId);

            if (item == null)
            {
                throw new ArgumentException("O post não existe!");
            }

            return item;
        }



        public async Task<Post> NewPost(Post post)
        {
            post.CreatedDate = DateTime.Now;

            post = await _postRepository.NewPost(post);

            return post;
        }



        public async Task<int> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }



        public async Task<bool> DeletePost(int postId)
        {
            var post = await _postRepository.GetPost(postId);

            if (post == null)
            {
                return false;
            }

            else
            {
                return await _postRepository.DeletePost(postId);
            }

        }
    }
}