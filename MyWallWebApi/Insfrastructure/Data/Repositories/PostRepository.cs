using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWallWebApi.Domains.Models;
using MyWallWebApi.Insfrastructure.Data.Contexts;
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
            List<Post> list = await _context.Post.OrderBy(date => date.CreatedDate).ToListAsync();

            return list;
        }

        public async Task<List<Post>> ListPostsByUserId(string applicationUserId)
        {
            List<Post> list = await _context.Post.Where(user => user.ApplicationUserId == applicationUserId)
                .OrderBy(date => date.CreatedDate).ToListAsync();

            return list;
        }


        public async Task<Post> GetPost(int postId)
        {
            Post? post = await _context.Post.Include(p => p.ApplicationUser).FirstAsync(p => p.Id == postId);

            return post;
        }



        public async Task<Post> NewPost(Post post)
        {

            var ret = await _context.Post.AddAsync(post);

            await _context.SaveChangesAsync();

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
