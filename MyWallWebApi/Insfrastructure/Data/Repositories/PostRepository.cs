using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWallWebApi.Models;

namespace MyWallWebApi.Insfrastructure.Data.Repositories
{
    public class PostRepository
    {

        private readonly SqliteContext _context;

        public PostRepository(SqliteContext context)
        {
            _context = context;
        }

        
        public async Task<List<Post>> ListPosts()
        {
            List<Post> list = await _context.Post.ToListAsync();

            return list;
        }



        
        public async Task<Post> GetPost(int postId)
        {
            Post? post = await _context.Post.FindAsync(postId);

            return post;
        }



        public async Task<Post> NewPost(Post post)
        {

            var countId = await _context.Post.CountAsync();

            var ret = await _context.Post.AddAsync(post);

            await _context.SaveChangesAsync();

            ret.State = EntityState.Detached;

            return ret.Entity;
        }



        public async Task<int> UpdatePost(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }



        public async Task<bool> DeletePost(int postid)
        {
            var item = await _context.Post.FindAsync(postid);
            _context.Post.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
