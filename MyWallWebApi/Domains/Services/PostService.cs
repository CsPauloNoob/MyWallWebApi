using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWallWebApi.Domains.Models;
using MyWallWebApi.Insfrastructure.Data.Repositories;
using MyWallWebApi.Models;

namespace MyWallWebApi.Domains.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;
        private readonly AuthService _authService;


        public PostService(PostRepository postRepository, AuthService authService)
        {
            _postRepository = postRepository;
            _authService = authService;
        }


        [AllowAnonymous]
        public async Task<List<Post>> ListPosts()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            List<Post> list = await _postRepository.ListPostsByUserId(currentUser.Id);

            return list;
        }


        public async Task<List<Post>> ListUserPosts()
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
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            Post novoPost = new Post();

            novoPost.ApplicationUserId = currentUser.Id;
            novoPost.Title = post.Title;
            novoPost.Content = post.Content;
            novoPost.CreatedDate = DateTime.Now;

            novoPost = await _postRepository.NewPost(novoPost);

            return novoPost;
        }



        public async Task<int> UpdatePost(Post post)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Post findPost = await _postRepository.GetPost(post.Id);
            if (findPost == null)
                throw new ArgumentException("Post não existe!");

            if (!findPost.ApplicationUserId.Equals(currentUser.Id))
                throw new ArgumentException("Sem permissão.");

            findPost.Title = post.Title;
            findPost.Content = post.Content;

            return await _postRepository.UpdatePost(findPost);
        }



        public async Task<bool> DeletePost(int postId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Post findPost = await _postRepository.GetPost(postId);
            if (findPost == null)
                throw new ArgumentException("Post não existe!");

            if (!findPost.ApplicationUserId.Equals(currentUser.Id))
                throw new ArgumentException("Sem permissão.");

            await _postRepository.DeletePost(postId);

            return true;

        }
    }
}